using System;
using Xunit;
using TestHelper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NetFabric.Hyperlinq.Analyzer.UnitTests
{
    public class NullEnumerableAnalyzerTests : DiagnosticVerifier
    {
        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() =>
            new NullEnumerableAnalyzer();

        [Fact]
        public void Verify()
        {
            var test = @"
using System.Collections.Generic;

class C
{
    IEnumerable<int> Method01()
    {
        return null;
    }

    IEnumerable<int> Method02() => null;

    IEnumerable<int> Method03() => new List<int>();

    IEnumerable<int> Method04()
    {
        return null;
        yield return 0;
    }
}";

            var method01 = new DiagnosticResult
            {
                Id = "HLQ002",
                Message = "Enumerable cannot be null.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 8, 9)
                },
            };

            var method02 = new DiagnosticResult
            {
                Id = "HLQ002",
                Message = "Enumerable cannot be null.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 33)
                },
            };

            var method04 = new DiagnosticResult
            {
                Id = "HLQ002",
                Message = "Enumerable cannot be null.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 17, 9)
                },
            };

            VerifyCSharpDiagnostic(test, method01, method02, method04);
        }

    }
}