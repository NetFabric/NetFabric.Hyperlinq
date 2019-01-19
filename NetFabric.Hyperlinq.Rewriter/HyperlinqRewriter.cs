using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;

namespace NetFabric.Hyperlinq.Rewriter
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class HyperlinqRewriter : CompilationRewriter
    {
        public override Compilation Rewrite(CompilationRewriterContext context)
        {
            var compilation = context.Compilation;

            // Transform compilation

            return compilation;
        }
    }
}
