using NetFabric.Assertive;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public class EnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsEnumerable(source);

            // Act
            var result = EnumerableExtensions
                .AsValueEnumerable(wrapped);

            // Assert
            _ = result.Must()
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
                .AsEnumerable(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = EnumerableExtensions
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
                .AsEnumerable(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = EnumerableExtensions
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
        public void AsValueEnumerable_GetEnumerator_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsEnumerable(source);

            // Act
            var result = EnumerableExtensions
                .AsValueEnumerable<Wrap.EnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, enumerable => enumerable.GetEnumerator());

            // Assert
            _ = result.Must()
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
                .AsEnumerable(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = EnumerableExtensions
                .AsValueEnumerable<Wrap.EnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, enumerable => enumerable.GetEnumerator())
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
                .AsEnumerable(source);
            var expected = Enumerable
                .ToList(source);

            // Act
            var result = EnumerableExtensions
                .AsValueEnumerable<Wrap.EnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, enumerable => enumerable.GetEnumerator())
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}