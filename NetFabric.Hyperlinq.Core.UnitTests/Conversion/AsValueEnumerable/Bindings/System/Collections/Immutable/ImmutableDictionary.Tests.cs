using NetFabric.Assertive;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Immutable
{
    public class ImmutableDictionaryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ImmutableDictionary_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = source.ToImmutableDictionary(item => item, default);

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableDictionary<int, int>, ImmutableDictionary<int, int>.Enumerator, ImmutableDictionary<int, int>.Enumerator, KeyValuePair<int, int>, ImmutableDictionaryExtensions.GetEnumerator<int, int>, ImmutableDictionaryExtensions.GetEnumerator<int, int>>>()
                .BeEnumerableOf<KeyValuePair<int, int>>()
                .BeEqualTo(wrapped);
        }
    }
}
