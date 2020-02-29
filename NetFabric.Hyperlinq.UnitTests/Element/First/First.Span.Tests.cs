using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.First
{
    public class SpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void First_With_Empty_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .First<int>(source.AsSpan());

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(source);

            // Act
            ref readonly var result = ref Array
                .First<int>(source.AsSpan());

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public void First_Predicate_With_Empty_Should_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .Where<int>(source.AsSpan(), predicate)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void First_Predicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(source, predicate.AsFunc());

            // Act
            ref readonly var result = ref Array
                .Where<int>(source.AsSpan(), predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_Empty_Should_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .Where<int>(source.AsSpan(), predicate)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_ValidData_Should_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            ref readonly var result = ref Array
                .Where<int>(source.AsSpan(), predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}