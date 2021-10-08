using NetFabric.Assertive;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Bindings.System.Collections.Generic
{
    public class DictionaryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_Dictionary_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = source.ToDictionary(item => item);

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<Dictionary<int, int>, Dictionary<int, int>.Enumerator, Dictionary<int, int>.Enumerator, KeyValuePair<int, int>, DictionaryExtensions.GetEnumerator<int, int>, DictionaryExtensions.GetEnumerator<int, int>>>()
                .BeEnumerableOf<KeyValuePair<int, int>>()
                .BeEqualTo(wrapped);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_Dictionary_KeyCollection_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = source.ToDictionary(item => item).Keys;

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<Dictionary<int, int>.KeyCollection, Dictionary<int, int>.KeyCollection.Enumerator, Dictionary<int, int>.KeyCollection.Enumerator, int, DictionaryExtensions.GetEnumerator<int, int>, DictionaryExtensions.GetEnumerator<int, int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_Dictionary_ValueCollection_Must_ReturnWrapper(int[] source)
        {
            // Arrange
            var wrapped = source.ToDictionary(item => item).Values;

            // Act
            var result = wrapped.AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<Dictionary<int, int>.ValueCollection, Dictionary<int, int>.ValueCollection.Enumerator, Dictionary<int, int>.ValueCollection.Enumerator, int, DictionaryExtensions.GetEnumerator<int, int>, DictionaryExtensions.GetEnumerator<int, int>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
    }
}
