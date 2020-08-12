using System;
using System.Buffers;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ArraySegmentTests
    {
        [Fact]
        public void ToArray_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = ArrayExtensions
                .ToArray(source);

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(Array.Empty<int>());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToArray_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .ToArray(wrapped);

            // Act
            var result = ArrayExtensions
                .ToArray(wrapped);

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToArray_MemoryPool_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var pool = MemoryPool<int>.Shared;
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .ToArray(wrapped);

            // Act
            var result = ArrayExtensions
                .ToArray(wrapped, pool);

            // Assert
            _ = result.Memory
                .SequenceEqual(expected);
        }
    }
}