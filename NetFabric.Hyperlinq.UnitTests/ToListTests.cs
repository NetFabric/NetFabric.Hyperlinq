using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToListTests
    {
        public static TheoryData<int, int, List<int>> RangeData =>
            new TheoryData<int, int, List<int>> 
            {
                { 0, 0, new List<int>(new int[] {}) },
                { 0, 1, new List<int>(new int[] { 0 })  },
                { 0, 10, new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }) },
                { 5, 5, new List<int>(new int[] { 5, 6, 7, 8, 9 }) },
            };

        [Theory]
        [MemberData(nameof(RangeData))]
        public void ToList_With_ValidArgs_Should_Succeed(int start, int count, List<int> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).ToList();

            // Assert
            result.Should().Equal(expected);
        }
    }
}