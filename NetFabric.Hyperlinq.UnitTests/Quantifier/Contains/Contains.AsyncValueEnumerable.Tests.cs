using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Contains
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_With_Null_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, null);

            // Act
            var result = await AsyncValueEnumerable
                .ContainsAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value, null);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_With_Comparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, EqualityComparer<int>.Default);

            // Act
            var result = await AsyncValueEnumerable
                .ContainsAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}