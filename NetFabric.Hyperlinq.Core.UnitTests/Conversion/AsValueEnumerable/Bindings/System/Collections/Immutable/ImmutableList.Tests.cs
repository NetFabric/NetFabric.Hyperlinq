using NetFabric.Assertive;
using System.Collections.Immutable;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Immutable
{
    public class ImmutableListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ImmutableList_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = source.ToImmutableList();

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableList<int>, ImmutableList<int>.Enumerator, ImmutableList<int>.Enumerator, int, ImmutableListExtensions.GetEnumerator<int>, ImmutableListExtensions.GetEnumerator<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
