using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using NetFabric.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
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

        internal static readonly ImmutableArray<string> methods = ImmutableArray.Create(new[]
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
            var typeSymbolCache = new TypeSymbolsCache(context.Compilation);

            // Check if NetFabric.Hyperlinq.Abstractions and NetFabric.Hyperlinq.Abstractions are referenced
            if (typeSymbolCache["NetFabric.Hyperlinq.IValueEnumerable`2"] is null 
                || typeSymbolCache["NetFabric.Hyperlinq.ValueEnumerableExtensions"] is null)
                return;

            if (context.SyntaxReceiver is not SyntaxReceiver receiver)
                return;

            try
            {
                var builder = new CodeBuilder();
                GenerateSource(context.Compilation, typeSymbolCache, receiver.MemberAccessExpressions, builder, context.CancellationToken);
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
                    cancellationToken.ThrowIfCancellationRequested();

                    _ = expressionSyntax.Name.ToString() switch
                    {
                        "AsValueEnumerable" => HandleAsValueEnumerable(compilation, typeSymbolsCache, expressionSyntax, builder, cancellationToken),
                        _ => HandleMethod(compilation, expressionSyntax, builder, cancellationToken),
                    };
                }
            }
        }

        static bool HandleMethod(Compilation compilation, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, CancellationToken cancellationToken)
        {
            var semanticModel = compilation.GetSemanticModel(expressionSyntax.SyntaxTree);
            if (semanticModel.GetSymbolInfo(expressionSyntax, cancellationToken).Symbol is not null) // method already exists
                return false;

            return false;
        }

        static bool IsValueEnumerable(ITypeSymbol symbol, TypeSymbolsCache typeSymbolsCache)
            => symbol.ImplementsInterface(typeSymbolsCache["NetFabric.Hyperlinq.IValueEnumerable`2"]!, out var _);
    }
}