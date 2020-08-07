using System;
using System.Collections.Generic;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToList
{
    public class ArraySegmentTests
    {
        [Fact]
        public void ToList_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = ArrayExtensions
                .ToList(source);

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(new List<int>());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToList_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var expected = Enumerable
                .ToList(wrapped);

            // Act
            var result = ArrayExtensions
                .ToList(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}