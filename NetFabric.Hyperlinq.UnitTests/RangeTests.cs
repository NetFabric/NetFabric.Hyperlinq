using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class RangeTests
    {
        [Theory]
        [InlineData(-1)]
        public void Range_With_NegativeCount_Should_Throw(int count)
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Range(0, count);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentOutOfRangeException>()
                .And
                .ParamName.Should()
                    .Be("count");
        }

        public static TheoryData<int, int, IReadOnlyList<int>> IEnumerableData =>
            new TheoryData<int, int, IReadOnlyList<int>> 
            {
                { 0, 0, new int[] {} },
                { 0, 1, new int[] { 0 } },
                { 0, 10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
                { -2, 5, new int[] { -2, -1, 0, 1, 2 } },
            };

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Range_With_ValidEnumeration_Should_Succeed(int start, int count, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count);

            // Assert
            result.Count().Should().Be(expected.Count);
            result.AsEnumerable().Should().Equal(expected);
            for(var index = 0; index < result.Count(); index++)
                result[index].Should().Be(expected[index]);
        }      

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, -1)]
        public void Indexer_With_IndexOutOfRange_Should_Throw(int count, int index)
        {
            // Arrange

            // Act
            Func<int> action = () => Enumerable.Range(0, count)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }
  
    }
}