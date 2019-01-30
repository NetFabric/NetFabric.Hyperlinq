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
        [Fact]
        public void FieldInitialization_Private_Should_Succeed()
        {
            var test = @"
                class C
                {
                    readonly List<T> field = new List<T>();
                }
            ";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void FieldInitialization_Private_With_Boxing_Should_ReturnDiagnostic()
        {
            var test = @"
                class C
                {
                    readonly IList<T> field = new List<T>();
                }
            ";

            var expected = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'MyRangeEnumerable' has a value type enumerator. Assigning it to 'IMyReadOnlyList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 15)
                },
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [Fact]
        public void FieldInitialization_Private__With_MethodCall_Should_Succeed()
        {
            var test = @"
                class C
                {
                    readonly MyRangeEnumerable field = MyEnumerable.RangeValueType(0, 10);
                }
            ";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void FieldInitialization_Private_With_MethodCall_And_Boxing_Should_ReturnDiagnostic()
        {
            var test = @"
                class C
                {
                    readonly IMyReadOnlyList field = MyEnumerable.RangeValueType(0, 10);
                }
            ";

            var expected = new DiagnosticResult
            {
                Id = "HLQ001",
                Message = "'MyRangeEnumerable' has a value type enumerator. Assigning it to 'IMyReadOnlyList' causes boxing of the enumerator.",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 15)
                },
            };

            VerifyCSharpDiagnostic(test, expected);
        }
    }
}