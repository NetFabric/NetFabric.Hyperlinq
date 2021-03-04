using NetFabric.Assertive;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsAsyncValueEnumerable
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsAsyncValueEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            var result = wrapped
                .AsAsyncValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>();

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
                .AsValueEnumerable(source);
            var expected = source
                .ToArray();

            // Act
            var result = await wrapped
                .AsAsyncValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>()
                .ToArrayAsync()
                .ConfigureAwait(false);

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
                .AsValueEnumerable(source);
            var expected = source
                .ToList();

            // Act
            var result = await wrapped
                .AsAsyncValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>()
                .ToListAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}
