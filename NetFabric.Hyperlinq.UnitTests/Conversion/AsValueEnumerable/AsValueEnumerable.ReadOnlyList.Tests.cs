using NetFabric.Assertive;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .AsValueEnumerable(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyListExtensions.ValueEnumerableWrapper<int>>()
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
                .AsReadOnlyList(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = ReadOnlyListExtensions
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
                .AsList(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = ReadOnlyListExtensions
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
                .AsReadOnlyList(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = ReadOnlyListExtensions
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
                .AsList(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = ReadOnlyListExtensions
                .AsValueEnumerable<int>(wrapped)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}