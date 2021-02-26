using NetFabric.Assertive;
using System.Collections.Immutable;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Immutable
{
    public class ImmutableArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ImmutableArray_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = source.ToImmutableArray();

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyListExtensions.ListValueEnumerable<int>>()
//                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableArray<int>, ValueEnumerator<int>, ImmutableArray<int>.Enumerator, int, ImmutableArrayExtensions.GetEnumerator<int>, ImmutableArrayExtensions.GetEnumerator2<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
        }
    }
}
