using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.SingleOrDefault
{
    public class MemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_EmptyOrSingle_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.SingleOrDefault(source);

            // Act
            ref readonly var result = ref Array
                .SingleOrDefault<int>(source.AsMemory());

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Multiple_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .SingleOrDefault<int>(source.AsMemory());

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Predicate_With_EmptyOrSingle_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.SingleOrDefault(source, predicate.AsFunc());

            // Act
            ref readonly var result = ref Array
                .Where<int>(source.AsMemory(), predicate)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Predicate_With_Multiple_Should_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .Where<int>(source.AsMemory(), predicate)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_PredicateAt_With_EmptyOrSingle_Should_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            ref readonly var result = ref Array
                .Where<int>(source.AsMemory(), predicate)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_PredicateAt_With_Multiple_Should_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = ref Array
                .Where<int>(source.AsMemory(), predicate)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }
    }
}