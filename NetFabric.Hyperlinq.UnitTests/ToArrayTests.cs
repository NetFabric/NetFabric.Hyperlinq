using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToArrayTests
    {
        public static TheoryData<int, int, int[]> RangeData =>
            new TheoryData<int, int, int[]> 
            {
                { 0, 0, new int[] {} },
                { 0, 1, new int[] { 0 }  },
                { 0, 10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
                { 5, 5, new int[] { 5, 6, 7, 8, 9 } },
            };

        [Theory]
        [MemberData(nameof(RangeData))]
        public void ToArray_With_ValidArgs_Should_Succeed(int start, int count, int[] expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).ToArray();

            // Assert
            result.Should().Equal(expected);
        }
    }
}