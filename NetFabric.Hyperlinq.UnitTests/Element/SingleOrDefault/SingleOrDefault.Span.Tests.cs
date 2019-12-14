using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleOrDefaultSpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.SingleOrDefault(source);

            // Act
            var result = SpanExtensions
                .SingleOrDefault<int>(source);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        public void SingleOrDefaultPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.SingleOrDefault(source, predicate);

            // Act
            var result = SpanExtensions
                .SingleOrDefault<int>(source, predicate);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Multiple_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => SpanExtensions.
                SingleOrDefault<int>(source);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefaultPredicate_With_Multiple_Should_Throw(int[] source, Func<int, bool> predicate)
        {
            // Arrange

            // Act
            Action action = () => SpanExtensions
                .SingleOrDefault<int>(source, predicate);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }         
    }
}