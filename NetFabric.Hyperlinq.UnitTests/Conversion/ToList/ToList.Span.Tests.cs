using System;
using System.Collections.Generic;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToList
{
    public class SpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToList_With_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = ArrayExtensions
                .ToList<int>(source.AsSpan());

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
        public void ToList_With_Predicate_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .ToList();

            // Act
            var result = ArrayExtensions
                .Where(source.AsSpan(), predicate)
                .ToList();

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
        public void ToList_With_PredicateAt_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .ToList();

            // Act
            var result = ArrayExtensions
                .Where(source.AsSpan(), predicate)
                .ToList();

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
        public void ToList_With_Selector_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToList();

            // Act
            var result = ArrayExtensions
                .Select<int, string>(source.AsSpan(), selector)
                .ToList();

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
        public void ToList_With_SelectorAt_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToList();

            // Act
            var result = ArrayExtensions
                .Select(source.AsSpan(), selector)
                .ToList();

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
        public void ToList_With_Predicate_Selector_Must_Succeed(int[] source, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .Select(selector.AsFunc())
                .ToList();

            // Act
            var result = ArrayExtensions
                .Where(source.AsSpan(), predicate)
                .Select(selector)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}