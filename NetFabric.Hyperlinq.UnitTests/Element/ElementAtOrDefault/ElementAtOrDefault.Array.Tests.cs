using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ElementAtOrDefaultArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.ElementAtOutOfRange), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_With_OutOfRange_Should_ReturnDefault(int[] source, int index)
        {
            // Arrange

            // Act
            var result = Array.ElementAtOrDefault<int>(source, index);

            // Assert
            result.Should().Be(default);
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_With_ValidData_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var expected = System.Linq.Enumerable.ElementAtOrDefault(source, index);

            // Act
            var result = Array.ElementAtOrDefault<int>(source, index);

            // Assert
            result.Should().Be(expected);
        }
    }
}