using NetFabric.Assertive;
using System.Collections.Immutable;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Immutable
{
    public class ImmutableQueueTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ImmutableQueue_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = ImmutableQueue.Create(source);

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<EnumerableExtensions.ValueEnumerable<ImmutableQueue<int>, ValueEnumerator<int>, ImmutableQueue<int>.Enumerator, int, ImmutableQueueExtensions.GetEnumerator<int>, ImmutableQueueExtensions.GetEnumerator2<int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
