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
    public sealed class NullEnumerableAnalyzer : DiagnosticAnalyzer
    {
        const string DiagnosticId = DiagnosticIds.NullReturnId;

        static readonly LocalizableString Title =
            new LocalizableResourceString(nameof(Resources.NullEnumerable_Title), Resources.ResourceManager, typeof(Resources));
        static readonly LocalizableString MessageFormat =
            new LocalizableResourceString(nameof(Resources.NullEnumerable_MessageFormat), Resources.ResourceManager, typeof(Resources));
        static readonly LocalizableString Description =
            new LocalizableResourceString(nameof(Resources.NullEnumerable_Description), Resources.ResourceManager, typeof(Resources));
        const string Category = "Performance";

        static readonly DiagnosticDescriptor rule =
            new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, 
                isEnabledByDefault: true, description: Description, 
                helpLinkUri: "https://github.com/NetFabric/NetFabric.Hyperlinq/tree/master/NetFabric.Hyperlinq.Analyzer/docs/reference/HLQ002_NullEnumerable.md");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeReturnStatement, SyntaxKind.ReturnStatement);
            context.RegisterSyntaxNodeAction(AnalyzeArrowExpressionClause, SyntaxKind.ArrowExpressionClause);
        }

        static void AnalyzeReturnStatement(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is ReturnStatementSyntax returnStatementSyntax))
                return;

            if (!(returnStatementSyntax.Expression is LiteralExpressionSyntax literalExpressionSyntax))
                return;

            if (!literalExpressionSyntax.IsKind(SyntaxKind.NullLiteralExpression))
                return;

            var semanticModel = context.SemanticModel;

            var methodDeclarationSyntax = returnStatementSyntax.Ancestors().OfType<MethodDeclarationSyntax>().First();
            var methodReturnTypeSymbol = semanticModel.GetTypeInfo(methodDeclarationSyntax.ReturnType).Type;
            if (methodReturnTypeSymbol is null || (!methodReturnTypeSymbol.IsEnumerableInterface() && !methodReturnTypeSymbol.IsEnumerable()))
                return;

            var diagnostic = Diagnostic.Create(rule, returnStatementSyntax.GetLocation());
            context.ReportDiagnostic(diagnostic);
        }

        static void AnalyzeArrowExpressionClause(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is ArrowExpressionClauseSyntax arrowExpressionClauseSyntax))
                return;

            if (!arrowExpressionClauseSyntax.Expression.IsKind(SyntaxKind.NullLiteralExpression))
                return;

            var semanticModel = context.SemanticModel;

            var methodDeclarationSyntax = arrowExpressionClauseSyntax.Ancestors().OfType<MethodDeclarationSyntax>().First();
            var methodReturnTypeSymbol = semanticModel.GetTypeInfo(methodDeclarationSyntax.ReturnType).Type;
            if (methodReturnTypeSymbol is null || (!methodReturnTypeSymbol.IsEnumerableInterface() && !methodReturnTypeSymbol.IsEnumerable()))
                return;

            var diagnostic = Diagnostic.Create(rule, arrowExpressionClauseSyntax.GetLocation());
            context.ReportDiagnostic(diagnostic);
        }
    }
}