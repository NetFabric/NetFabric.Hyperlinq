#if NET60_OR_GREATER

using NetFabric.Assertive;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Generic
{
    public class PriorityQueueTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_PriorityQueue_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = new PriorityQueue<int, int>(source.Select(item => (item, 0)));

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<PriorityQueue<int>, PriorityQueue<int>.Enumerator, PriorityQueue<int>.Enumerator, int, PriorityQueueExtensions.GetEnumerator<int>, PriorityQueueExtensions.GetEnumerator<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}

#endif
