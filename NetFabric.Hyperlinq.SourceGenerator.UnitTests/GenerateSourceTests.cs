using Microsoft.CodeAnalysis;
using NetFabric.Assertive;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.SourceGenerator.UnitTests
{
    public class GenerateSourceTests
    {
        public static TheoryData<string[]> ClassesWithOverloads
            => new TheoryData<string[]> {
                new string[] {
                    "TestData/Source/Count.ValueEnumerable.cs",
                },
                new string[] {
                    "TestData/Source/Where.ValueEnumerable.cs",
                },
                new string[] {
                    "TestData/Source/Select.ValueEnumerable.cs",
                },
            };

        [Theory]
        [MemberData(nameof(ClassesWithOverloads))]
        public async Task ClassesWithOverloadsShouldNotGenerate(string[] paths)
        {
            // Arrange
            var generator = new OverloadsGenerator();
            var project = Verifier.CreateProject(
                paths
                .Concat(Directory.EnumerateFiles("TestData/Source/Common", "*.cs", SearchOption.AllDirectories))
                .Select(path => File.ReadAllText(path)));
            var compilation = await project.GetCompilationAsync().ConfigureAwait(false);

            // Act
            var extensionMethods = generator.CollectExtensionMethods(compilation!);
            var result = generator.GenerateSource(compilation!, extensionMethods);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(INamedTypeSymbol, INamedTypeSymbol, string)>()
                .BeEmpty();
        }

        // -----------------------------------------------------

        public static TheoryData<string[], string[]> GeneratorSources
            => new TheoryData<string[], string[]> {
                {
                    new string[] {
                        "TestData/Source/Range.cs",
                        "TestData/Source/Contains.ValueEnumerable.cs",
                    },
                    new string[] {
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Select.ArraySegment.cs",
                        "TestData/Source/Contains.ValueEnumerable.cs",
                    },
                    new string[] {
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Range.cs",
                        "TestData/Source/Count.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Range.Count.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Repeat.cs",
                        "TestData/Source/Count.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Repeat.Count.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Range.cs",
                        "TestData/Source/Where.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Range.Where.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Range.cs",
                        "TestData/Source/Select.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Range.Select.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Count.ValueEnumerable.cs",
                        "TestData/Source/Where.ArraySegment.cs",
                    },
                    new string[] {
                        "TestData/Results/Where.ArraySegment.Count.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Any.ArraySegment.cs",
                        "TestData/Source/Any.ReadOnlyList.cs",
                        "TestData/Source/Any.ValueEnumerable.cs",
                        "TestData/Source/Any.ValueReadOnlyCollection.cs",
                        "TestData/Source/Where.ValueEnumerable.cs",
                    },
                    new string[] {
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Any.ArraySegment.cs",
                        "TestData/Source/Any.ReadOnlyList.cs",
                        "TestData/Source/Any.ValueEnumerable.cs",
                        "TestData/Source/Any.ValueReadOnlyCollection.cs",
                        "TestData/Source/Select.ArraySegment.cs",
                    },
                    new string[] {
                        "TestData/Results/Select.ArraySegment.Any.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Any.ArraySegment.cs",
                        "TestData/Source/Any.ReadOnlyList.cs",
                        "TestData/Source/Any.ValueEnumerable.cs",
                        "TestData/Source/Any.ValueReadOnlyCollection.cs",
                        "TestData/Source/Select.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Select.ValueEnumerable.Any.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Count.ValueEnumerable.cs",
                        "TestData/Source/Where.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Where.ValueEnumerable.Count.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/First.ValueEnumerable.cs",
                        "TestData/Source/Where.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Where.ValueEnumerable.First.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/First.ValueEnumerable.cs",
                        "TestData/Source/Select.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Select.ValueEnumerable.First.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Where.ValueEnumerable.cs",
                        "TestData/Source/Distinct.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Where.ValueEnumerable.Distinct.cs",
                        "TestData/Results/Distinct.ValueEnumerable.Where.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Where.ValueEnumerable.cs",
                        "TestData/Source/Select.ValueEnumerable.cs",
                    },
                    new string[] {
                        "TestData/Results/Where.ValueEnumerable.Select.cs",
                        "TestData/Results/Select.ValueEnumerable.Where.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Where.ValueEnumerable.cs",
                        "TestData/Source/Dictionary.Bindings.cs",
                    },
                    new string[] {
                        "TestData/Results/Dictionary.Where.cs",
                    }
                },
                {
                    new string[] {
                        "TestData/Source/Select.ValueEnumerable.cs",
                        "TestData/Source/Dictionary.Bindings.cs",
                    },
                    new string[] {
                        "TestData/Results/Dictionary.Select.cs",
                    }
                },
            };

        [Theory]
        [MemberData(nameof(GeneratorSources))]
        public async Task GenerateSourceShouldGenerate(string[] paths, string[] expected)
        { 
            // Arrange
            var generator = new OverloadsGenerator();
            var project = Verifier.CreateProject(
                paths
                .Concat(Directory.EnumerateFiles("TestData/Source/Common", "*.cs", SearchOption.AllDirectories))
                .Select(path => File.ReadAllText(path)));
            var compilation = await project.GetCompilationAsync().ConfigureAwait(false);

            // Act
            var extensionMethods = generator.CollectExtensionMethods(compilation!);
            var result = generator.GenerateSource(compilation!, extensionMethods);

            // Assert
            _ = result.Select(item => item.Source)
                .ToArray()
                .Must()
                .BeEqualTo(expected.Select(path => File.ReadAllText(path)));
        }
    }
}