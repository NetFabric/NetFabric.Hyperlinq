using NetFabric.Assertive;
using System.Buffers;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct.ValueEnumerable
{
    public class Tests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = source
                .Distinct();

            // Act
            var result = wrapped
                .Distinct<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = source
                .Distinct()
                .Sum();

            // Act
            var result = wrapped
                .Distinct<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }

    public class DistinctEnumerableTests
        : ValueEnumerableTestsBase<ValueEnumerableExtensions.DistinctEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>,
            ValueEnumerableExtensions.SkipEnumerable<ValueEnumerableExtensions.DistinctEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>, ValueEnumerableExtensions.DistinctEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>.Enumerator, int>,
            ValueEnumerableExtensions.TakeEnumerable<ValueEnumerableExtensions.DistinctEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>, ValueEnumerableExtensions.DistinctEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>.Enumerator, int>>
    {
        public DistinctEnumerableTests() 
            : base(array => Wrap.AsValueEnumerable(array).AsValueEnumerable().Distinct())
        {}
    }
}
