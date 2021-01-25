using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAt
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Return_None(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var optionTooSmall = ReadOnlyListExtensions
                .ElementAt<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, -1);
            var optionTooLarge = ReadOnlyListExtensions
                .ElementAt<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, source.Length);

            // Assert
            _ = optionTooSmall.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Must_Return_Some(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            for (var index = 0; index < source.Length; index++)
            {
                // Act
                var result = ReadOnlyListExtensions
                    .ElementAt<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(source[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Skip_Take_With_OutOfRange_Must_Return_None(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var optionTooSmall = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ElementAt(-1);
            var optionTooLarge = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ElementAt(takeCount);

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
        public void ElementAt_Skip_Take_With_ValidData_Must_Return_Some(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ReadOnlyListExtensions
                    .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
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
        public void ElementAt_Skip_Take_Predicate_With_OutOfRange_Must_Return_None(int[] source, int skipCount, int takeCount, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var optionTooSmall = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ElementAt(-1);
            var optionTooLarge = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ElementAt(takeCount);

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
        public void ElementAt_Skip_Take_Predicate_With_ValidData_Must_Return_Some(int[] source, int skipCount, int takeCount, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ReadOnlyListExtensions
                    .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
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
        public void ElementAt_Skip_Take_PredicateAt_With_OutOfRange_Must_Return_None(int[] source, int skipCount, int takeCount, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var optionTooSmall = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ElementAt(-1);
            var optionTooLarge = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ElementAt(takeCount);

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
        public void ElementAt_Skip_Take_PredicateAt_With_ValidData_Must_Return_Some(int[] source, int skipCount, int takeCount, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ReadOnlyListExtensions
                    .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
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
        public void ElementAt_Skip_Take_Selector_With_OutOfRange_Must_Return_None(int[] source, int skipCount, int takeCount, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var optionTooSmall = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ElementAt(takeCount);

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
        public void ElementAt_Skip_Take_Selector_With_ValidData_Must_Return_Some(int[] source, int skipCount, int takeCount, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ReadOnlyListExtensions
                    .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
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
        public void ElementAt_Skip_Take_SelectorAt_With_OutOfRange_Must_Return_None(int[] source, int skipCount, int takeCount, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var optionTooSmall = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ElementAt(takeCount);

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
        public void ElementAt_Skip_Take_SelectorAt_With_ValidData_Must_Return_Some(int[] source, int skipCount, int takeCount, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ReadOnlyListExtensions
                    .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
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
        public void ElementAt_Skip_Take_Predicate_Selector_With_OutOfRange_Must_Return_None(int[] source, int skipCount, int takeCount, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var optionTooSmall = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .ElementAt(takeCount);

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
        public void ElementAt_Skip_Take_Predicate_Selector_With_ValidData_Must_Return_Some(int[] source, int skipCount, int takeCount, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ReadOnlyListExtensions
                    .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
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