using NetFabric.Assertive;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAtOrDefaultAsync
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtOrDefaultAsync_With_ValidData_Must_Succeed(int[] source)
        {
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(source, index);

                // Act
                var result = await AsyncValueEnumerable
                    .ElementAtOrDefaultAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtOrDefaultAsync_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = await AsyncValueEnumerable
                    .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                    .ElementAtOrDefaultAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtOrDefaultAsync_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = await AsyncValueEnumerable
                    .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                    .ElementAtOrDefaultAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtOrDefaultAsync_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsAsyncValueEnumerable(source);
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = await AsyncValueEnumerable
                    .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                    .ElementAtOrDefaultAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtOrDefaultAsync_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsAsyncValueEnumerable(source);
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = await AsyncValueEnumerable
                    .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                    .ElementAtOrDefaultAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtOrDefaultAsync_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = await AsyncValueEnumerable
                    .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                    .Select(selector.AsAsync())
                    .ElementAtOrDefaultAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }
    }
}