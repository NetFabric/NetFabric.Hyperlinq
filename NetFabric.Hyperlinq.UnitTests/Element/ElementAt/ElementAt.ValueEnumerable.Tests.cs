using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAt
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Return_None(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var optionNegative = ValueEnumerableExtensions
                .ElementAt<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, -1);
            var optionTooLarge = ValueEnumerableExtensions
                .ElementAt<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, source.Length);

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
                var wrapped = Wrap.AsValueEnumerable(source);
                var expected = 
                    System.Linq.Enumerable.ElementAt(source, index);

                // Act
                var result = ValueEnumerableExtensions
                    .ElementAt<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, index);

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
        public void ElementAt_Predicate_With_OutOfRange_Must_Return_None(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var optionNegative = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .ElementAt(-1);
            var optionTooLarge = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
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
        public void ElementAt_Predicate_With_ValidData_Must_Return_Some(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ValueEnumerableExtensions
                    .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
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
        public void ElementAt_PredicateAt_With_OutOfRange_Must_Return_None(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var optionNegative = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .ElementAt(-1);
            var optionTooLarge = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
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
        public void ElementAt_PredicateAt_With_ValidData_Must_Return_Some(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ValueEnumerableExtensions
                    .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
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
        public void ElementAt_Selector_With_OutOfRange_Must_Return_None(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var optionNegative = ValueEnumerableExtensions
                .Select<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ElementAt(-1);
            var optionTooLarge = ValueEnumerableExtensions
                .Select<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
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
        public void ElementAt_Selector_With_ValidData_Must_Return_Some(int[] source, Selector<int, string> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueEnumerable(source);
                var expected = 
                    System.Linq.Enumerable.ElementAt(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = ValueEnumerableExtensions
                    .Select<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected),
                    () => throw new Exception());
            }
        }
        
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_OutOfRange_Must_Return_None(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var optionNegative = ValueEnumerableExtensions
                .Select<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ElementAt(-1);
            var optionTooLarge = ValueEnumerableExtensions
                .Select<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
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
        public void ElementAt_SelectorAt_With_ValidData_Must_Return_Some(int[] source, SelectorAt<int, string> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueEnumerable(source);
                var expected = 
                    System.Linq.Enumerable.ElementAt(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = ValueEnumerableExtensions
                    .Select<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                    .ElementAt(index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_Selector_With_OutOfRange_Must_Return_None(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var optionNegative = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .Select(selector)
                .ElementAt(-1);
            var optionTooLarge = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
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
        public void ElementAt_Predicate_Selector_With_ValidData_Must_Return_Some(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = ValueEnumerableExtensions
                    .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
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