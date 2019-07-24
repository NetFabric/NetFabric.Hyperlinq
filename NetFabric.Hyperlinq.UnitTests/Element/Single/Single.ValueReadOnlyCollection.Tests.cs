using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Should_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action action = () => ValueReadOnlyCollection.Single<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueReadOnlyCollection<int>.Enumerator, int>(wrapped);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void SinglePredicate_With_Empty_Should_Throw(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action action = () => ValueReadOnlyCollection.Single<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueReadOnlyCollection<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SingleSingle), MemberType = typeof(TestData))]
        public void Single_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.Single(wrapped);

            // Act
            var result = ValueReadOnlyCollection.Single<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueReadOnlyCollection<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        public void SinglePredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.Single(wrapped, predicate);

            // Act
            var result = ValueReadOnlyCollection.Single<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueReadOnlyCollection<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SingleMultiple), MemberType = typeof(TestData))]
        public void Single_With_Multiple_Should_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action action = () => ValueReadOnlyCollection.Single<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueReadOnlyCollection<int>.Enumerator, int>(wrapped);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void SinglePredicate_With_Multiple_Should_Throw(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action action = () => ValueReadOnlyCollection.Single<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueReadOnlyCollection<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains more than one element");
        }
    }
}