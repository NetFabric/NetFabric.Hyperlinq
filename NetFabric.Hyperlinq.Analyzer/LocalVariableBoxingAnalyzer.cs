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
    public sealed class LocalVariableBoxingAnalyzer : DiagnosticAnalyzer
    {
        const string DiagnosticId = DiagnosticIds.LocalVariableBoxingId;

        static readonly LocalizableString Title = 
            new LocalizableResourceString(nameof(Resources.LocalVariableBoxing_Title), Resources.ResourceManager, typeof(Resources));
        static readonly LocalizableString MessageFormat = 
            new LocalizableResourceString(nameof(Resources.LocalVariableBoxing_MessageFormat), Resources.ResourceManager, typeof(Resources));
        static readonly LocalizableString Description = 
            new LocalizableResourceString(nameof(Resources.LocalVariableBoxing_Description), Resources.ResourceManager, typeof(Resources));
        const string Category = "Performance";

        static readonly DiagnosticDescriptor rule = 
            new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => 
            ImmutableArray.Create(rule); 

        public override void Initialize(AnalysisContext context)
        {
            //context.RegisterSyntaxNodeAction(AnalyzeFieldDeclaration, SyntaxKind.FieldDeclaration);
            context.RegisterSyntaxNodeAction(AnalyzeSimpleAssignment, SyntaxKind.SimpleAssignmentExpression);
        } 

        static void AnalyzeSimpleAssignment(SyntaxNodeAnalysisContext context)
        {
            if(!(context.Node is AssignmentExpressionSyntax assignmentExpression))
                return;

            var semanticModel = context.SemanticModel;

            var leftTypeInfo = semanticModel.GetTypeInfo(assignmentExpression.Left);
            if (leftTypeInfo.Type.TypeKind != TypeKind.Interface)
                return;

            var rightTypeInfo = semanticModel.GetTypeInfo(assignmentExpression.Right).Type as INamedTypeSymbol;
            var methods = rightTypeInfo.GetMembers().OfType<IMethodSymbol>();
            var publicGetEnumeratorMethod = methods
                .FirstOrDefault(method =>
                    method.DeclaredAccessibility == Accessibility.Public &&
                    method.Name == "GetEnumerator");
            if (publicGetEnumeratorMethod is null)
                return;

            var returnType = publicGetEnumeratorMethod.ReturnType;
            if (returnType.IsReferenceType)
                return;

            var diagnostic = Diagnostic.Create(rule, assignmentExpression.GetLocation(), rightTypeInfo.Name);
            context.ReportDiagnostic(diagnostic);
        }
    }
}