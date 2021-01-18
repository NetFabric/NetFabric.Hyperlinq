using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.First
{
    public class ReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void First_With_Empty_Must_Return_None(int[] source)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .First((ReadOnlySpan<int>)source.AsSpan());

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Must_Return_Some(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .First(source);

            // Act
            var result = ArrayExtensions
                .First((ReadOnlySpan<int>)source.AsSpan());

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public void First_Predicate_With_Empty_Must_Return_None(int[] source, Func<int, bool> predicate)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void First_Predicate_With_ValidData_Must_Return_Some(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .First(source, predicate);

            // Act
            var result = ArrayExtensions
                .Where((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_Empty_Must_Return_None(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_ValidData_Must_Return_Some(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .First();

            // Act
            var result = ArrayExtensions
                .Where((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        public void First_Selector_With_Empty_Must_Return_None(int[] source, Func<int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Select((ReadOnlySpan<int>)source.AsSpan(), selector)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void First_Selector_With_ValidData_Must_Return_Some(int[] source, Func<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector)
                .First();

            // Act
            var result = ArrayExtensions
                .Select((ReadOnlySpan<int>)source.AsSpan(), selector)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        public void First_SelectorAt_With_Empty_Must_Return_None(int[] source, Func<int, int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Select((ReadOnlySpan<int>)source.AsSpan(), selector)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void First_SelectorAt_With_ValidData_Must_Return_Some(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector)
                .First();

            // Act
            var result = ArrayExtensions
                .Select((ReadOnlySpan<int>)source.AsSpan(), selector)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        public void First_Predicate_Selector_With_Empty_Must_Return_None(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Select(selector)
                .First();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void First_Predicate_Selector_With_ValidData_Must_Return_Some(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .Select(selector)
                .First();

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Select(selector)
                .First();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }
    }
}