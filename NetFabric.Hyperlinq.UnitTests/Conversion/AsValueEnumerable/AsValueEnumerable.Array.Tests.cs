using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsValueEnumerableArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange

            // Act
            var result = Array.AsValueEnumerable(source);

            // Assert
            result.Should()
                .BeOfType<Array.AsValueEnumerableEnumerable<int>>().And
                .Equals(source);
        }
    }
}