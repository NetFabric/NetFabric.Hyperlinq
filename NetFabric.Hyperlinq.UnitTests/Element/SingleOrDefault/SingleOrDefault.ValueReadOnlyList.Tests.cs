using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleOrDefaultValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.SingleOrDefault(wrapped);

            // Act
            var result = ValueReadOnlyList
                .SingleOrDefault<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped);

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
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.SingleOrDefault(wrapped, predicate);

            // Act
            var result = ValueReadOnlyList
                .SingleOrDefault<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Multiple_Should_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => ValueReadOnlyList
                .SingleOrDefault<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped);

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
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => ValueReadOnlyList
                .SingleOrDefault<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }         
    }
}