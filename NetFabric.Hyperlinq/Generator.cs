using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using NetFabric.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    [Generator]
    public partial class Generator
        : ISourceGenerator
    {
        static readonly string assemblyName = typeof(CodeBuilder).Assembly.GetName().Name;
        static readonly string assemblyVersion = typeof(CodeBuilder).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? string.Empty;

        static readonly DiagnosticDescriptor unhandledExceptionError = new(
            id: "HPLG001",
            title: "Unhandled exception while generating overloads",
            messageFormat: "Unhandled exception while generating overloads: {0}",
            category: "OverloadsGenerator",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        internal static readonly ImmutableHashSet<string> methods = ImmutableHashSet.Create(new[]
        {
            // aggregation
            "Count",
            "CountAsync",
            "Sum",
            "SumVector",
            "SumAsync",

            // conversion
            "AsEnumerable",
            "AsAsyncEnumerable",
            "AsValueEnumerable",
            "AsAsyncValueEnumerable",
            "ToArray",
            "ToArrayVector",
            "ToArrayAsync",
            "ToDictionary",
            "ToDictionaryAsync",
            "ToList",
            "ToListVector",
            "ToListAsync",

            // element
            "ElementAt",
            "ElementAtAsync",
            "First",
            "FirstAsync",
            "Single",
            "SingleAsync",

            // filtering
            "Where",
            "WhereAsync",

            // partitioning
            "Skip",
            "SkipAsync",
            "Take",
            "TakeAsync",

            // projection
            "Select",
            "SelectVector",
            "SelectAsync",
            "SelectMany",
            "SelectManyAsync",

            // quantifier
            "All",
            "AllAsync",
            "Any",
            "AnyAsync",
            "Contains",
            "ContainsVector",
            "ContainsAsync",

            // quantifier
            "Distinct",
            "DistinctAsync",
        });

        static readonly ImmutableHashSet<string> sumTypes = ImmutableHashSet.Create(new[]
        {
            "int",
            "int?",
            "nint",
            "nint?",
            "nuint",
            "nuint?",
            "long",
            "long?",
            "float",
            "float?",
            "double",
            "double?",
            "decimal",
            "decimal?",
        });

        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
                _ = Debugger.Launch();
#endif

            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver(methods));
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var typeSymbolsCache = new TypeSymbolsCache(context.Compilation);

            // Check if NetFabric.Hyperlinq.Abstractions and NetFabric.Hyperlinq.Abstractions are referenced
            if (typeSymbolsCache[typeof(IValueEnumerable<,>)] is null 
                || typeSymbolsCache[typeof(ValueEnumerableExtensions)] is null)
                return; // TODO: return a Diagnostic?

            if (context.SyntaxReceiver is not SyntaxReceiver receiver)
                return;

            try
            {
                var builder = new CodeBuilder();
                GenerateSource(context.Compilation, typeSymbolsCache, receiver.MemberAccessExpressions, builder, context.CancellationToken);
                context.AddSource("ExtensionMethods.g.cs", SourceText.From(builder.ToString(), Encoding.UTF8));
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                context.ReportDiagnostic(Diagnostic.Create(unhandledExceptionError, Location.None, ex.Message));
            }
        }

        internal static void GenerateSource(Compilation compilation, TypeSymbolsCache typeSymbolsCache, List<MemberAccessExpressionSyntax> memberAccessExpressions, CodeBuilder builder, CancellationToken cancellationToken)
        {
            var generatedMethods = new Dictionary<MethodSignature, ValueEnumerableType>();

            _ = builder
                .Line("#nullable enable")
                .Line()
                .Line("using System;")
                .Line("using System.CodeDom.Compiler;")
                .Line("using System.Collections;")
                .Line("using System.Collections.Generic;")
                .Line("using System.ComponentModel;")
                .Line("using System.Diagnostics;")
                .Line("using System.Diagnostics.CodeAnalysis;")
                .Line("using System.Runtime.CompilerServices;")
                .Line()
                .Line("namespace NetFabric.Hyperlinq;")
                .Line();

            using (builder.Block("static partial class GeneratedExtensionMethods"))
            {
                foreach (var expressionSyntax in memberAccessExpressions)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var semanticModel = compilation.GetSemanticModel(expressionSyntax.SyntaxTree);

                    _ = GenerateSource(compilation, semanticModel, typeSymbolsCache, expressionSyntax, builder, generatedMethods, cancellationToken);
                }
            }
        }

        static ValueEnumerableType? AsValueEnumerable(MemberAccessExpressionSyntax memberAccessExpressionSyntax, Compilation compilation, SemanticModel semanticModel, TypeSymbolsCache typeSymbolsCache, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, Dictionary<MethodSignature, ValueEnumerableType> generatedMethods, CancellationToken cancellationToken)
        {
            var typeSymbol = semanticModel.GetTypeInfo(memberAccessExpressionSyntax.Expression, cancellationToken).Type;
            if (typeSymbol is null)
                return null;

            // Check if the receiver type implements IValueEnumerable<,>
            var valueEnumerableType = typeSymbol.ToValueEnumerableType(typeSymbolsCache);
            if (valueEnumerableType is not null)
                return valueEnumerableType;

            // Go up one layer. Generate method if required.
            if (expressionSyntax.Expression is InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax receiverSyntax })
            {
                valueEnumerableType = GenerateSource(compilation, semanticModel, typeSymbolsCache, receiverSyntax, builder, generatedMethods, cancellationToken);
                if (valueEnumerableType is not null)
                    return valueEnumerableType;
            }

            // Receiver type does not implement IValueEnumerable<,> so nothing else needs to be done
            return null;
        }

        static ValueEnumerableType? GenerateSource(Compilation compilation, SemanticModel semanticModel, TypeSymbolsCache typeSymbolsCache, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, Dictionary<MethodSignature, ValueEnumerableType> generatedMethods, CancellationToken cancellationToken) 
            => expressionSyntax.Name.ToString() switch
                {
                    "AsValueEnumerable" => GenerateSourceAsValueEnumerable(compilation, semanticModel, typeSymbolsCache, expressionSyntax, builder, generatedMethods, cancellationToken),
                    _ => GenerateSourceDefault(compilation, semanticModel, typeSymbolsCache, expressionSyntax, builder, generatedMethods, cancellationToken),
                };

        static ValueEnumerableType? GenerateSourceDefault(Compilation compilation, SemanticModel semanticModel, TypeSymbolsCache typeSymbolsCache, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, Dictionary<MethodSignature, ValueEnumerableType> generatedMethods, CancellationToken cancellationToken)
        {
            // Find the receiver type
            var receiverType = AsValueEnumerable(expressionSyntax, compilation, semanticModel, typeSymbolsCache, expressionSyntax, builder, generatedMethods, cancellationToken);
            if (receiverType is null)
                return null;

            var methodName = expressionSyntax.Name.ToString();
            if (methodName == "Sum" && !sumTypes.Contains(receiverType.ItemType))
                return null;

            var containingClass = receiverType.IsList
                ? typeSymbolsCache[typeof(ValueReadOnlyListExtensions)]!
                : receiverType.IsCollection
                    ? typeSymbolsCache[typeof(ValueReadOnlyCollectionExtensions)]!
                    : typeSymbolsCache[typeof(ValueEnumerableExtensions)]!;
            var containingClassString = containingClass.ToDisplayString();

            // Check if the method is already defined
            var symbol = semanticModel.GetSymbolInfo(expressionSyntax, cancellationToken).Symbol;
            if (symbol is IMethodSymbol methodSymbol)
            { 
                // If it's an instance method of a type that implements IValueEnumerable<,> then it's already optimized.
                if (methodSymbol.ReceiverType is not null && methodSymbol.ReceiverType.ImplementsInterface(typeSymbolsCache[typeof(IValueEnumerable<,>)]!, out _))
                    return methodSymbol.ReturnType.ToValueEnumerableType(typeSymbolsCache); // return the returned type

                // Check if the generator already generated the extension method
                var parameters = methodSymbol.Parameters.Select(parameter => parameter.Type.ToDisplayString())
                    .ToArray();
                var methodSignature =
                    new MethodSignature(expressionSyntax.Name.ToString(), receiverType.Name, parameters);
                if (generatedMethods.TryGetValue(methodSignature, out var returnType))
                    return returnType;

                // Generate the extension method
                var comparer = new TypeSymbolConversionComparer(compilation);
                var parametersTypes = methodSymbol.Parameters.Select(parameter => parameter.Type).ToArray();
                var hyperlinqMethods = containingClass
                    .GetMembers()
                    .OfType<IMethodSymbol>()
                    .Where(method => 
                        method.IsPublic() 
                        && method.Name == methodName
                        && method.Parameters.Skip(1).Select(parameter => parameter.Type).SequenceEqual(parametersTypes, comparer))
                    .ToArray();
                var hyperlinqMethod = hyperlinqMethods.FirstOrDefault();
                if (hyperlinqMethod is null)
                    return null;

                var parametersString = string.Join(", ",
                    new[] { $"{receiverType.Name} source" }
                        .Concat(methodSymbol.Parameters.Select(static parameter => $"{parameter.Type.ToDisplayString()} {parameter.Name}")));
                var argumentsString = string.Join(", ",
                    new[] { "source" }
                        .Concat(methodSymbol.Parameters.Select(parameter => MapArgument(parameter, typeSymbolsCache))));
                var typeArgumentsString = string.Join(", ",
                    new[] { receiverType.Name, receiverType.EnumeratorType }
                        .Concat(methodSymbol.TypeArguments.Select(argument => MapTypeArgument(argument, typeSymbolsCache))));
                var returnTypeString = hyperlinqMethod.ReturnType is INamedTypeSymbol { IsGenericType: true }
                    ? $"{hyperlinqMethod.ReturnType.ContainingType}.{hyperlinqMethod.ReturnType.Name}<{typeArgumentsString}>"
                    : hyperlinqMethod.ReturnType.ToDisplayString();
                _ = builder
                    .Line()
                    .GeneratedCodeMethodAttributes()
                    .Line("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .Line($"public static {returnTypeString} {methodSymbol.Name}(this {parametersString})")
                    .Indent()
                    .Line($"=> {containingClassString}.{methodSymbol.Name}<{typeArgumentsString}>({argumentsString});");
            }

            // The method is not yet defined
            if (expressionSyntax.Parent is InvocationExpressionSyntax invocation)
            {
                var a = invocation.ArgumentList.Arguments
                    .Select(argument => semanticModel.GetTypeInfo(argument.Expression).Type)
                    .ToArray();
                // Check if the generator already generated the extension method
                //var parameters = new string[] { receiverType.Name }.Concat(invocation.ArgumentList.Arguments.Select(argument => argument.ToDisplayString())).ToArray();
                //var methodSignature = new MethodSignature(expressionSyntax.Name.ToString(), parameters);
                //if (generatedMethods.TryGetValue(methodSignature, out var returnType))
                //    return returnType;

                //// Generate the extension method
                //var hyperlinqMethod = hyperlinqMethods.FirstOrDefault();

                //var parametersString = string.Join(", ",
                //    new string[] { $"{receiverType.Name} source" }
                //    .Concat(methodSymbol.Parameters.Select(parameter => $"{parameter.Type.ToDisplayString()} {parameter.Name}")));
                //var argumentsString = string.Join(", ",
                //    new string[] { "source" }
                //    .Concat(methodSymbol.Parameters.Select(parameter => parameter.Name)));
                //_ = builder
                //    .Line()
                //    .Line("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                //    .Line($"public static {hyperlinqMethod.ReturnType.ToDisplayString()} {methodSymbol.Name}(this {parametersString})")
                //    .Indent().Line($"=> {containingClassString}.{methodSymbol.Name}<{receiverType.Name}, {receiverType.EnumeratorType}, {receiverType.ItemType}>({argumentsString});");

                //generatedMethods.Add(methodSignature, returnType);
                //return returnType;
            }

            return null;

            static string MapArgument(IParameterSymbol parameter, TypeSymbolsCache typeSymbolsCache)
            {
                if (parameter.Type is INamedTypeSymbol { IsGenericType: true } namedTypeSymbol)
                {
                    // Convert Func<> to FunctionWrapper<>
                    if (SymbolEqualityComparer.Default.Equals(parameter.Type.OriginalDefinition, typeSymbolsCache[typeof(Func<,>)]))
                    {
                        var typeArguments = string.Join(", ",
                            namedTypeSymbol.TypeArguments.Select(argument => argument.ToDisplayString()));
                        return $"new NetFabric.Hyperlinq.FunctionWrapper<{typeArguments}>({parameter.Name})";
                    }
                }
                
                return parameter.Name;
            }
            
            static string MapTypeArgument(ITypeSymbol argument, TypeSymbolsCache typeSymbolsCache)
            {
                if (argument is INamedTypeSymbol { IsGenericType: true } namedTypeSymbol)
                {
                    // Convert Func<> to FunctionWrapper<>
                    if (SymbolEqualityComparer.Default.Equals(argument.OriginalDefinition, typeSymbolsCache[typeof(Func<,>)]))
                    {
                        var typeArguments = string.Join(", ",
                            namedTypeSymbol.TypeArguments.Select(argument => argument.ToDisplayString()));
                        return $"NetFabric.Hyperlinq.FunctionWrapper<{typeArguments}>";
                    }
                }
                
                return argument.ToDisplayString();
            }
        }
    }
}