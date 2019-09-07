using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToListArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToList_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = System.Linq.Enumerable.ToList(source);

            // Act
            var result = Array.ToList(source);

            // Assert
            result.Should()
                .BeOfType<List<int>>().And
                .NotBeSameAs(source).And
                .Equal(expected);
        }
    }
}