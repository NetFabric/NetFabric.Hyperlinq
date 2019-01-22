using System;
using Xunit;
using TestHelper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NetFabric.Hyperlinq.Analyzer.UnitTests
{
    public class LocalVariableBoxingTests : CodeFixVerifier
    {
        [Fact]
        public void Empty_Should_Succeeds()
        {
            var test = @"";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void AssignConstructorToExplicitType_Should_Succeed()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        List<int> list = new List<int>();
                    }
                }
            ";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void AssignMethodToExplicitType_Should_Succeed()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        List<int> list = GetList();
                    }

                    static List<int> GetList() => new List<int>();
                }
            ";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void AssignParameterToExplicitType_Should_Succeed()
        {
            var test = @"
                class C
                {
                    void M(List<int> a)
                    {
                        List<int> list = a;
                    }
                }
            ";

            VerifyCSharpDiagnostic(test);
        }


        [Fact]
        public void AssignContructorToVar_Should_Succeed()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        var list = new List<int>();
                    }
                }
            ";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void AssignMethodToVar_Should_Succeed()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        var list = GetList();
                    }

                    static List<int> GetList() => new List<int>();
                }
            ";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void AssignParameterToVar_Should_Succeed()
        {
            var test = @"
                class C
                {
                    void M(List<int> a)
                    {
                        var list = a;
                    }
                }
            ";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void AssignEnumerableMethodToEnumerable_Should_Succeed()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        IEnumerable enumerable = GetEnumerable();
                    }

                    static IEnumerable<int> GetEnumerable() => yield break;
                }
            ";

            VerifyCSharpDiagnostic(test);
        }    

        [Fact]
        public void AssignEnumerableMethodToEnumerableOfT_Should_Succeed()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        IEnumerable<int> enumerable = GetEnumerable();
                    }

                    static IEnumerable<int> GetEnumerable() => yield break;
                }
            ";

            VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void AssignConstructorToEnumerable_Should_ReturnDiagnostic()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        IEnumerable list = new List<int>();
                    }
                }
            ";

            var expected = new DiagnosticResult
            {
                Id = "HLQ01",
                Message = "Assigment to interface causes boxing of enumerator for 'List<>'",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 15)
                },
            };

            VerifyCSharpDiagnostic(test, expected);
        }    

        [Fact]
        public void AssignMethodToEnumerable_Should_ReturnDiagnostic()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        IEnumerable list = GetList();
                    }

                    static List<int> GetList() => new List<int>();
                }
            ";


            var expected = new DiagnosticResult
            {
                Id = "HLQ01",
                Message = "Assigment to interface causes boxing of enumerator for 'List<>'",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 15)
                },
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [Fact]
        public void AssignParameterToEnumerable_Should_ReturnDiagnostic()
        {
            var test = @"
                class C
                {
                    void M(List<int> a)
                    {
                        IEnumerable list = a;
                    }
                }
            ";

            var expected = new DiagnosticResult
            {
                Id = "HLQ01",
                Message = "Assigment to interface causes boxing of enumerator for 'List<>'",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 15)
                },
            };

            VerifyCSharpDiagnostic(test, expected);
        }


        [Fact]
        public void AssignConstructorToEnumerableOfT_Should_ReturnDiagnostic()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        IEnumerable<int> list = new List<int>();
                    }
                }
            ";

            var expected = new DiagnosticResult
            {
                Id = "HLQ01",
                Message = "Assigment to interface causes boxing of enumerator for 'List<>'",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 15)
                },
            };

            VerifyCSharpDiagnostic(test, expected);
        }    

        [Fact]
        public void AssignMethodToEnumerableOfT_Should_ReturnDiagnostic()
        {
            var test = @"
                class C
                {
                    void M()
                    {
                        IEnumerable<int> list = GetList();
                    }

                    static List<int> GetList() => new List<int>();
                }
            ";

            var expected = new DiagnosticResult
            {
                Id = "HLQ01",
                Message = "Assigment to interface causes boxing of enumerator for 'List<>'",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 15)
                },
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [Fact]
        public void AssignParameterToEnumerableOfT_Should_ReturnDiagnostic()
        {
            var test = @"
                class C
                {
                    void M(List<int> a)
                    {
                        IEnumerable<int> list = a;
                    }
                }
            ";

            var expected = new DiagnosticResult
            {
                Id = "HLQ01",
                Message = "Assigment to interface causes boxing of enumerator for 'List<>'",
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] {
                    new DiagnosticResultLocation("Test0.cs", 11, 15)
                },
            };

            VerifyCSharpDiagnostic(test, expected);
        }
    }
}