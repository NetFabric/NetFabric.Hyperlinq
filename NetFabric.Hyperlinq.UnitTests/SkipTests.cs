using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTests
    {
        public static TheoryData<int[], int, int[]> IEnumerableData =>
            new TheoryData<int[], int, int[]> 
            {
                { new int[] {}, 0,  new int[] {} },
                { new int[] {}, 5,  new int[] {} },
                { new int[] { 0 }, 0,  new int[] { 0 } },
                { new int[] { 0 }, -1,  new int[] { 0 } },
                { new int[] { 0 }, 1,  new int[] { } },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1,  new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0,  new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5,  new int[] { 5, 6, 7, 8, 9 }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2,  new int[] { 2, 3, 4, 5, 6, 7, 8, 9 }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 8,  new int[] { 8, 9 }},
            };

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Skip_With_ValidIEnumerable_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            Span<int> span = source;

            // Act
            var result = span.Skip(count);

            // Assert
            result.SequenceCompareTo(expected).Should().Be(0);
        }
    }
}