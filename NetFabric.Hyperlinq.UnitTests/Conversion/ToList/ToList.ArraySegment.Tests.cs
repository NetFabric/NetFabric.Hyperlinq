using System;
using System.Collections.Generic;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToList
{
    public class ArraySegmentTests
    {
        [Fact]
        public void ToList_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = source.AsValueEnumerable()
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(new List<int>());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToList_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .ToList(wrapped);

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
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ToList_Predicate_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ToList_PredicateAt_Must_Succeed(int[] source, int skip, int take, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ToList_Selector_Must_Succeed(int[] source, int skip, int take, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(wrapped, skip)
                .Take(take)
                .Select(selector)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToList_SelectorAt_Must_Succeed(int[] source, int skip, int take, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(wrapped, skip)
                .Take(take)
                .Select(selector)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ToList_Predicate_Selector_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .ToList();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
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