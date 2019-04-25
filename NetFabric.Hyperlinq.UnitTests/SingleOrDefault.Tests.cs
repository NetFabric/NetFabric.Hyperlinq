using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleOrDefaultTests
    {
        [Fact]
        public void Single_With_MoreThanElement_Should_Throw()
        {
            // Arrange
            var empty = TestEnumerable.ValueType(2);

            // Act
            Action action = () => empty.SingleOrDefault();

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains more than one element");
        }

        public static TheoryData<int[], int> SingleOrDefaultData =>
            new TheoryData<int[], int>
            {
                { new int[] { }, 0 },
                { new int[] { 1 }, 1 },
                { new int[] { 5 }, 5 },
            };

        [Theory]
        [MemberData(nameof(SingleOrDefaultData))]
        public void SingleOrDefault_With_ValidArray_Should_Succeed(int[] source, int expected)
        {
            // Arrange

            // Act
            var result = source.SingleOrDefault();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SingleOrDefaultData))]
        public void SingleOrDefault_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.SingleOrDefault();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SingleOrDefaultData))]
        public void SingleOrDefault_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.SingleOrDefault();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SingleOrDefaultData))]
        public void SingleOrDefault_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.SingleOrDefault();

            // Assert
            result.Should().Be(expected);
        }

        public static TheoryData<int[], Func<int, long, bool>, int> SingleOrDefaultPredicateData =>
            new TheoryData<int[], Func<int, long, bool>, int>
            {
                { new int[] { }, (_, __) => true, 0 },
                { new int[] { 1 }, (_, __) => true, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, (value, _) => value == 5, 5 },
            };


        [Theory]
        [MemberData(nameof(SingleOrDefaultPredicateData))]
        public void SingleOrDefaultPredicate_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.SingleOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SingleOrDefaultPredicateData))]
        public void SingleOrDefaultPredicate_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.SingleOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(SingleOrDefaultPredicateData))]
        public void SingleOrDefaultPredicate_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.SingleOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

    }
}