using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstTests
    {
        [Fact]
        public void First_With_EmptyIEnumerable_Should_Throw()
        {
            // Arrange
            var empty = TestEnumerable.ValueType(0);

            // Act
            Action action = () => empty.First();

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        public static TheoryData<int[], int> FirstData =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1 }, 1 }, 
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1 },
            };

        [Theory]
        [MemberData(nameof(FirstData))]
        public void First_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.First();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstData))]
        public void First_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.First();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstData))]
        public void First_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.First();

            // Assert
            result.Should().Be(expected);
        }

        public static TheoryData<int[], Func<int, bool>, int> FirstPredicateData =>
            new TheoryData<int[], Func<int, bool>, int>
            {
                { new int[] { 1 }, _ => true, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, _ => true, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, value => value > 5, 6 },
            };


        [Theory]
        [MemberData(nameof(FirstPredicateData))]
        public void FirstPredicate_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.First(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstPredicateData))]
        public void FirstPredicate_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.First(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstPredicateData))]
        public void FirstPredicate_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.First(predicate);

            // Assert
            result.Should().Be(expected);
        }

    }
}