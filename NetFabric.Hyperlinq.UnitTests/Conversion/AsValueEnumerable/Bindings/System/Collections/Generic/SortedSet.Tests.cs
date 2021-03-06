using NetFabric.Assertive;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Generic
{
    public class SortedSetTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_SortedSet_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = new SortedSet<int>(source);

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<SortedSet<int>, SortedSet<int>.Enumerator, SortedSet<int>.Enumerator, int, SortedSetExtensions.GetEnumerator<int>, SortedSetExtensions.GetEnumerator<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
