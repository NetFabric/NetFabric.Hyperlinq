using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountTests
    {
        [Fact]
        public void Count_With_NullSource_Should_Throw()
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Count<IEnumerable<int>, int>(null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("source");
        }

        public static TheoryData<IEnumerable<int>, int> IEnumerableData =>
            new TheoryData<IEnumerable<int>, int> 
            {
                { new int[] {}, 0 },
                { new int[] { 0 }, 1  },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 10 },
            };

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Count_IEnumerable_Should_Return_Count(IEnumerable<int> source, int expected)
        {
            // Arrange

            // Act
            var count = Enumerable.Count<IEnumerable<int>, int>(source);

            // Assert
            count.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_Range_Should_Return_Count(int expected)
        {
            // Arrange
            var range = Enumerable.Range(0, expected);

            // Act
            var count = Enumerable.Count<Enumerable.RangeEnumerable, int>(range);

            // Assert
            count.Should().Be(expected);
        }        
    }
}