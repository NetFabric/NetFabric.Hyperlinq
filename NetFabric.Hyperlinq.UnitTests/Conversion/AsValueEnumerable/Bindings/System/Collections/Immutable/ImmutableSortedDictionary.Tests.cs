using NetFabric.Assertive;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Immutable
{
    public class ImmutableSortedDictionaryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ImmutableSortedDictionry_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var dictionary = source.ToDictionary(item => item);
            var wrapped = ImmutableSortedDictionary.CreateRange(default, dictionary);

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableSortedDictionary<int, int>, ImmutableSortedDictionary<int, int>.Enumerator, ImmutableSortedDictionary<int, int>.Enumerator, KeyValuePair<int, int>, ImmutableSortedDictionaryExtensions.GetEnumerator<int, int>, ImmutableSortedDictionaryExtensions.GetEnumerator<int, int>>>()
                .BeEnumerableOf<KeyValuePair<int, int>>()
                .BeEqualTo(wrapped);
        }
    }
}
