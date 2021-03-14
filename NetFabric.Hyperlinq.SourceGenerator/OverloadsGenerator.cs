using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    [Generator]
    public class OverloadsGenerator
        : ISourceGenerator
    {
        static readonly DiagnosticDescriptor unhandledExceptionError = new(
            id: "HPLG001",
            title: "Unhandled exception while generating overloads",
            messageFormat: "Unhandled exception while generating overloads: {0}",
            category: "OverloadsGenerator",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);


        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            //_ = Debugger.Launch(); // uncomment to debug this source generator

            var compilationContext = new CompilationContext(context.Compilation);

            try
            {
                var collectedExtensionMethods = CollectExtensionMethods(compilationContext);

                var generatedSources = GenerateSource(collectedExtensionMethods, compilationContext);
                foreach (var (containerClass, extendingType, generatedSource) in generatedSources)
                {
                    var hitName = $"{containerClass.OriginalDefinition.MetadataName}.{extendingType.OriginalDefinition.MetadataName}.g.cs";
                    hitName = hitName.Replace('`', '.');
                    context.AddSource(hitName, SourceText.From(generatedSource, Encoding.UTF8));
                }

            }
            catch (Exception ex)
            {
                context.ReportDiagnostic(Diagnostic.Create(unhandledExceptionError, Location.None, ex.Message));
            }
        }

        bool ConsiderExtensionMethod(IMethodSymbol symbol, CompilationContext context)
        {
            var attribute = symbol.GetIgnoreAttribute(context);
            return attribute switch
            {
                null => symbol.IsPublic(),
                _ => !attribute.Value
            };
        }

        /// <summary>
        /// Collects all the extension methods defined
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A dictionary containing collections of the extension methods per type extended.</returns>
        internal DictionarySet<string, MethodInfo> CollectExtensionMethods(CompilationContext context)
        {
            var collectedExtensionMethods = new DictionarySet<string, MethodInfo>();
            
            // go through all implemented static types and get all the extension methods implemented
            var extensionMethods = context.Compilation.SourceModule.GlobalNamespace
                .GetAllTypes()
                .Where(typeSymbol =>
                    typeSymbol.IsStatic
                    && typeSymbol.IsPublic())
                .SelectMany(typeSymbol =>
                    typeSymbol.GetMembers()
                        .OfType<IMethodSymbol>()
                        .Where(methodSymbol =>
                            methodSymbol.IsExtensionMethod 
                            && ConsiderExtensionMethod(methodSymbol, context)));

            // go through all extension methods and store the ones where the extended type is a constrained generic parameter
            foreach (var extensionMethod in extensionMethods)
            {
                var extensionType = extensionMethod.Parameters[0].Type;
                var generic = extensionMethod.TypeParameters
                    .FirstOrDefault(typeParameter 
                        => typeParameter.ConstraintTypes.Length > 0
                        && typeParameter.Name == extensionType.Name);
                if (generic is null)
                {
                    var name = extensionMethod.Parameters[0].Type.OriginalDefinition.MetadataName;
                    switch (name)
                    {
                        case "ArraySegment`1":
                        case "ReadOnlySpan`1":
                        case "ReadOnlyMemory`1":
                            collectedExtensionMethods.Add(name, extensionMethod.GetInfo(context, 1));
                            break;
                    }
                }
                else
                {
                    var extendingType = generic.ConstraintTypes[0];
                    var name = extendingType.OriginalDefinition.MetadataName;
                    switch (name)
                    {
                        case "IValueEnumerable`2":
                        case "IValueReadOnlyCollection`2":
                        case "IReadOnlyList`1":
                        case "IAsyncValueEnumerable`2":
                            collectedExtensionMethods.Add(name, extensionMethod.GetInfo(context, 1));
                            break;
                    }
                }
            }

            return collectedExtensionMethods;
        }

        /// <summary>
        /// Generates the source for the overloads based on the defined extension methods.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="collectedExtensionMethods">A dictionary containing the defined extension methods.</param>
        /// <param name="generatedPath">The path where to serialize the generated code for debugging.</param>
        internal IEnumerable<(INamedTypeSymbol ContainerClass, INamedTypeSymbol ExtendedType, string Source)> GenerateSource(DictionarySet<string, MethodInfo> collectedExtensionMethods, CompilationContext context)
        {
            // go through all candidate types to be extended
            // these are inner types of a public static class that are not static and not interfaces
            foreach (var extendingType in context.Compilation.SourceModule.GlobalNamespace
                .GetAllTypes()
                .Where(type => type.IsStatic && type.IsReferenceType && type.IsPublic() && !type.ShouldIgnore(context))
                .SelectMany(containerType => containerType.GetTypeMembers().OfType<INamedTypeSymbol>()
                    .Where(type => !(type.IsStatic || type.IsInterface() || type.ShouldIgnore(context)))))
            {
                var bindingAttribute = extendingType.GetBindingsAttribute(context);
                foreach (var source in GenerateSource(collectedExtensionMethods, context, extendingType, bindingAttribute))
                    yield return source;
            }
        }

        IEnumerable<(INamedTypeSymbol ContainerClass, INamedTypeSymbol ExtendedType, string Source)> GenerateSource(DictionarySet<string, MethodInfo> collectedExtensionMethods, CompilationContext context, INamedTypeSymbol extendingType, GeneratorBindingsAttribute? bindingsAttribute)
        {
            // check if it's a value enumerable and keep a reference to the implemented interface
            var valueEnumerableInterface = extendingType.GetAllInterfaces()
                .FirstOrDefault(@interface => @interface.Name is "IValueEnumerable" or "IAsyncValueEnumerable");
            if (valueEnumerableInterface is not null || bindingsAttribute is not null)
            {
                // get the types of the enumerable, enumerator and source from the generic parameters declaration
                var enumerableType = extendingType;
                var enumeratorType = valueEnumerableInterface?.TypeArguments[1];
                var sourceType = valueEnumerableInterface?.TypeArguments[0];

                // get the type mappings from the GeneratorMappingsAttribute, if found.
                var typeGenericsMapping = extendingType.GetGenericsMappings(context);

                // get the info of all the instance methods declared in the type to be extended
                var implementedInstanceMethods = extendingType.GetMembers().OfType<IMethodSymbol>()
                    .Where(method => method.Name is not ".ctor") // ignore the constructors
                    .Select(method => method.GetInfo(context))
                    .ToArray();

                // get the extension methods for this type declared in the outter static type
                var implementedExtensionMethods = extendingType.ContainingType.GetMembers().OfType<IMethodSymbol>()
                    .Where(method
                        => method.IsExtensionMethod
                        && method.Parameters[0].Type.ToDisplayString() == extendingType.ToDisplayString())
                    .Select(method => method.GetInfo(context, 1))
                    .ToArray();

                // join the two lists together as these are the implemented methods for this type
                var implementedMethods = implementedInstanceMethods.Concat(implementedExtensionMethods)
                    .ToList();

                // lists of methods to be generated
                var instanceMethodsToBeGenerated = new List<MethodInfo>();
                var extensionMethodsToBeGenerated = new List<MethodInfo>();

                // go through all the implemented interfaces so that 
                // the overloads are generated based on the extension methods defined for these
                var implementedTypes = 
                    bindingsAttribute?.SourceImplements?.Split(',')
                    ?? extendingType.AllInterfaces.Select(type => type.OriginalDefinition.MetadataName);

                foreach (var implementedType in implementedTypes)
                {
                    // get the extension methods collected for this interface
                    if (!collectedExtensionMethods.TryGetValue(implementedType, out var overloadingMethods))
                        continue;

                    // check which ones should be generated
                    // the method can be already defined by a more performant custom implementation
                    for (var methodIndex = 0; methodIndex < overloadingMethods.Count; methodIndex++)
                    {
                        var overloadingMethod = overloadingMethods[methodIndex];

                        // check if already implemented
                        var mappedOverloadingMethods = overloadingMethod.ApplyMappings(typeGenericsMapping);
                        if (!implementedMethods.Any(method => method.IsOverload(mappedOverloadingMethods))
                            && !((mappedOverloadingMethods.Name is "Select" || mappedOverloadingMethods.Name is "SelectAt") && (extendingType.Name.EndsWith("SelectEnumerable") || extendingType.Name.EndsWith("SelectAtEnumerable")))) // these cases are hard to fix other way
                        {
                            // check if there's a collision with a property
                            if (extendingType.GetMembers().OfType<IPropertySymbol>()
                                .Any(property => property.Name == mappedOverloadingMethods.Name))
                            {
                                // this method will be generated as an extension method
                                extensionMethodsToBeGenerated.Add(mappedOverloadingMethods);
                            }
                            else
                            {
                                // this method will generated as an instance method
                                instanceMethodsToBeGenerated.Add(mappedOverloadingMethods);
                            }

                            implementedMethods.Add(mappedOverloadingMethods);
                        }
                    }
                }

                // generate the code for the instance methods and extension methods, if any...
                if (instanceMethodsToBeGenerated.Count is not 0 || extensionMethodsToBeGenerated.Count is not 0)
                {
                    var builder = new CodeBuilder();
                    _ = builder
                        .AppendLine("#nullable enable")
                        .AppendLine()
                        .AppendLine("using System;")
                        .AppendLine("using System.CodeDom.Compiler;")
                        .AppendLine("using System.Diagnostics;")
                        .AppendLine("using System.Runtime.CompilerServices;")
                        .AppendLine();

                    using (builder.AppendBlock($"namespace NetFabric.Hyperlinq"))
                    {
                        // the generator extends the types by adding partial types
                        // both the outter and the inner types have to be declared as partial
                        using (builder.AppendBlock($"public static partial class {extendingType.ContainingType.Name}"))
                        {
                            // generate the instance methods in the inner type
                            if (instanceMethodsToBeGenerated.Count is not 0)
                            {
                                var extendingTypeGenericParameters = string.Empty;
                                if (extendingType.IsGenericType)
                                {
                                    var parametersDefinition = new StringBuilder();
                                    _ = parametersDefinition.Append($"<{extendingType.TypeParameters.Select(parameter => parameter.ToDisplayString()).ToCommaSeparated()}>");
                                    // foreach (var typeParameter in extendingType.TypeParameters.Where(typeParameter => typeParameter.ConstraintTypes.Length is not 0))
                                    //     _ = parametersDefinition.Append($" where {typeParameter.Name} : {typeParameter.AsConstraintsStrings().ToCommaSeparated()}");
                                    extendingTypeGenericParameters = parametersDefinition.ToString();
                                }

                                var entity = extendingType.IsValueType
                                    ? "struct"
                                    : "class";
                                using (builder.AppendBlock($"public partial {entity} {extendingType.Name}{extendingTypeGenericParameters}"))
                                {
                                    foreach (var instanceMethod in instanceMethodsToBeGenerated)
                                    {
                                        var methodGenericsMapping = typeGenericsMapping.AddRange(instanceMethod.GenericsMapping);
                                        GenerateMethodSource(builder, context, extendingType, instanceMethod, enumerableType, enumeratorType, sourceType, methodGenericsMapping, false, bindingsAttribute);
                                    }
                                }
                            }
                            _ = builder.AppendLine();

                            // generate the extension methods in the outter type
                            foreach (var extensionMethod in extensionMethodsToBeGenerated)
                            {
                                var methodGenericsMapping = typeGenericsMapping.AddRange(extensionMethod.GenericsMapping);
                                GenerateMethodSource(builder, context, extendingType, extensionMethod, enumerableType, enumeratorType, sourceType, methodGenericsMapping, true, bindingsAttribute);
                            }
                        }
                    }

                    var source = builder.ToString().Replace("TResult, TResult", "TSource, TResult");
                    yield return (extendingType.ContainingType, extendingType, source);
                }
            }
        }

        void GenerateMethodSource(CodeBuilder builder, CompilationContext context, INamedTypeSymbol extendingType, MethodInfo methodToGenerate, ITypeSymbol? enumerableType, ITypeSymbol? enumeratorType, ITypeSymbol sourceType, ImmutableArray<GeneratorMappingAttribute> genericsMapping, bool isExtensionMethod, GeneratorBindingsAttribute? bindingsAttribute)
        {
            var extendingTypeTypeArguments = extendingType.MappedTypeArguments(genericsMapping)
                .ToArray();
            var typeParameters = isExtensionMethod
                ? methodToGenerate.TypeParameters
                    .Where(typeParameter =>
                        !typeParameter.IsConcreteType
                        && typeParameter.Name is not "TEnumerable" and not "TEnumerator" and not "TList")
                    .ToArray()
                : methodToGenerate.TypeParameters
                    .Where(typeParameter =>
                        !typeParameter.IsConcreteType
                        && typeParameter.Name is not "TEnumerable" and not "TEnumerator" and not "TList"
                        && !extendingTypeTypeArguments.Any(argument => argument.Name == typeParameter.Name))
                    .ToArray();

            var methodReturnType = methodToGenerate.ReturnType.ToDisplayString();
            var genericsIndex = methodReturnType.IndexOf('<');
            if (genericsIndex >= 0)
            {
                methodReturnType = methodReturnType.Substring(0, genericsIndex);
                if (methodToGenerate.ReturnType is INamedTypeSymbol namedMethodReturnType)
                {
                    if (bindingsAttribute is null)
                        methodReturnType += MapTypeProperties(namedMethodReturnType.TypeArguments.Select(argument => argument.ToDisplayString()), enumerableType!, enumeratorType!, sourceType, genericsMapping);
                    else
                        methodReturnType += MapTypeProperties(namedMethodReturnType.TypeArguments.Select(argument => argument.ToDisplayString()), bindingsAttribute);
                }
            }
            if (methodReturnType is "TEnumerable")
                methodReturnType = extendingType.ToDisplayString();

            var methodName = methodToGenerate.Name;
            var methodExtensionType = extendingType.ToDisplayString();
            var methodParameters = methodToGenerate.Parameters
                .Select(parameter => parameter.DefaultValue is null
                    ? $"{parameter.Type} {parameter.Name}"
                    : $"{parameter.Type} {parameter.Name} = {parameter.DefaultValue}")
                .ToCommaSeparated();
            var methodGenericParameters = typeParameters
                .Select(typeParameter => typeParameter.Name)
                .ToCommaSeparated();
            var methodGenericParametersString = methodGenericParameters.Any()
                ? $"<{methodGenericParameters}>"
                : string.Empty;

            var returnKeyword = string.Empty;
            var callContainingType = methodToGenerate.ContainingType;
            var callTypeParameters = bindingsAttribute is null
                ? MapTypeProperties(methodToGenerate.TypeParameters.Select(parameter => parameter.Name), enumerableType!, enumeratorType!, sourceType, genericsMapping)
                : MapTypeProperties(methodToGenerate.TypeParameters.Select(parameter => parameter.Name), bindingsAttribute);
            var callParameters = methodToGenerate.Parameters.Select(parameter => parameter.Name).ToCommaSeparated();

            // generate the source
            _ = builder
                .AppendLine(context.GeneratedCodeAttribute)
                .AppendLine("[DebuggerNonUserCode]")
                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]");

            var firstCallParameter = bindingsAttribute?.Source ?? "this";

            if (isExtensionMethod)
            {
                _ = builder.AppendLine($"public static {methodReturnType} {methodName}{methodGenericParametersString}(this {methodExtensionType} source{methodParameters})");

                firstCallParameter = bindingsAttribute is null 
                    ? "source"
                    : $"source.{bindingsAttribute.Source}";
            }
            else
            {
                var methodReadonly = extendingType.IsValueType ? "readonly" : string.Empty;
                _ = builder.AppendLine($"public {methodReadonly} {methodReturnType} {methodName}{methodGenericParametersString}({methodParameters})");
            }
            foreach (var (name, constraints, _) in typeParameters.Where(typeParameter => typeParameter.Constraints.Any()))
                _ = builder.AppendLine($"where {name} : {constraints}");

            callParameters = StringExtensions.CommaSeparateIfNotNullOrEmpty(firstCallParameter, callParameters, bindingsAttribute?.ExtraParameters); 

            _ = builder
                .AppendLine($"=> {callContainingType}.{methodName}{callTypeParameters}({callParameters});")
                .AppendLine();
        }

        string MapTypeProperties(IEnumerable<string> typePropertyNames, ITypeSymbol enumerableType, ITypeSymbol enumeratorType, ITypeSymbol sourceType, ImmutableArray<GeneratorMappingAttribute> genericsMapping)
        {
            var str = typePropertyNames.Select(typePropertyName => typePropertyName switch
            {
                "TEnumerable" or "TList" => enumerableType.ToDisplayString(genericsMapping),
                "TEnumerator" => enumeratorType.ToDisplayString(genericsMapping),
                "TSource" => sourceType.ToDisplayString(genericsMapping),
                _ => typePropertyName.ApplyMappings(genericsMapping, out _),
            })
            .ToCommaSeparated();

            return string.IsNullOrEmpty(str) ? string.Empty : $"<{str}>";
        }

        string MapTypeProperties(IEnumerable<string> typePropertyNames, GeneratorBindingsAttribute? bindingsAttribute)
        {
            var str = typePropertyNames.Select(typePropertyName => typePropertyName switch
                {
                    "TEnumerable" or "TList" => bindingsAttribute?.EnumerableType ?? typePropertyName,
                    "TEnumerator" => bindingsAttribute?.EnumeratorType ?? typePropertyName,
                    "TSource" => bindingsAttribute?.ElementType ?? typePropertyName,
                    _ => typePropertyName,
                })
                .ToCommaSeparated();

            str = StringExtensions.CommaSeparateIfNotNullOrEmpty(str, bindingsAttribute?.ExtraTypeParameters);

            return string.IsNullOrEmpty(str) ? string.Empty : $"<{str}>";
        }
    }
}
