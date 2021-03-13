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
            => new()
            {
                { new[] { "TestData/Source/NoExtensionMethods.cs" }, 0 },
                { new[] { "TestData/Source/ExtensionMethods.cs" }, 3 },

                { new[] { "TestData/Source/Distinct.ArraySegment.cs" }, 1},
                { new[] { "TestData/Source/Count.ValueEnumerable.cs" }, 1 },
                { new[] { "TestData/Source/Distinct.ValueEnumerable.cs" }, 1 },

                { new[] { "TestData/Source/Where.ArraySegment.cs" }, 2 },
                { new[] { "TestData/Source/Select.ArraySegment.cs" }, 2 },
                { new[] { "TestData/Source/Where.ValueEnumerable.cs" }, 2 },
                { new[] { "TestData/Source/Select.ValueEnumerable.cs" }, 2 },
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
                .Concat(Directory.EnumerateFiles("../../../../NetFabric.Hyperlinq.SourceGenerator/Attributes/", "*.cs", SearchOption.AllDirectories))
                .Select(path => File.ReadAllText(path)));
            var context = new CompilationContext(await project.GetCompilationAsync().ConfigureAwait(false) ?? throw new System.Exception("Error getting compilation!"));

            // Act
            var result = generator.CollectExtensionMethods(context);

            // Assert
            _ = result.Count.Must()
                .BeEqualTo(expected);
        }
    }
}