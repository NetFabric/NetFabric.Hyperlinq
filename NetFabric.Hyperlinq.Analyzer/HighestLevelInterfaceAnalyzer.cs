using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NetFabric.Hyperlinq.Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class HighestLevelInterfaceAnalyzer : DiagnosticAnalyzer
    {
        const string DiagnosticId = DiagnosticIds.HighestLevelInterfaceId;

        static readonly LocalizableString Title =
            new LocalizableResourceString(nameof(Resources.HighestLevelInterface_Title), Resources.ResourceManager, typeof(Resources));
        static readonly LocalizableString MessageFormat =
            new LocalizableResourceString(nameof(Resources.HighestLevelInterface_MessageFormat), Resources.ResourceManager, typeof(Resources));
        static readonly LocalizableString Description =
            new LocalizableResourceString(nameof(Resources.HighestLevelInterface_Description), Resources.ResourceManager, typeof(Resources));
        const string Category = "Performance";

        static readonly DiagnosticDescriptor rule =
            new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning,
                isEnabledByDefault: true, description: Description,
                helpLinkUri: "https://github.com/NetFabric/NetFabric.Hyperlinq/tree/master/NetFabric.Hyperlinq.Analyzer/docs/reference/HLQ003_HighestLevelInterface.md");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeMethodDeclaration, SyntaxKind.MethodDeclaration);
        }

        static void AnalyzeMethodDeclaration(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is MethodDeclarationSyntax methodDeclarationSyntax))
                return;

            var semanticModel = context.SemanticModel;

            var methodSymbol = semanticModel.GetDeclaredSymbol(methodDeclarationSyntax);
            if (methodSymbol.ReturnsVoid || methodSymbol.DeclaredAccessibility != Accessibility.Public)
                return;

            var returnType = methodSymbol.ReturnType.OriginalDefinition.SpecialType;

            var arrowExpressionClauseSyntax = methodDeclarationSyntax.DescendantNodes()
                .OfType<ArrowExpressionClauseSyntax>().FirstOrDefault();
            if (arrowExpressionClauseSyntax is null)
            {
                switch (returnType)
                {
                    case SpecialType.System_Collections_IEnumerable:
                        AnalyzeIEnumerableMethod(context, methodDeclarationSyntax);
                        break;
                    case SpecialType.System_Collections_Generic_IEnumerable_T:
                        AnalyzeIEnumerableTMethod(context, methodDeclarationSyntax);
                        break;
                    case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:
                        AnalyzeIReadOnlyCollectionMethod(context, methodDeclarationSyntax);
                        break;
                }
            }
            else
            {
                AnalyzeArrowExpressionClause(context, methodDeclarationSyntax, arrowExpressionClauseSyntax, returnType);
            }
        }

        static void AnalyzeArrowExpressionClause(SyntaxNodeAnalysisContext context, MethodDeclarationSyntax methodDeclarationSyntax, ArrowExpressionClauseSyntax arrowExpressionClauseSyntax, SpecialType returnType)
        {
            var semanticModel = context.SemanticModel;
            var expressionType = semanticModel.GetTypeInfo(arrowExpressionClauseSyntax.Expression).Type;

            switch (returnType)
            {
                case SpecialType.System_Collections_IEnumerable:
                    if (expressionType.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyList_T))
                    {
                        var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyList<T>");
                        context.ReportDiagnostic(diagnostic);
                    }
                    else if (expressionType.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyCollection_T))
                    {
                        var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyCollection<T>");
                        context.ReportDiagnostic(diagnostic);
                    }
                    else if(expressionType.ImplementsInterface(SpecialType.System_Collections_Generic_IEnumerable_T))
                    {
                        var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IEnumerable<T>");
                        context.ReportDiagnostic(diagnostic);
                    }
                    break;
                case SpecialType.System_Collections_Generic_IEnumerable_T:
                    if (expressionType.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyList_T))
                    {
                        var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyList<T>");
                        context.ReportDiagnostic(diagnostic);
                    }
                    else if (expressionType.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyCollection_T))
                    {
                        var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyCollection<T>");
                        context.ReportDiagnostic(diagnostic);
                    }
                    break;
                case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:
                    if (expressionType.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyList_T))
                    {
                        var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyList<T>");
                        context.ReportDiagnostic(diagnostic);
                    }
                    break;
            }
        }

        static void AnalyzeIEnumerableMethod(SyntaxNodeAnalysisContext context, MethodDeclarationSyntax methodDeclarationSyntax)
        {
            if (AllReturnsNull(context, methodDeclarationSyntax))
                return;

            if (AllReturnsImplement(context, methodDeclarationSyntax, SpecialType.System_Collections_Generic_IReadOnlyList_T))
            {
                var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyList<T>");
                context.ReportDiagnostic(diagnostic);
            }
            else if (AllReturnsImplement(context, methodDeclarationSyntax, SpecialType.System_Collections_Generic_IReadOnlyCollection_T))
            {
                var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyCollection<T>");
                context.ReportDiagnostic(diagnostic);
            }
            else if (AllReturnsImplement(context, methodDeclarationSyntax, SpecialType.System_Collections_Generic_IEnumerable_T))
            {
                var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IEnumerable<T>");
                context.ReportDiagnostic(diagnostic);
            }
        }

        static void AnalyzeIEnumerableTMethod(SyntaxNodeAnalysisContext context, MethodDeclarationSyntax methodDeclarationSyntax)
        {
            if (AllReturnsNull(context, methodDeclarationSyntax))
                return;

            if (AllReturnsImplement(context, methodDeclarationSyntax, SpecialType.System_Collections_Generic_IReadOnlyList_T))
            {
                var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyList<T>");
                context.ReportDiagnostic(diagnostic);
            }
            else if (AllReturnsImplement(context, methodDeclarationSyntax, SpecialType.System_Collections_Generic_IReadOnlyCollection_T))
            {
                var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyCollection<T>");
                context.ReportDiagnostic(diagnostic);
            }
        }

        static void AnalyzeIReadOnlyCollectionMethod(SyntaxNodeAnalysisContext context, MethodDeclarationSyntax methodDeclarationSyntax)
        {
            if (AllReturnsNull(context, methodDeclarationSyntax))
                return;

            if (AllReturnsImplement(context, methodDeclarationSyntax, SpecialType.System_Collections_Generic_IReadOnlyList_T))
            {
                var diagnostic = Diagnostic.Create(rule, methodDeclarationSyntax.ReturnType.GetLocation(), "IReadOnlyList<T>");
                context.ReportDiagnostic(diagnostic);
            }
        }

        static bool AllReturnsNull(SyntaxNodeAnalysisContext context, MethodDeclarationSyntax methodDeclarationSyntax)
        {
            var semanticModel = context.SemanticModel;
            foreach(var node in methodDeclarationSyntax.DescendantNodes().OfType<ReturnStatementSyntax>())
            {
                var returnType = semanticModel.GetTypeInfo(node.Expression).Type;
                if(!(returnType is null))
                    return false;
            }
            foreach(var node in methodDeclarationSyntax.DescendantNodes().OfType<ArrowExpressionClauseSyntax>())
            {
                var returnType = semanticModel.GetTypeInfo(node.Expression).Type;
                if(!(returnType is null))
                    return false;
            }
            return true;
        }

        static bool AllReturnsImplement(SyntaxNodeAnalysisContext context, MethodDeclarationSyntax methodDeclarationSyntax, SpecialType type)
        {
            var semanticModel = context.SemanticModel;
            foreach(var node in methodDeclarationSyntax.DescendantNodes().OfType<ReturnStatementSyntax>())
            {
                var returnType = semanticModel.GetTypeInfo(node.Expression).Type;
                if(!(returnType is null || returnType.ImplementsInterface(type)))
                    return false;
            }
            foreach(var node in methodDeclarationSyntax.DescendantNodes().OfType<ArrowExpressionClauseSyntax>())
            {
                var returnType = semanticModel.GetTypeInfo(node.Expression).Type;
                if(!(returnType is null || returnType.ImplementsInterface(type)))
                    return false;
            }
            return true;
        }
    }
}