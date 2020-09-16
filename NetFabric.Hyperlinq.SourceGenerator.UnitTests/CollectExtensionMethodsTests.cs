using Microsoft.CodeAnalysis;
using NetFabric.Assertive;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.SourceGenerator.UnitTests
{
    public class CollectExtensionMethodsTests
    {
        public static TheoryData<string[], int> ExtensionMethods
            => new TheoryData<string[], int> {
                { new string[] { "TestData/Source/NoExtensionMethods.cs" }, 0 },
                { new string[] { "TestData/Source/Distinct.ArraySegment.cs" }, 0 },
                { new string[] { "TestData/Source/Where.ArraySegment.cs" }, 0 },
                { new string[] { "TestData/Source/Select.ArraySegment.cs" }, 0 },

                { new string[] { "TestData/Source/ExtensionMethods.cs" }, 1 },
                { new string[] { "TestData/Source/Count.ValueEnumerable.cs" }, 1 },
                { new string[] { "TestData/Source/Distinct.ValueEnumerable.cs" }, 1 },

                { new string[] { "TestData/Source/Where.ValueEnumerable.cs" }, 2 },
                { new string[] { "TestData/Source/Select.ValueEnumerable.cs" }, 2 },
            };

        [Theory]
        [MemberData(nameof(ExtensionMethods))]
        public async Task ShouldCollectExpectedNumberOfExtensionMethods(string[] paths, int expected)
        {
            // Arrange
            var generator = new OverloadsGenerator();
            var project = Verifier.CreateProject(
                paths
                .Concat(Directory.EnumerateFiles("TestData/Source/Common", "*.cs", SearchOption.AllDirectories))
                .Select(path => File.ReadAllText(path)));
            var compilation = await project.GetCompilationAsync().ConfigureAwait(false);

            // Act
            var result = generator.CollectExtensionMethods(compilation!);

            // Assert
            _ = result.Values.SelectMany(item => item).Count().Must()
                .BeEqualTo(expected);
        }
    }
}