using System;
using Xunit;
using TestHelper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NetFabric.Hyperlinq.Analyzer.UnitTests
{
    public class HighestLevelInterfaceAnalyzerTests : DiagnosticVerifier
    {
        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer() =>
            new HighestLevelInterfaceAnalyzer();

        [Fact]
        public void VerifyIReadOnlyCollection()
        {
            var test = @"
using System.Collections;
using System.Collections.Generic;

class ReadOnlyCollection<T> : IReadOnlyCollection<T>
{
    readonly List<T> collection = new List<T>();

    public int Count => collection.Count;

    public List<T>.Enumerator GetEnumerator() => collection.GetEnumerator();
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => collection.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => collection.GetEnumerator();

    public void Dispose() {}
}

class C
{
    void MethodVoid()
    {
        return;
    }

    IEnumerable<int> MethodNull()
    {
        return null;
    }

    IEnumerable<int> MethodNotPublic()
    {
        return new ReadOnlyCollection<int>();
    }

    public IEnumerable<int> Method01()
    {
        return new ReadOnlyCollection<int>();
    }

    public IReadOnlyCollection<int> Method02()
    {
        return new ReadOnlyCollection<int>();
    }

    public ReadOnlyCollection<int> Method03()
    {
        return new ReadOnlyCollection<int>();
    }

    public IEnumerable<int> Method04(int value)
    {
        switch(value)
        {
            case 0:
                return null;

            default:
                return new ReadOnlyCollection<int>();
        }
    }

    IEnumerable<int> Method10() => new ReadOnlyCollection<int>();

    public IEnumerable<int> Method11() => new ReadOnlyCollection<int>();

    public IReadOnlyCollection<int> Method12() => new ReadOnlyCollection<int>();

    public ReadOnlyCollection<int> Method13() => new ReadOnlyCollection<int>();
}";
            var method01 = new DiagnosticResult
            {
                Id = "HLQ003",
                Message = "Consider returning 'IReadOnlyCollection<T>' instead.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 35, 12)
                },
            };

            var method04 = new DiagnosticResult
            {
                Id = "HLQ003",
                Message = "Consider returning 'IReadOnlyCollection<T>' instead.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 50, 12)
                },
            };

            var method11 = new DiagnosticResult
            {
                Id = "HLQ003",
                Message = "Consider returning 'IReadOnlyCollection<T>' instead.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 64, 12)
                },
            };

            VerifyCSharpDiagnostic(test, method01, method04, method11);
        }

        [Fact]
        public void VerifyIReadOnlyList()
        {
            var test = @"
using System.Collections.Generic;

class C
{
    void MethodVoid()
    {
        return;
    }

    IEnumerable<int> MethodNull()
    {
        return null;
    }

    IEnumerable<int> MethodNotPublic()
    {
        return new List<int>();
    }

    public IEnumerable<int> Method01()
    {
        return new List<int>();
    }

    public IReadOnlyCollection<int> Method02()
    {
        return new List<int>();
    }

    public IReadOnlyList<int> Method03()
    {
        return new List<int>();
    }

    public List<int> Method04()
    {
        return new List<int>();
    }

    public IEnumerable<int> Method05(int value)
    {
        switch(value)
        {
            case 0:
                return null;

            case 1:
                return new ReadOnlyCollection<int>();

            default:
                return new List<int>();
        }
    }

    IEnumerable<int> Method10() => new List<int>();

    public IEnumerable<int> Method11() => new List<int>();

    public IReadOnlyCollection<int> Method12() => new List<int>();

    public IReadOnlyList<int> Method13() => new List<int>();

    public List<int> Method14() => new List<int>();

    IEnumerable<int> Method20()
    {
        yield break;
    }

    public IEnumerable<int> Method21()
    {
        yield break;
    }
}";
            var method01 = new DiagnosticResult
            {
                Id = "HLQ003",
                Message = "Consider returning 'IReadOnlyList<T>' instead.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 21, 12)
                },
            };

            var method02 = new DiagnosticResult
            {
                Id = "HLQ003",
                Message = "Consider returning 'IReadOnlyList<T>' instead.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 26, 12)
                },
            };

            var method11 = new DiagnosticResult
            {
                Id = "HLQ003",
                Message = "Consider returning 'IReadOnlyList<T>' instead.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 58, 12)
                },
            };

            var method12 = new DiagnosticResult
            {
                Id = "HLQ003",
                Message = "Consider returning 'IReadOnlyList<T>' instead.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 60, 12)
                },
            };

            VerifyCSharpDiagnostic(test, method01, method02, method11, method12);
        }
    }
}