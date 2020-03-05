using NetFabric.Assertive;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.FirstOrDefault
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask FirstOrDefaultAsync_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(source);

            // Act
            var result = await AsyncValueEnumerable
                .FirstOrDefaultAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask FirstOrDefaultAsync_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(source, predicate.AsFunc());

            // Act
            var result = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .FirstOrDefaultAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask FirstOrDefaultAsync_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .FirstOrDefaultAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}