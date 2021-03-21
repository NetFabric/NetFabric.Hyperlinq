using NetFabric.Assertive;
using System.Buffers;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct.ReadOnlyList
{
    public class Tests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = source
                .Skip(skip)
                .Take(take)
                .Distinct();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Distinct();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Distinct_Sum_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = source
                .Skip(skip)
                .Take(take)
                .Distinct()
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Distinct()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }

    public class DistinctEnumerableTests
        : ValueEnumerableTestsBase<ValueReadOnlyListExtensions.DistinctEnumerable<Wrap.ValueReadOnlyListWrapper<int>, int>,
            ValueEnumerableExtensions.SkipEnumerable<ValueReadOnlyListExtensions.DistinctEnumerable<Wrap.ValueReadOnlyListWrapper<int>, int>, ValueReadOnlyListExtensions.DistinctEnumerable<Wrap.ValueReadOnlyListWrapper<int>, int>.Enumerator, int>,
            ValueEnumerableExtensions.TakeEnumerable<ValueReadOnlyListExtensions.DistinctEnumerable<Wrap.ValueReadOnlyListWrapper<int>, int>, ValueReadOnlyListExtensions.DistinctEnumerable<Wrap.ValueReadOnlyListWrapper<int>, int>.Enumerator, int>>
    {
        public DistinctEnumerableTests() 
            : base(array => Wrap.AsValueReadOnlyList(array).AsValueEnumerable().Distinct())
        {}
    }
}
