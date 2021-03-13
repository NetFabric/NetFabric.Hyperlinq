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
            => new()
            {
                new[] {
                    "TestData/Source/Count.ValueEnumerable.cs",
                },
                new[] {
                    "TestData/Source/Where.ValueEnumerable.cs",
                },
                new[] {
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
                .Concat(Directory.EnumerateFiles("../../../../NetFabric.Hyperlinq.SourceGenerator/Attributes/", "*.cs", SearchOption.AllDirectories))
                .Select(path => File.ReadAllText(path)));
            var context = new CompilationContext(await project.GetCompilationAsync().ConfigureAwait(false) ?? throw new System.Exception("Error getting compilation!"));

            // Act
            var extensionMethods = generator.CollectExtensionMethods(context);
            var result = generator.GenerateSource(extensionMethods, context);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(INamedTypeSymbol, INamedTypeSymbol, string)>()
                .BeEmpty();
        }

        // -----------------------------------------------------

        public static TheoryData<string[], string[]> GeneratorSources
            => new()
            {
                {
                    new[] {
                        "TestData/Source/Range.cs",
                        "TestData/Source/Contains.ValueEnumerable.cs",
                    },
                    new string[] {
                    }
                },
                {
                    new[] {
                        "TestData/Source/Select.ArraySegment.cs",
                        "TestData/Source/Contains.ValueEnumerable.cs",
                    },
                    new string[] {
                    }
                },
                {
                    new[] {
                        "TestData/Source/Range.cs",
                        "TestData/Source/Count.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Range.Count.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Repeat.cs",
                        "TestData/Source/Count.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Repeat.Count.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Range.cs",
                        "TestData/Source/Where.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Range.Where.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Range.cs",
                        "TestData/Source/Select.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Range.Select.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Count.ValueEnumerable.cs",
                        "TestData/Source/Where.ArraySegment.cs",
                    },
                    new[] {
                        "TestData/Results/Where.ArraySegment.Count.cs",
                    }
                },
                {
                    new[] {
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
                    new[] {
                        "TestData/Source/Any.ArraySegment.cs",
                        "TestData/Source/Any.ReadOnlyList.cs",
                        "TestData/Source/Any.ValueEnumerable.cs",
                        "TestData/Source/Any.ValueReadOnlyCollection.cs",
                        "TestData/Source/Select.ArraySegment.cs",
                    },
                    new[] {
                        "TestData/Results/Select.ArraySegment.Any.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Any.ArraySegment.cs",
                        "TestData/Source/Any.ReadOnlyList.cs",
                        "TestData/Source/Any.ValueEnumerable.cs",
                        "TestData/Source/Any.ValueReadOnlyCollection.cs",
                        "TestData/Source/Select.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Select.ValueEnumerable.Any.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Count.ValueEnumerable.cs",
                        "TestData/Source/Where.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Where.ValueEnumerable.Count.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/First.ValueEnumerable.cs",
                        "TestData/Source/Where.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Where.ValueEnumerable.First.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/First.ValueEnumerable.cs",
                        "TestData/Source/Select.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Select.ValueEnumerable.First.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Where.ValueEnumerable.cs",
                        "TestData/Source/Distinct.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Where.ValueEnumerable.Distinct.cs",
                        "TestData/Results/Distinct.ValueEnumerable.Where.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Where.ValueEnumerable.cs",
                        "TestData/Source/Select.ValueEnumerable.cs",
                    },
                    new[] {
                        "TestData/Results/Where.ValueEnumerable.Select.cs",
                        "TestData/Results/Select.ValueEnumerable.Where.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Where.ValueEnumerable.cs",
                        "TestData/Source/Dictionary.Bindings.cs",
                    },
                    new[] {
                        "TestData/Results/Dictionary.Where.cs",
                    }
                },
                {
                    new[] {
                        "TestData/Source/Select.ValueEnumerable.cs",
                        "TestData/Source/Dictionary.Bindings.cs",
                    },
                    new[] {
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
                .Concat(Directory.EnumerateFiles("../../../../NetFabric.Hyperlinq.SourceGenerator/Attributes/", "*.cs", SearchOption.AllDirectories))
                .Select(path => File.ReadAllText(path)));
            var context = new CompilationContext(await project.GetCompilationAsync().ConfigureAwait(false) ?? throw new System.Exception("Error getting compilation!"));

            // Act
            var extensionMethods = generator.CollectExtensionMethods(context);
            var result = generator.GenerateSource(extensionMethods, context);

            // Assert
            _ = result.Select(item => item.Source)
                .ToArray()
                .Must()
                .BeEqualTo(expected.Select(path => File.ReadAllText(path)));
        }
    }
}