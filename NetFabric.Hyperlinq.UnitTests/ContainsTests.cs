using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ContainsTests
    {
        [Fact]
        public void Contains_With_NullSource_Should_Throw()
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Contains<IEnumerable<int>, IEnumerator<int>, int>(null, 0);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("source");
        }

        public static TheoryData<int[], int, bool> ContainsData =>
            new TheoryData<int[], int, bool>
            {
                { new int[] { }, 1, false },
                { new int[] { 1 }, 1, true },
                { new int[] { 1 }, 2, false },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1, true },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5, true },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9, true },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 10, false },
            };

        [Theory]
        [MemberData(nameof(ContainsData))]
        public void Contains_With_ValidIEnumerable_Should_Succeed(IEnumerable<int> source, int value, bool expected)
        {
            // Arrange

            // Act
            var result = source.Contains(value);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(ContainsData))]
        public void Contains_With_ValidIReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, int value, bool expected)
        {
            // Arrange

            // Act
            var result = source.Contains(value);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(ContainsData))]
        public void Contains_With_ValidIReadOnlyList_Should_Succeed(IReadOnlyList<int> source, int value, bool expected)
        {
            // Arrange

            // Act
            var result = source.Contains(value);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Test()
        {
            // Arrange
            IEnumerable<int> source = new List<int>(new[] { 0, 1, 2, 3, 4, 5 });

            // Act
            var result = source.Contains(2);

            // Assert
            result.Should().Be(true);
        }

    }
}