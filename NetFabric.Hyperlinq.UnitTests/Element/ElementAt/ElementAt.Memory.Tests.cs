using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAt
{
    public class MemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Return_None(int[] source)
        {
            // Arrange

            // Act
            var optionNegative = source.AsMemory().AsValueEnumerable()
                .ElementAt(-1);
            var optionTooLarge = source.AsMemory().AsValueEnumerable()
                .ElementAt(source.Length);

            // Assert
            _ = optionNegative.Must()
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
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var expected = Enumerable
                    .ElementAt(source, index);

                // Act
                var result = source.AsMemory().AsValueEnumerable()
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_With_OutOfRange_Must_Return_None(int[] source, Func<int, bool> predicate)
        {
            // Arrange

            // Act
            var optionNegative = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .ElementAt(-1);
            var optionTooLarge = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .ElementAt(source.Length);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_With_ValidData_Must_Return_Some(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = source.AsMemory().AsValueEnumerable()
                    .Where(predicate)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_PredicateAt_With_OutOfRange_Must_Return_None(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange

            // Act
            var optionNegative = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .ElementAt(-1);
            var optionTooLarge = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .ElementAt(source.Length);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_PredicateAt_With_ValidData_Must_Return_Some(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = source.AsMemory().AsValueEnumerable()
                    .Where(predicate)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Selector_With_OutOfRange_Must_Return_None(int[] source, Func<int, string> selector)
        {
            // Arrange

            // Act
            var optionNegative = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .ElementAt(source.Length);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Selector_With_ValidData_Must_Return_Some(int[] source, Func<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector)
                .ToList();

            for (var index = 0; index < source.Length; index++)
            {
                // Act
                var result = source.AsMemory().AsValueEnumerable()
                    .Select(selector)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }
        
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_OutOfRange_Must_Return_None(int[] source, Func<int, int, string> selector)
        {
            // Arrange

            // Act
            var optionNegative = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .ElementAt(source.Length);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_ValidData_Must_Return_Some(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector)
                .ToList();

            for (var index = 0; index < source.Length; index++)
            {
                // Act
                var result = source.AsMemory().AsValueEnumerable()
                    .Select(selector)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_Selector_With_OutOfRange_Must_Return_None(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange

            // Act
            var optionNegative = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Select(selector)
                .ElementAt(source.Length);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_Selector_With_ValidData_Must_Return_Some(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .Select(selector)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = source.AsMemory().AsValueEnumerable()
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