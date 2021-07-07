using NetFabric.Assertive;
using System.Collections.Immutable;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Immutable
{
    public class ImmutableHashSetTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ImmutableHashSet_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = source.ToImmutableHashSet();

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableHashSet<int>, ImmutableHashSet<int>.Enumerator, ImmutableHashSet<int>.Enumerator, int, ImmutableHashSetExtensions.GetEnumerator<int>, ImmutableHashSetExtensions.GetEnumerator<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
