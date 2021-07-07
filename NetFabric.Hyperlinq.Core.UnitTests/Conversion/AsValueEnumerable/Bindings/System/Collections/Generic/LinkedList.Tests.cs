using NetFabric.Assertive;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Generic
{
    public class LinkedListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_LinkedList_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = new LinkedList<int>(source);

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<LinkedList<int>, LinkedList<int>.Enumerator, LinkedList<int>.Enumerator, int, LinkedListExtensions.GetEnumerator<int>, LinkedListExtensions.GetEnumerator<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
