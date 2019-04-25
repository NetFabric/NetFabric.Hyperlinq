using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstOrDefaultTests
    {
        public static TheoryData<int[], int> FirstOrDefaultData =>
            new TheoryData<int[], int>
            {
                { new int[] { }, 0 },
                { new int[] { 1 }, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1 },
            };

        [Theory]
        [MemberData(nameof(FirstOrDefaultData))]
        public void FirstOrDefault_With_ValidArray_Should_Succeed(int[] source, int expected)
        {
            // Arrange

            // Act
            ref readonly var result = ref source.FirstOrDefault();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstOrDefaultData))]
        public void FirstOrDefault_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstOrDefaultData))]
        public void FirstOrDefault_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstOrDefaultData))]
        public void FirstOrDefault_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault();

            // Assert
            result.Should().Be(expected);
        }

        public static TheoryData<int[], Func<int, long, bool>, int> FirstOrDefaultPredicateData =>
            new TheoryData<int[], Func<int, long, bool>, int>
            {
                { new int[] { }, (_, __) => true, 0 },
                { new int[] { 1 }, (_, __) => true, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, (_, __) => true, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, (value, _) => value > 5, 6 },
            };


        [Theory]
        [MemberData(nameof(FirstOrDefaultPredicateData))]
        public void FirstOrDefaultPredicate_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstOrDefaultPredicateData))]
        public void FirstOrDefaultPredicate_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstOrDefaultPredicateData))]
        public void FirstOrDefaultPredicate_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

    }
}