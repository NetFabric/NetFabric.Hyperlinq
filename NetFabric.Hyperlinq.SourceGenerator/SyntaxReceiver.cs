using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    class SyntaxReceiver : ISyntaxReceiver
    {
        readonly ImmutableHashSet<string> memberAccessNames;

        public SyntaxReceiver(ImmutableHashSet<string> memberAccessNames) 
            => this.memberAccessNames = memberAccessNames;

        public List<MemberAccessExpressionSyntax> MemberAccessExpressions { get; } = new();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            switch (syntaxNode)
            {
                case MemberAccessExpressionSyntax { Name: var memberName } memberAccessExpression:
                    if (memberAccessExpression.Kind() == SyntaxKind.SimpleMemberAccessExpression
                        && memberAccessNames.Contains(memberName.Identifier.ValueText))
                    {
                        // It's a SimpleMemberAccessExpression and its name is in memberAccessNames collection
                        MemberAccessExpressions.Add(memberAccessExpression);
                    }
                    break;
            }
        }
    }
}
