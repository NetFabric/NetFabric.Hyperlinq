using System;
using Xunit;
using TestHelper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NetFabric.Hyperlinq.Analyzer.UnitTests
{
    public class AssignmentBoxingTests : CodeFixVerifier
    {
        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() =>
            new AssignmentBoxingAnalyzer();

        [Fact]
        public void FieldInitialization()
        {
            var test = @"
using NetFabric.Hyperlinq.Analyzer.UnitTests;
using System.Collections.Generic;
using System.Linq;

class C
{
    List<int> field00 = new List<int>();
    IList<int> field01 = new List<int>(); // boxes enumerator
    IEnumerable<int> field02 = Enumerable.Range(0, 10); 
    MyEnumerable.MyRangeEnumerable field03 = MyEnumerable.Range(0, 10);
    IMyEnumerable<int> field04 = MyEnumerable.Range(0, 10); // boxes enumerator

    public List<int> field10 = new List<int>();
    public IList<int> field11 = new List<int>(); // boxes enumerator but public
    public IEnumerable<int> field12 = Enumerable.Range(0, 10);
    public MyEnumerable.MyRangeEnumerable field13 = MyEnumerable.Range(0, 10);
    public IMyEnumerable<int> field14 = MyEnumerable.Range(0, 10); // boxes enumerator but public
}
            ";

            var field01 = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 9, 5)
                },
            };

            var field04 = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'Range' has a value type enumerator. Assigning it to 'IMyEnumerable' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 0, 0)
                },
            };

            VerifyCSharpDiagnostic(test, field01, field04);
        }
    }
}