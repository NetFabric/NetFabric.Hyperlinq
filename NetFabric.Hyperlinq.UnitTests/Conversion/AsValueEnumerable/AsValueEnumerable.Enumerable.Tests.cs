using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsValueEnumerableEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.AsValueEnumerable(wrapped);

            // Assert
            result.Should()
                .BeOfType<Enumerable.ValueEnumerableWrapper<int>>().And
                .Equals(source);
        }
    }
}