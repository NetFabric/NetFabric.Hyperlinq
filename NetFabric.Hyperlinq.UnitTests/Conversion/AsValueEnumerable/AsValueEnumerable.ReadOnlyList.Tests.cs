using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsValueEnumerableReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.AsValueEnumerable(wrapped);

            // Assert
            result.Should().BeOfType<ReadOnlyList.ValueEnumerableWrapper<int>>();
            Utils.ValueReadOnlyList.ShouldEqual<ReadOnlyList.ValueEnumerableWrapper<int>, ReadOnlyList.ValueEnumerableWrapper<int>.Enumerator, int>(result, wrapped);
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ElementAt_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = System.Linq.Enumerable.ElementAt(wrapped, index);

            // Act
            var result = ReadOnlyList.AsValueEnumerable(wrapped).ElementAt(index);

            // Assert
            result.Should().Be(expected);
        }
    }
}