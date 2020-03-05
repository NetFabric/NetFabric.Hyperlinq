using System.Collections.Generic;
using System.Threading.Tasks;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsAsyncValueEnumerable
{
    public class AsyncEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsAsyncValueEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncEnumerable(source);

            // Act
            var result = AsyncEnumerable
                .AsAsyncValueEnumerable(wrapped);

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(source);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask AsAsyncValueEnumerable_With_ToArrayAsync_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToArray(source);

            // Act
            var result = await AsyncEnumerable
                .AsAsyncValueEnumerable<int>(wrapped)
                .ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask AsAsyncValueEnumerable_With_ToListAsync_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(source);

            // Act
            var result = await AsyncEnumerable
                .AsAsyncValueEnumerable<int>(wrapped)
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}