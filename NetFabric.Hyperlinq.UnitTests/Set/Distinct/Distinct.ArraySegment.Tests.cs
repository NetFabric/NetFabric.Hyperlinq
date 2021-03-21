using NetFabric.Assertive;
using System;
using System.Buffers;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct.ArraySegment
{
    public class Tests
    {
        [Fact]
        public void Distinct_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);
            var expected = Enumerable.Empty<int>();

            // Act
            var result = source.AsValueEnumerable()
                .Distinct();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Partition.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = wrapped
                .Distinct();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Distinct();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Distinct_Sum_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Partition.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = wrapped
                .Distinct()
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Distinct()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }

    public class ArraySegmentDistinctEnumerableTests
        : ValueEnumerableTestsBase<
            ArrayExtensions.ArraySegmentDistinctEnumerable<int>,
            ValueEnumerableExtensions.SkipEnumerable<ArrayExtensions.ArraySegmentDistinctEnumerable<int>, ArrayExtensions.ArraySegmentDistinctEnumerable<int>.Enumerator, int>,
            ValueEnumerableExtensions.TakeEnumerable<ArrayExtensions.ArraySegmentDistinctEnumerable<int>, ArrayExtensions.ArraySegmentDistinctEnumerable<int>.Enumerator, int>>
    {
        public ArraySegmentDistinctEnumerableTests() 
            : base(array => new ArraySegment<int>(array).AsValueEnumerable().Distinct())
        {}
    }
}
