using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstOrDefaultTests
    {
        [Fact]
        public void FirstOrDefault_With_NullSource_Should_Throw()
        {
            // Arrange

            // Act
            Action action = () => Enumerable.FirstOrDefault<IEnumerable<int>, IEnumerator<int>, int>(null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("source");
        }

        public static TheoryData<int[], int> FirstOrDefaultData =>
            new TheoryData<int[], int>
            {
                { new int[] { }, 0 },
                { new int[] { 1 }, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1 },
            };

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

        public static TheoryData<int[], Func<int, bool>, int> FirstOrDefaultPredicateData =>
            new TheoryData<int[], Func<int, bool>, int>
            {
                { new int[] { }, _ => true, 0 },
                { new int[] { 1 }, _ => true, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, _ => true, 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, value => value > 5, 6 },
            };


        [Theory]
        [MemberData(nameof(FirstOrDefaultPredicateData))]
        public void FirstOrDefaultPredicate_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstOrDefaultPredicateData))]
        public void FirstOrDefaultPredicate_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(FirstOrDefaultPredicateData))]
        public void FirstOrDefaultPredicate_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = source.FirstOrDefault(predicate);

            // Assert
            result.Should().Be(expected);
        }

    }
}