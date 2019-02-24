using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeTests
    {
        public static TheoryData<int[], int, int[]> IEnumerableData =>
            new TheoryData<int[], int, int[]> 
            {
                { new int[] {}, 0,  new int[] {} },
                { new int[] {}, 5,  new int[] {} },
                { new int[] { 0 }, 0,  new int[] {} },
                { new int[] { 0 }, -1,  new int[] {} },
                { new int[] { 0 }, 1,  new int[] { 0 } },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5,  new int[] { 0, 1, 2, 3, 4 }},
            };

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Take_With_ValidIEnumerable_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            Span<int> span = source;

            // Act
            var result = span.Take(count);

            // Assert
            result.SequenceCompareTo(expected).Should().Be(0);
        }
    }
}