using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.SingleOrDefault
{
    public class ReadOnlyMemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Empty_Or_Single_Must_Succeed(int[] source)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.SingleOrDefault(source);

            // Act
            ref readonly var result = ref Array
                .SingleOrDefault<int>((ReadOnlyMemory<int>)source.AsMemory());

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Multiple_Must_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .SingleOrDefault<int>((ReadOnlyMemory<int>)source.AsMemory());

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Predicate_With_Empty_Or_Single_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.SingleOrDefault(source, predicate.AsFunc());

            // Act
            ref readonly var result = ref Array
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Predicate_With_Multiple_Must_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_PredicateAt_With_Empty_Or_Single_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            ref readonly var result = ref Array
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_PredicateAt_With_Multiple_Must_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Selector_With_Empty_Or_Single_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = Array
                .Select<int, string>((ReadOnlyMemory<int>)source.AsMemory(), selector)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Selector_With_Multiple_Must_Throw(int[] source, Selector<int, string> selector)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Select<int, string>((ReadOnlyMemory<int>)source.AsMemory(), selector)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_SelectorAt_With_Empty_Or_Single_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = Array
                .Select<int, string>((ReadOnlyMemory<int>)source.AsMemory(), selector)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_SelectorAt_With_Multiple_Must_Throw(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Select<int, string>((ReadOnlyMemory<int>)source.AsMemory(), selector)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Predicate_Selector_With_Empty_Or_Single_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = Array
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .Select(selector)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Predicate_Selector_With_Multiple_Must_Throw(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .Select(selector)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }
    }
}