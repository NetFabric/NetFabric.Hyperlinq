using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        public void First_With_Empty_Should_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action action = () => ValueReadOnlyCollection.First<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void FirstPredicate_With_Empty_Should_Throw(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action action = () => ValueReadOnlyCollection.First<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SingleSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SingleMultiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.First(wrapped);

            // Act
            var result = ValueReadOnlyCollection.First<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void FirstPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.First(wrapped, predicate);

            // Act
            var result = ValueReadOnlyCollection.First<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}