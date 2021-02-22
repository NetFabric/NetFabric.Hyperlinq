using System;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.All
{
    public class ArraySegmentTests
    {
        [Fact]
        public void All_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = source.AsValueEnumerable()
                .All(_ => true);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void All_Predicate_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .All(wrapped, predicate);

            // Act
            var result = wrapped.AsValueEnumerable()
                .All(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void All_Skip_Take_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, int, bool> predicate)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .Where(wrapped, predicate)
                .Count() == count;

            // Act
            var result = wrapped.AsValueEnumerable()
                .All(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}