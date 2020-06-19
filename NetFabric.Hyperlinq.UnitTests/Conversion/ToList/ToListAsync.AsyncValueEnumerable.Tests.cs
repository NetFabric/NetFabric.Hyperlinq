using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async ValueTask ToListAsync_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ToListAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

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
        public async ValueTask ToListAsync_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .ToList();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
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
        public async ValueTask ToListAsync_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .ToList();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
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
        public async ValueTask ToListAsync_Selector_With_ValidData_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToList();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
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
        public async ValueTask ToListAsync_SelectorAt_With_ValidData_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToList();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
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
        public async ValueTask ToListAsync_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .Select(selector.AsFunc())
                .ToList();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
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