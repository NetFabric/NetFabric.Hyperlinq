using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Generation.ValueEnumerableTests
{
    public class AsyncReturnTests
    {
        [Theory]
        [MemberData(nameof(TestData.Return), MemberType = typeof(TestData))]
        public void Return_With_Value_Must_Succeed(int value)
        {
            // Arrange
            var expected = System.Linq.EnumerableEx.Return(value);

            // Act
            var result = AsyncValueEnumerable.Return(value);

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}