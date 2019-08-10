using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FodyDependenciesTests
    {
        [Fact]
        public void Assembly_Should_NotDependeOnBuildAssemblies()
        {
            // Arrange
            var assembly = typeof(IgnoreAttribute).Assembly;

            // Act
            var result = assembly.GetReferencedAssemblies();

            // Assert
            System.Linq.Enumerable.FirstOrDefault(result, a => a.FullName.StartsWith("NetFabric")).Should().BeNull();
        }
    }
}