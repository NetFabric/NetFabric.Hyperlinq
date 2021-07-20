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
using System.Text;
using System.Threading;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    [Generator]
    public partial class Generator
        : ISourceGenerator
    {
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
            if (typeSymbolsCache["NetFabric.Hyperlinq.IValueEnumerable`2"] is null 
                || typeSymbolsCache["NetFabric.Hyperlinq.ValueEnumerableExtensions"] is null)
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

        internal static void GenerateSource(Compilation compilation, TypeSymbolsCache typeSymbolsCache, List<MemberAccessExpressionSyntax> memberAccessExpressions, CodeBuilder builder, CancellationToken cancellationToken, bool isUnitTest = false)
        {
            var generatedMethods = new HashSet<MethodSignature>();

            _ = builder
                .AppendLine("#nullable enable")
                .AppendLine()
                .AppendLine("using System;")
                .AppendLine("using System.Collections;")
                .AppendLine("using System.Collections.Generic;")
                .AppendLine("using System.Runtime.CompilerServices;")
                .AppendLine();

            using (builder.AppendBlock("namespace NetFabric.Hyperlinq"))
            using (builder.AppendBlock("static partial class GeneratedExtensionMethods"))
            {
                foreach (var expressionSyntax in memberAccessExpressions)
                {
                    var semanticModel = compilation.GetSemanticModel(expressionSyntax.SyntaxTree);

                    _ = GenerateSource(compilation, semanticModel, typeSymbolsCache, expressionSyntax, builder, generatedMethods, cancellationToken, isUnitTest);
                }
            }
        }

        static ValueEnumerableType? GenerateSource(Compilation compilation, SemanticModel semanticModel, TypeSymbolsCache typeSymbolsCache, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, HashSet<MethodSignature> generatedMethods, CancellationToken cancellationToken, bool isUnitTest)
            => expressionSyntax.Name.ToString() switch
            {
                "AsValueEnumerable" => GenerateAsValueEnumerable(compilation, semanticModel, typeSymbolsCache, expressionSyntax, builder, generatedMethods, cancellationToken, isUnitTest),
                _ => GenerateOperationSource(compilation, semanticModel, expressionSyntax, builder, generatedMethods, cancellationToken, isUnitTest),
            };

        static ValueEnumerableType? GenerateOperationSource(Compilation compilation, SemanticModel semanticModel, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, HashSet<MethodSignature> generatedMethods, CancellationToken cancellationToken, bool isUnitTest)
        {
            // Get the type this operator is applied to
            var receiverTypeSymbol = semanticModel.GetTypeInfo(expressionSyntax.Expression, cancellationToken).Type;

            return null;
        }

        static bool IsValueEnumerable(ITypeSymbol symbol, TypeSymbolsCache typeSymbolsCache)
            => symbol.ImplementsInterface(typeSymbolsCache["NetFabric.Hyperlinq.IValueEnumerable`2"]!, out var _);
    }
}