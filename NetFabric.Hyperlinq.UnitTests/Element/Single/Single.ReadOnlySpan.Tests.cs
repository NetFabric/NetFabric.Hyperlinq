using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.Single
{
    public class ReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Must_Return_None(int[] source)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Single<int>((ReadOnlySpan<int>)source.AsSpan());

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
            var expected = 
                System.Linq.Enumerable.Single(source);

            // Act
            var result = ArrayExtensions
                .Single<int>((ReadOnlySpan<int>)source.AsSpan());

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
            var result = ArrayExtensions
                .Single<int>((ReadOnlySpan<int>)source.AsSpan());

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Empty_Must_Return_None(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Single_Must_Return_Some(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(source, predicate.AsFunc());

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Multiple_Must_Return_None(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Empty_Must_Return_None(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Single_Must_Return_Some(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Multiple_Must_Return_None(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        public void Single_Selector_With_Empty_Must_Return_None(int[] source, Selector<int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Select<int, string>((ReadOnlySpan<int>)source.AsSpan(), selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        public void Single_Selector_With_Single_Must_Return_Some(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Select<int, string>((ReadOnlySpan<int>)source.AsSpan(), selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Single_Selector_With_Multiple_Must_Return_None(int[] source, Selector<int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Select<int, string>((ReadOnlySpan<int>)source.AsSpan(), selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Empty_Must_Return_None(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Select<int, string>((ReadOnlySpan<int>)source.AsSpan(), selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Single_Must_Return_Some(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Select<int, string>((ReadOnlySpan<int>)source.AsSpan(), selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Multiple_Must_Return_None(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Select<int, string>((ReadOnlySpan<int>)source.AsSpan(), selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Empty_Must_Return_None(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Single_Must_Return_Some(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Multiple_Must_Return_None(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }
    }
}