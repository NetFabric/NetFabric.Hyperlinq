using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Should_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable
                .Single<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void SinglePredicate_With_Empty_Should_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable
                .Single<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void Single_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Single(wrapped);

            // Act
            var result = ValueEnumerable
                .Single<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        public void SinglePredicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Single(wrapped, predicate.AsFunc());

            // Act
            var result = ValueEnumerable
                .Single<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Single_With_Multiple_Should_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable
                .Single<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void SinglePredicate_With_Multiple_Should_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable
                .Single<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }
    }
}