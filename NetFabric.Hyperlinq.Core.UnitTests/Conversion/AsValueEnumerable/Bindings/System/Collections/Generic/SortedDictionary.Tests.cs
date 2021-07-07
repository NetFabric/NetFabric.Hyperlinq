using NetFabric.Assertive;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Generic
{
    public class SortedDictionaryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_SortedDictionary_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = new SortedDictionary<int, int>(source.ToDictionary(item => item));

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<SortedDictionary<int, int>, SortedDictionary<int, int>.Enumerator, SortedDictionary<int, int>.Enumerator, KeyValuePair<int, int>, SortedDictionaryExtensions.GetEnumerator<int, int>, SortedDictionaryExtensions.GetEnumerator<int, int>>>()
                .BeEnumerableOf<KeyValuePair<int, int>>()
                .BeEqualTo(wrapped);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_SortedDictionary_KeyCollection_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = new SortedDictionary<int, int>(source.ToDictionary(item => item)).Keys;

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<SortedDictionary<int, int>.KeyCollection, SortedDictionary<int, int>.KeyCollection.Enumerator, SortedDictionary<int, int>.KeyCollection.Enumerator, int, SortedDictionaryExtensions.GetEnumerator<int, int>, SortedDictionaryExtensions.GetEnumerator<int, int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_SortedDictionary_ValueCollection_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = new SortedDictionary<int, int>(source.ToDictionary(item => item)).Values;

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<SortedDictionary<int, int>.ValueCollection, SortedDictionary<int, int>.ValueCollection.Enumerator, SortedDictionary<int, int>.ValueCollection.Enumerator, int, SortedDictionaryExtensions.GetEnumerator<int, int>, SortedDictionaryExtensions.GetEnumerator<int, int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
