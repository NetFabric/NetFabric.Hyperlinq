using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Generation.ValueEnumerableTests
{
    public class EmptyTests
    {
        [Fact]
        public void Empty_Must_Succeed()
        {
            // Arrange
            var expected = Enumerable.Empty<int>();

            // Act
            var result = ValueEnumerable.Empty<int>();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}