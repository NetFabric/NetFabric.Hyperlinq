using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.First
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void First_With_Empty_Must_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .First<int>(source);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(source);

            // Act
            ref readonly var result = ref Array
                .First<int>(source);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public void First_Predicate_With_Empty_Must_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .Where<int>(source, predicate)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void First_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(source, predicate.AsFunc());

            // Act
            ref readonly var result = ref Array
                .Where<int>(source, predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_Empty_Must_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .Where<int>(source, predicate)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            ref readonly var result = ref Array
                .Where<int>(source, predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        public void First_Selector_With_Empty_Must_Throw(int[] source, Selector<int, string> selector)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Select<int, string>(source, selector)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void First_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = Array
                .Select<int, string>(source, selector)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        public void First_SelectorAt_With_Empty_Must_Throw(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Select<int, string>(source, selector)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void First_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = Array
                .Select<int, string>(source, selector)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        public void First_Predicate_Selector_With_Empty_Must_Throw(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Where<int>(source, predicate)
                .Select(selector)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void First_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = Array
                .Where<int>(source, predicate)
                .Select(selector)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}