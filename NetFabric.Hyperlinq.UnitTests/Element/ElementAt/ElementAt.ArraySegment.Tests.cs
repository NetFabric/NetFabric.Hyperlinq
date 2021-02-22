using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAt
{
    public class ArraySegmentTests 
    {
        [Fact]
        public void ElementAt_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = source.AsValueEnumerable()
                .ElementAt(0);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Return_None(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);

            // Act
            var optionTooSmall = wrapped.AsValueEnumerable()
                .ElementAt(-1);
            var optionTooLarge = wrapped.AsValueEnumerable()
                .ElementAt(take);

            // Assert
            _ = optionTooSmall.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Must_Return_Some(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .ToList(wrapped);

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = wrapped.AsValueEnumerable()
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_With_OutOfRange_Must_Return_None(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var optionTooSmall = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .ElementAt(-1);
            var optionTooLarge = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .ElementAt(take);

            // Assert
            _ = optionTooSmall.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = wrapped.AsValueEnumerable()
                    .Skip(skip)
                    .Take(take)
                    .Where(predicate)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_PredicateAt_With_OutOfRange_Must_Return_None(int[] source, int skip, int take, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var optionTooSmall = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .ElementAt(-1);
            var optionTooLarge = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .ElementAt(take);

            // Assert
            _ = optionTooSmall.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_PredicateAt_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = wrapped.AsValueEnumerable()
                    .Skip(skip)
                    .Take(take)
                    .Where(predicate)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Selector_With_OutOfRange_Must_Return_None(int[] source, int skip, int take, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var optionTooSmall = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .ElementAt(take);

            // Assert
            _ = optionTooSmall.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Selector_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Select(selector)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = wrapped.AsValueEnumerable()
                    .Skip(skip)
                    .Take(take)
                    .Select(selector)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_OutOfRange_Must_Return_None(int[] source, int skip, int take, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var optionTooSmall = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector)
                .ElementAt(take);

            // Assert
            _ = optionTooSmall.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Select(selector)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = wrapped.AsValueEnumerable()
                    .Skip(skip)
                    .Take(take)
                    .Select(selector)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_Selector_With_OutOfRange_Must_Return_None(int[] source, int skip, int take, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var optionTooSmall = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .ElementAt(take);

            // Assert
            _ = optionTooSmall.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_Selector_With_ValidData_Must_Return_Some(int[] source, int skip, int take, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = wrapped.AsValueEnumerable()
                    .Skip(skip)
                    .Take(take)
                    .Where(predicate)
                    .Select(selector)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }
    }
}