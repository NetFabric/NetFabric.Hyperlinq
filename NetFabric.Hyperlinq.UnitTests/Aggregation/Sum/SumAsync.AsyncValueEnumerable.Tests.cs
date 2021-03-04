using NetFabric.Assertive;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Sum
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Sum), MemberType = typeof(TestData))]
        public async ValueTask SumAsync_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = await wrapped
                .SumAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, int>()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.NullableSum), MemberType = typeof(TestData))]
        public async ValueTask SumAsync_With_Nullable_ValidData_Must_Succeed(int?[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = await wrapped
                .SumAsync<Wrap.AsyncValueEnumerableWrapper<int?>, Wrap.AsyncEnumerator<int?>, int?, int>()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected.Value);
        }
    }
}