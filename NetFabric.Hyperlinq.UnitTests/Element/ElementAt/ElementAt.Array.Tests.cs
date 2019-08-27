using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ElementAtArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.ElementAtOutOfRange), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Should_Throw(int[] source, int index)
        {
            // Arrange

            // Act
            Action action = () => Array.ElementAt<int>(source, index);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var expected = System.Linq.Enumerable.ElementAt(source, index);

            // Act
            var result = Array.ElementAt<int>(source, index);

            // Assert
            result.Should().Be(expected);
        }
    }
}