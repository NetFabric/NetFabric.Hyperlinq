using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.Single
{
    public class MemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Must_Return_None(int[] source)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void Single_With_Single_Must_Return_Some(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .Single(source);

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Single_With_Multiple_Must_Return_None(int[] source)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Empty_Must_Return_None(int[] source, Func<int, bool> predicate)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Single_Must_Return_Some(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected =
                Enumerable.Single(source, predicate);

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Multiple_Must_Return_None(int[] source, Func<int, bool> predicate)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Empty_Must_Return_None(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Single_Must_Return_Some(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .Single();

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Multiple_Must_Return_None(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        public void Single_Selector_With_Empty_Must_Return_None(int[] source, Func<int, string> selector)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        public void Single_Selector_With_Single_Must_Return_Some(int[] source, Func<int, string> selector)
        {
            // Arrange
            var expected =
                Enumerable.Single(
                    Enumerable.Select(source, selector));

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Single_Selector_With_Multiple_Must_Return_None(int[] source, Func<int, string> selector)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Empty_Must_Return_None(int[] source, Func<int, int, string> selector)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Single_Must_Return_Some(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector)
                .Single();

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Multiple_Must_Return_None(int[] source, Func<int, int, string> selector)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Empty_Must_Return_None(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Single_Must_Return_Some(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .Select(selector)
                .Single();

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Multiple_Must_Return_None(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange

            // Act
            var result = source.AsMemory().AsValueEnumerable()
                .Where(predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }
    }
}