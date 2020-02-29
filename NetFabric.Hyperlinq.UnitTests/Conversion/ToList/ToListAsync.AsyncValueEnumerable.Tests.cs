using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToList
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ToListAsync_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(source);

            // Act
            var result = await AsyncValueEnumerable
                .ToListAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToListAsync_Predicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToListAsync_PredicateAt_With_ValidData_Should_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToListAsync_Selector_With_ValidData_Should_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToListAsync_SelectorAt_With_ValidData_Should_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }


        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToListAsync_Predicate_Selector_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}