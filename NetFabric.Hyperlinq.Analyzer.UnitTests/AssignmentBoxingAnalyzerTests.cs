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
        public void VerifyFieldInitialization()
        {
            var test = @"
using System.Collections.Generic;

class C
{
    List<int> field00 = new List<int>();
    IList<int> field01 = new List<int>(); // boxes enumerator
    List<int> field03 = GetList();
    IList<int> field04 = GetList(); // boxes enumerator

    public List<int> field10 = new List<int>();
    public IList<int> field11 = new List<int>(); // boxes enumerator but public
    public List<int> field13 = GetList();
    public IList<int> field14 = GetList(); // boxes enumerator but public

    public C()
    {
        field00 = new List<int>();
        field01 = new List<int>(); // boxes enumerator
        field03 = GetList();
        field04 = GetList(); // boxes enumerator

        field10 = new List<int>();
        field11 = new List<int>(); // boxes enumerator but public
        field13 = GetList();
        field14 = GetList(); // boxes enumerator but public
    }

    static List<int> GetList() => new List<int>();
}";

            var field01 = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 7, 5)
                },
            };

            var field04 = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 9, 5)
                },
            };

            var field01InConstructor = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 19, 9)
                },
            };

            var field04InConstructor = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 21, 9)
                },
            };

            VerifyCSharpDiagnostic(test, field01, field04, field01InConstructor, field04InConstructor);
        }

        [Fact]
        public void VerifyPropertyInitialization()
        {
            var test = @"
using System.Collections.Generic;

class C
{
    List<int> Property00 { get; } = new List<int>();
    IList<int> Property01 { get; } = new List<int>(); // boxes enumerator
    List<int> Property03 { get; } = GetList();
    IList<int> Property04 { get; } = GetList(); // boxes enumerator

    public List<int> Property10 { get; } = new List<int>();
    public IList<int> Property11 { get; } = new List<int>(); // boxes enumerator but public
    public List<int> Property13 { get; } = GetList();
    public IList<int> Property14 { get; } = GetList(); // boxes enumerator but public

    public C()
    {
        Property00 = new List<int>();
        Property01 = new List<int>(); // boxes enumerator
        Property03 = GetList();
        Property04 = GetList(); // boxes enumerator

        Property10 = new List<int>();
        Property11 = new List<int>(); // boxes enumerator but public
        Property13 = GetList();
        Property14 = GetList(); // boxes enumerator but public
    }

    static List<int> GetList() => new List<int>();
}";

            var property01 = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 7, 5)
                },
            };

            var property04 = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 9, 5)
                },
            };

            var property01InConstructor = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 19, 9)
                },
            };

            var property04InConstructor = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 21, 9)
                },
            };

            VerifyCSharpDiagnostic(test, property01, property04, property01InConstructor, property04InConstructor);
        }

        [Fact]
        public void VerifyLocalVariableInitialization()
        {
            var test = @"
using System.Collections.Generic;

class C
{
    public Method()
    {
        List<int> variable00 = new List<int>();
        IList<int> variable01 = new List<int>(); // boxes enumerator
        List<int> variable03 = GetList();
        IList<int> variable04 = GetList(); // boxes enumerator

        var variable10 = new List<int>();
        var variable11 = new List<int>(); 
        var variable13 = GetList();
        var variable14 = GetList(); 

        variable00 = new List<int>();
        variable01 = new List<int>(); // boxes enumerator
        variable03 = GetList();
        variable04 = GetList(); // boxes enumerator

        variable10 = new List<int>();
        variable11 = new List<int>(); 
        variable13 = GetList();
        variable14 = GetList(); 
    }

    static List<int> GetList() => new List<int>();
}";

            var variable01 = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 9, 9)
                },
            };

            var variable04 = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 9)
                },
            };

            var variable01Assignment = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 19, 9)
                },
            };

            var variable04Assignment = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'List' has a value type enumerator. Assigning it to 'IList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 21, 9)
                },
            };

            VerifyCSharpDiagnostic(test, variable01, variable04, variable01Assignment, variable04Assignment);
        }

    }
}