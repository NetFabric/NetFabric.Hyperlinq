using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToList
{
    public class ReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToList_With_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .ToList();

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
        public void ToList_With_Predicate_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Where(predicate)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Where(predicate)
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
        public void ToList_With_PredicateAt_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Where(predicate)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Where(predicate)
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
        public void ToList_With_Selector_Must_Succeed(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Select(selector)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Select(selector)
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
        public void ToList_With_SelectorAt_Must_Succeed(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Select(selector)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Select(selector)
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
        public void ToList_With_Predicate_Selector_Must_Succeed(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Where(predicate)
                .Select(selector)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Where(predicate)
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