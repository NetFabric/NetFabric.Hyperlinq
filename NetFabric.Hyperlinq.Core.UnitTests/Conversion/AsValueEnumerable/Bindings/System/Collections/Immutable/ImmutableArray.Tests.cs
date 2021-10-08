using NetFabric.Assertive;
using System.Collections.Immutable;
using System.Linq;
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
                .BeOfType<ArrayExtensions.ArraySegmentValueEnumerable<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped, testRefStructs: false);
            _ = result.SequenceEqual(wrapped).Must().BeTrue();
        }
    }
}
