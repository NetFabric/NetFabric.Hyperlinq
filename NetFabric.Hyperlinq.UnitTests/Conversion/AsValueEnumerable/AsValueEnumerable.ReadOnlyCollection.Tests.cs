using NetFabric.Assertive;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public class ReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.CollectionValueEnumerable<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ToArray_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<int>(wrapped)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_Collection_With_ToArray_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsCollection(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<int>(wrapped)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ToList_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<int>(wrapped)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_Collection_With_ToList_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsCollection(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<int>(wrapped)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        //////////

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_GetEnumerator_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<Wrap.ReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, enumerable => enumerable.GetEnumerator());

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.CollectionValueEnumerable<Wrap.ReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int, FunctionWrapper<Wrap.ReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>>>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_GetEnumerator_With_ToArray_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<Wrap.ReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, enumerable => enumerable.GetEnumerator())
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_GetEnumerator_Collection_With_ToArray_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsCollection(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<Wrap.CollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, enumerable => enumerable.GetEnumerator())
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_GetEnumerator_With_ToList_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<Wrap.ReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, enumerable => enumerable.GetEnumerator())
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_GetEnumerator_Collection_With_ToList_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsCollection(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = ReadOnlyCollectionExtensions
                .AsValueEnumerable<Wrap.CollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, enumerable => enumerable.GetEnumerator())
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}