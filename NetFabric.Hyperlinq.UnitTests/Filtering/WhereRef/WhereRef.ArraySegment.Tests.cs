using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereRef
{
    public class ArraySegmentTests
    {
        [Fact]
        public void WhereRef_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);
            var function = Wrap.AsFunctionIn<int, bool>(_ => true);
            var expected = Enumerable.Empty<int>();

            // Act
            var result = ArrayExtensions
                .Where(source, function);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefReturns: false, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void WhereRef_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var function = Wrap.AsFunctionIn(predicate);
            var expected = Enumerable
                .Where(wrapped, predicate);

            // Act
            var result = ArrayExtensions
                .Where(wrapped, function);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefReturns: false, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}