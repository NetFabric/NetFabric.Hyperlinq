using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Generation.AsyncValueEnumerableTests
{
    public class EmptyTests
    {
        [Fact]
        public void Empty_Must_Succeed()
        {
            // Arrange
            var expected = Enumerable.Empty<int>();

            // Act
            var result = AsyncValueEnumerable.Empty<int>();

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}