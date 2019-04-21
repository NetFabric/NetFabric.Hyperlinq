using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleTests
    {
        [Fact]
        public void Single_With_EmptyIEnumerable_Should_Throw()
        {
            // Arrange
            var empty = TestEnumerable.ValueType(0);

            // Act
            Action action = () => empty.Single();

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Fact]
        public void Single_With_MoreThanElement_Should_Throw()
        {
            // Arrange
            var empty = TestEnumerable.ValueType(2);

            // Act
            Action action = () => empty.Single();

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains more than one element");
        }

        public static TheoryData<int[], int> SingleData =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1 }, 1 }, 
                { new int[] { 5 }, 5 },
            };

        [Theory]
        [MemberData(nameof(SingleData))]
        public void Single_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.Single();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SingleData))]
        public void Single_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.Single();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SingleData))]
        public void Single_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.Single();

            // Assert
            result.Should().Be(expected);
        }

        public static TheoryData<int[], Func<int, int, bool>, int> SinglePredicateData =>
            new TheoryData<int[], Func<int, int, bool>, int>
            {
                { new int[] { 1 }, (_, __) => true, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, (value, _) => value == 5, 5 },
            };


        [Theory]
        [MemberData(nameof(SinglePredicateData))]
        public void SinglePredicate_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, Func<int, int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.Single(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SinglePredicateData))]
        public void SinglePredicate_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, Func<int, int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.Single(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SinglePredicateData))]
        public void SinglePredicate_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, Func<int, int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.Single(predicate);

            // Assert
            result.Should().Be(expected);
        }

    }
}