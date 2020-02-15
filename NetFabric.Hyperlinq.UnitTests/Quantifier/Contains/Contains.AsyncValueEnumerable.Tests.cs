using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ContainsAsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_With_ValidData_Should_Succeed(int[] source, int value, IEqualityComparer<int> comparer)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, comparer);

            // Act
            var result = await AsyncValueEnumerable
                .ContainsAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value, comparer);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}