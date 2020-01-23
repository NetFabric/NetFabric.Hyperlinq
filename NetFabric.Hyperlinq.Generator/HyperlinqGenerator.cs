using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Uno.RoslynHelpers;
using Uno.SourceGeneration;

namespace NetFabric.Hyperlinq.Generator
{
    public class HyperlinqGenerator 
        : SourceGenerator
    {
        ISourceGeneratorLogger logger;
        INamespaceSymbol hyperlinqNamespace;

        readonly Dictionary<string, List<IMethodSymbol>> collectedExtensionMethods = new Dictionary<string, List<IMethodSymbol>>();

        public override void Execute(SourceGeneratorContext context)
        {
            //_ = Debugger.Launch(); // uncomment to debug code generator

            logger = context.GetLogger();
            logger.Info("Executing Hyperlinq generator!");

            var compilation = context.Compilation;
            hyperlinqNamespace = compilation.SourceModule.GlobalNamespace.GetNamespace("NetFabric", "Hyperlinq");

            CollectExtensionMethods(context);
            GenerateSource(context);
        }

        void CollectExtensionMethods(SourceGeneratorContext context)
        {
            logger.Info("Collecting extension methods with interface constraints!");

            foreach (var method in hyperlinqNamespace
                .GetTypeMembers()
                .Where(type => type.IsPublic() && type.IsStatic)
                .SelectMany(type => type.GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method => 
                    method.IsPublic() && 
                    method.IsExtensionMethod && 
                    method.IsGenericMethod &&
                    !method.ShouldIgnore(context.Compilation))))
            {
                var extensionType = method.Parameters[0].Type;

                var generic = method.TypeParameters
                    .FirstOrDefault(parameter => 
                        parameter.Name == extensionType.Name &&
                        parameter.ConstraintTypes.Length != 0);

                if (generic is object)
                {
                    var constraintType = generic.ConstraintTypes[0];
                    var key = constraintType.OriginalDefinition.MetadataName;
                    if (!collectedExtensionMethods.TryGetValue(key, out var list))
                    {
                        list = new List<IMethodSymbol>();
                        collectedExtensionMethods.Add(key, list);
                    }
                    list.Add(method);
                }
            }
        }

        void GenerateSource(SourceGeneratorContext context)
        {
            logger.Info("Generate the extensions source!");

            foreach (var containerClass in hyperlinqNamespace
                .GetTypeMembers()
                .Where(type => 
                    type.IsPublic() &&
                    type.IsStatic && 
                    type.IsReferenceType &&
                    !type.ShouldIgnore(context.Compilation)))
            {
                var assemblyName = GetType().Assembly.GetName().Name;
                var assemblyVersion = ((System.Reflection.AssemblyInformationalVersionAttribute)Attribute.GetCustomAttribute(GetType().Assembly, typeof(System.Reflection.AssemblyInformationalVersionAttribute), false))?.InformationalVersion ?? string.Empty;
                var generatedCodeAttribute = $"[GeneratedCode(\"{assemblyName}\", \"{assemblyVersion}\")]";

                foreach (var extendedType in 
                    containerClass.GetTypeMembers()
                    .OfType<INamedTypeSymbol>()
                    .Where(type => 
                        !type.IsStatic &&
                        !type.IsInterface()))
                {
                    var valueEnumerableInterface = extendedType.GetAllInterfaces()
                        .FirstOrDefault(@interface => @interface.Name == "IValueEnumerable" || @interface.Name == "IAsyncValueEnumerable");

                    if (valueEnumerableInterface is null)
                        continue;

                    var enumerableType = extendedType;
                    var enumeratorType = valueEnumerableInterface.TypeArguments[1];
                    var sourceType = valueEnumerableInterface.TypeArguments[0];

                    var genericsMapping = ImmutableArray.CreateRange(extendedType.GetGenericMappings(context.Compilation));

                    var implementedInstanceMethods = extendedType.GetMembers().OfType<IMethodSymbol>()
                        .Select(method => Tuple.Create(
                            method.Name, 
                            method.Parameters
                                .Select(parameter => parameter.Type.ToDisplayString())
                                .ToList()));

                    var implementedExtensionMethods = containerClass.GetMembers().OfType<IMethodSymbol>()
                        .Where(method => 
                            method.IsExtensionMethod &&
                            method.Parameters[0].Type.ToDisplayString() == extendedType.ToDisplayString())
                        .Select(method => Tuple.Create(
                            method.Name, 
                            method.Parameters
                                .Skip(1)
                                .Select(parameter => parameter.Type.ToDisplayString())
                                .ToList()));

                    var implementedMethods = implementedInstanceMethods.Concat(implementedExtensionMethods)
                        .ToList();

                    var instanceMethods = new List<IMethodSymbol>();
                    var extensionMethods = new List<IMethodSymbol>();

                    foreach (var implementedType in extendedType.AllInterfaces)
                    {
                        // get the extension methods for this interface
                        var key = implementedType.OriginalDefinition.MetadataName;
                        if (!collectedExtensionMethods.TryGetValue(key, out var implementedTypeMethods))
                            continue;

                        foreach (var implementedTypeMethod in implementedTypeMethods)
                        {
                            var methodName = implementedTypeMethod.Name;
                            var methodParameters = implementedTypeMethod.Parameters
                                .Skip(1)
                                .Select(parameter => parameter.Type.ToDisplayString(genericsMapping))
                                .ToList();

                            // check if already implemented
                            if (!implementedMethods.Any(method =>
                                method.Item1 == methodName && 
                                Enumerable.SequenceEqual(method.Item2, methodParameters)))
                            {
                                // check there's a collision with a property
                                if (extendedType.GetMembers().OfType<IPropertySymbol>()
                                    .Any(property => property.Name == methodName))
                                {
                                    extensionMethods.Add(implementedTypeMethod);
                                }
                                else
                                {
                                    instanceMethods.Add(implementedTypeMethod);
                                }

                                implementedMethods.Add(Tuple.Create(methodName, methodParameters));
                            }
                        }
                    }

                    if(instanceMethods.Count != 0 || extensionMethods.Count != 0)
                    {
                        var builder = new IndentedStringBuilder();
                        builder.AppendLineInvariant("using System;");
                        builder.AppendLineInvariant("using System.CodeDom.Compiler;");
                        builder.AppendLineInvariant("using System.Diagnostics;");
                        builder.AppendLineInvariant("using System.Diagnostics.Contracts;");
                        builder.AppendLineInvariant("using System.Runtime.CompilerServices;");

                        using (builder.BlockInvariant($"namespace {containerClass.ContainingNamespace}"))
                        {
                            using (builder.BlockInvariant($"public static partial class {containerClass.Name}"))
                            {
                                if (instanceMethods.Count != 0)
                                {
                                    var extendedTypeGenericParameters = string.Empty;
                                    if (extendedType.IsGenericType)
                                    {
                                        var parametersDefinition = new System.Text.StringBuilder();
                                        _ = parametersDefinition.Append($"<{extendedType.TypeParameters.Select(parameter => parameter.ToDisplayString()).ToCommaSeparated()}>");
                                        foreach (var typeParameter in extendedType.TypeParameters.Where(typeParameter => typeParameter.ConstraintTypes.Length != 0))
                                            _ = parametersDefinition.Append($" where {typeParameter.Name} : {typeParameter.AsConstraintsStrings().ToCommaSeparated()}");
                                        extendedTypeGenericParameters = parametersDefinition.ToString();
                                    }

                                    var entity = extendedType.IsValueType ? "readonly partial struct" : "partial class";
                                    using (builder.BlockInvariant($"public {entity} {extendedType.Name}{extendedTypeGenericParameters}"))
                                    {
                                        foreach(var instanceMethod in instanceMethods)
                                        {
                                            AddInstanceMethod(builder, extendedType, instanceMethod, enumerableType, enumeratorType, generatedCodeAttribute, genericsMapping);
                                        }
                                    }
                                }

                                foreach(var extensionMethod in extensionMethods)
                                {
                                    AddExtensionMethod(builder, extendedType, extensionMethod, enumerableType, enumeratorType, generatedCodeAttribute, genericsMapping);
                                }
                            }
                        }

                        context.AddCompilationUnit(extendedType.ToString(), builder.ToString()); 
                    }
                }
            }
        }

        void AddInstanceMethod(IndentedStringBuilder builder, INamedTypeSymbol extendedType, IMethodSymbol implementedTypeMethod, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, string generatedCodeAttribute, IEnumerable<(string, string, bool)> genericsMapping)
        {
            var typeParameters = Extensions.ExtractMethodTypeArguments(extendedType, implementedTypeMethod, genericsMapping)
                .Where(typeParameter => !extendedType.TypeParameters.Any(t => t.Name == typeParameter.Name))
                .ToList();

            var methodReadonly = extendedType.IsValueType ? "readonly" : string.Empty;
            var methodReturnType = implementedTypeMethod.ReturnType.ToDisplayString(enumerableType, enumeratorType, genericsMapping);
            if (methodReturnType == "TEnumerable") 
                methodReturnType = extendedType.ToDisplayString();
            var methodName = implementedTypeMethod.Name;
            var methodExtensionType = extendedType.ToDisplayString();
            var methodParameters = implementedTypeMethod.Parameters.AsParametersDeclarationString(genericsMapping);
            var methodGenericParameters = typeParameters.Any() ? 
                $"<{typeParameters.Select(typeParameter => typeParameter.Name).ToCommaSeparated()}>" :
                string.Empty;

            var returnKeyword = string.Empty;
            var callContainingType = implementedTypeMethod.ContainingType.ToDisplayString(genericsMapping);
            var callMethod = implementedTypeMethod.ToDisplayString(enumerableType, enumeratorType, genericsMapping);
            var callParameters = implementedTypeMethod.Parameters.AsParametersString()
                .Replace(implementedTypeMethod.Parameters[0].Name, "this");

            builder.AppendLineInvariant(generatedCodeAttribute);
            builder.AppendLineInvariant("[DebuggerNonUserCode]");
            builder.AppendLineInvariant("[MethodImpl(MethodImplOptions.AggressiveInlining)]");
            if (!implementedTypeMethod.ReturnsVoid)
                builder.AppendLineInvariant("[Pure]");
            builder.AppendLineInvariant($"public {methodReadonly} {methodReturnType} {methodName}{methodGenericParameters}({methodParameters})");
            foreach (var (name, constraints) in typeParameters.Where(typeParameter => typeParameter.Constraints.Any()))
                builder.AppendLineInvariant($"where {name} : {constraints.ToCommaSeparated()}");
            builder.AppendLineInvariant($"=> {callContainingType}.{callMethod}({callParameters});");
            builder.AppendLine();
        }

        void AddExtensionMethod(IndentedStringBuilder builder, INamedTypeSymbol extendedType, IMethodSymbol implementedTypeMethod, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, string generatedCodeAttribute, IEnumerable<(string, string, bool)> genericsMapping)
        {
            var typeParameters = Extensions.ExtractMethodTypeArguments(extendedType, implementedTypeMethod, genericsMapping);

            var methodReturnType = implementedTypeMethod.ReturnType.ToDisplayString(enumerableType, enumeratorType, genericsMapping);
            if (methodReturnType == "TEnumerable") 
                methodReturnType = extendedType.ToDisplayString();
            var methodName = implementedTypeMethod.Name;
            var methodExtensionType = extendedType.ToDisplayString();
            var methodParameters = implementedTypeMethod.Parameters.Length > 1
                ? $", {implementedTypeMethod.Parameters.AsParametersDeclarationString(genericsMapping)}"
                : string.Empty;
            var methodGenericParameters = typeParameters.Any() 
                ? $"<{typeParameters.Select(typeParameter => typeParameter.Name).ToCommaSeparated()}>" 
                : string.Empty;

            var returnKeyword = string.Empty;
            var callContainingType = implementedTypeMethod.ContainingType.ToDisplayString(genericsMapping);
            var callMethod = implementedTypeMethod.ToDisplayString(enumerableType, enumeratorType, genericsMapping);
            var callParameters = implementedTypeMethod.Parameters.AsParametersString();

            builder.AppendLineInvariant(generatedCodeAttribute);
            builder.AppendLineInvariant("[DebuggerNonUserCode]");
            builder.AppendLineInvariant("[MethodImpl(MethodImplOptions.AggressiveInlining)]");
            if (!implementedTypeMethod.ReturnsVoid)
                builder.AppendLineInvariant("[Pure]");
            builder.AppendLineInvariant($"public static {methodReturnType} {methodName}{methodGenericParameters}(this {methodExtensionType} source{methodParameters})");
            foreach (var (name, constraints) in typeParameters.Where(typeParameter => typeParameter.Constraints.Any()))
                builder.AppendLineInvariant($"where {name} : {constraints.ToCommaSeparated()}");
            builder.AppendLineInvariant($"=> {callContainingType}.{callMethod}({callParameters});");
            builder.AppendLine();
        }
    }
}