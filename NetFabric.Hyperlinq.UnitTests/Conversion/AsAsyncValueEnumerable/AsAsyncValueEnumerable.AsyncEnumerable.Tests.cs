using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            var result = wrapped
                .AsAsyncValueEnumerable();

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
            var expected = source
                .ToArray();

            // Act
            var result = await wrapped
                .AsAsyncValueEnumerable()
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
            var expected = source
                .ToList();

            // Act
            var result = await wrapped
                .AsAsyncValueEnumerable()
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsAsyncValueEnumerable_GetEnumerator_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncEnumerable(source);

            // Act
            var result = wrapped
                .AsAsyncValueEnumerable<Wrap.AsyncEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>((enumerable, _) => enumerable.GetAsyncEnumerator());

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(source);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask AsAsyncValueEnumerable_GetEnumerator_ToListAsync_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncEnumerable(source);

            // Act
            var result = await wrapped
                .AsAsyncValueEnumerable<Wrap.AsyncEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>((enumerable, _) => enumerable.GetAsyncEnumerator())
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(source);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask AsAsyncValueEnumerable_GetEnumerator_ToArrayAsync_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncEnumerable(source);

            // Act
            var result = await wrapped
                .AsAsyncValueEnumerable<Wrap.AsyncEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>((enumerable, _) => enumerable.GetAsyncEnumerator())
                .ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(source);
        }
    }
}