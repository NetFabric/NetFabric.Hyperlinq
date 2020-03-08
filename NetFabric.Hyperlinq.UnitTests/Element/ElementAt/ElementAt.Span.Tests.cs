using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAt
{
    public class SpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Throw(int[] source)
        {
            // Arrange

            // Act
            Action actionLess = () => _ = Array
                .ElementAt<int>(source.AsSpan(), -1);
            Action actionGreater = () => _ = Array
                .ElementAt<int>(source.AsSpan(), source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Must_Succeed(int[] source)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var expected = 
                    System.Linq.Enumerable.ElementAt(source, index);

                // Act
                var result = Array
                    .ElementAt<int>(source.AsSpan(), index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_With_OutOfRange_Must_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action actionLess = () => _ = Array
                .Where<int>(source.AsSpan(), predicate)
                .ElementAt(-1);
            Action actionGreater = () => _ = Array
                .Where<int>(source.AsSpan(), predicate)
                .ElementAt(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = Array
                    .Where<int>(source.AsSpan(), predicate)
                    .ElementAt(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected[index]);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_PredicateAt_With_OutOfRange_Must_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action actionLess = () => _ = Array
                .Where<int>(source.AsSpan(), predicate)
                .ElementAt(-1);
            Action actionGreater = () => _ = Array
                .Where<int>(source.AsSpan(), predicate)
                .ElementAt(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = Array
                    .Where<int>(source.AsSpan(), predicate)
                    .ElementAt(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected[index]);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Selector_With_OutOfRange_Must_Throw(int[] source, Selector<int, string> selector)
        {
            // Arrange

            // Act
            Action actionLess = () => _ = Array
                .Select<int, string>(source.AsSpan(), selector)
                .ElementAt(-1);
            Action actionGreater = () => _ = Array
                .Select<int, string>(source.AsSpan(), selector)
                .ElementAt(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var expected = 
                    System.Linq.Enumerable.ElementAt(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = Array
                    .Select<int, string>(source.AsSpan(), selector)
                    .ElementAt(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }
        
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_OutOfRange_Must_Throw(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange

            // Act
            Action actionLess = () => _ = Array
                .Select<int, string>(source.AsSpan(), selector)
                .ElementAt(-1);
            Action actionGreater = () => _ = Array
                .Select<int, string>(source.AsSpan(), selector)
                .ElementAt(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var expected = 
                    System.Linq.Enumerable.ElementAt(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = Array
                    .Select<int, string>(source.AsSpan(), selector)
                    .ElementAt(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_Selector_With_OutOfRange_Must_Throw(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange

            // Act
            Action actionLess = () => _ = Array
                .Where<int>(source.AsSpan(), predicate)
                .Select(selector)
                .ElementAt(-1);
            Action actionGreater = () => _ = Array
                .Where<int>(source.AsSpan(), predicate)
                .Select(selector)
                .ElementAt(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = Array
                    .Where<int>(source.AsSpan(), predicate)
                    .Select(selector)
                    .ElementAt(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected[index]);
            }
        }
    }
}