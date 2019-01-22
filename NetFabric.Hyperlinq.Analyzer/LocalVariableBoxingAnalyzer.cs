using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NetFabric.Hyperlinq.Analyzer
{
    /// <summary>
    /// An analyzer that warns when and enumerable with a value type enumerator is assigned to an interface.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class LocalVariableBoxingAnalyzer : DiagnosticAnalyzer
    {
        const string DiagnosticId = DiagnosticIds.LocalVariableBoxingId;

        static readonly string Title = "Assigment to interface causes boxing of enumerator";
        static readonly string MessageFormat = "Assigment to interface causes boxing of enumerator for '{0}'";
        static readonly string Description = "This collection has a value type enumerator. Assigning it to an interface cause it to be boxed and method calls to be virtual, affecting peformance.";
        const string Category = "Performance";
     
        static DiagnosticDescriptor Rule = 
            new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics 
        { 
            get => ImmutableArray.Create(Rule); 
        }

        public override void Initialize(AnalysisContext context)
        {
            // context.RegisterSyntaxNodeAction(AnalyzeSimpleAssignment, SyntaxKind.SimpleAssignmentExpression);
        }

        static void AnalyzeSimpleAssignment(SyntaxNodeAnalysisContext context)
        {
        }
    }
}