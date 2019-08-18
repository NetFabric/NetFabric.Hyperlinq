using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsValueEnumerableReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
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
    }
}