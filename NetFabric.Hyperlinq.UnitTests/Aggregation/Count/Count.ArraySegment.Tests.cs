using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Count
{
    public class ArraySegmentTests
    {
        [Fact]
        public void Count_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = source.AsValueEnumerable()
                .Count();

            // Assert
            _ = result.Must()
                .BeEqualTo(0);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .Count(wrapped);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Count();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Count_Predicate_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Count(predicate);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .Count();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void Count_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate)
                .Count();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .Count();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}