using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToArrayArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = System.Linq.Enumerable.ToArray(source);

            // Act
            var result = Array.ToArray(source);

            // Assert
            result.Should()
                .BeOfType<int[]>().And
                .NotBeSameAs(source).And
                .Equal(expected);
        }
    }
}