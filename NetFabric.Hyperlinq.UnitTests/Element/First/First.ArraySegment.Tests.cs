using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.First
{
    public class ArraySegmentTests
    {
        [Fact]
        public void First_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = source.AsValueEnumerable()
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        public void First_With_Empty_Must_Return_None(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);

            // Act
            var result = wrapped.AsValueEnumerable()
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Must_Return_Some(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .First(wrapped);

            // Act
            var result = wrapped.AsValueEnumerable()
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        public void First_Predicate_With_Empty_Must_Return_None(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void First_Predicate_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .First(predicate);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_Empty_Must_Return_None(int[] source, int skip, int take, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .First();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        public void First_Selector_With_Empty_Must_Return_None(int[] source, int skip, int take, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void First_Selector_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Select(selector)
                .First();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        public void First_SelectorAt_With_Empty_Must_Return_None(int[] source, int skip, int take, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void First_SelectorAt_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Select(selector)
                .First();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        public void First_Predicate_Selector_With_Empty_Must_Return_None(int[] source, int skip, int take, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void First_Predicate_Selector_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .First();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }
    }
}