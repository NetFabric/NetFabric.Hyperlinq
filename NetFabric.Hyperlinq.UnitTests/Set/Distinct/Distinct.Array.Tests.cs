using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class DistinctArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Distinct), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Distinct(source);

            // Act
            var result = Array.Distinct<int>(source);

            // Assert
            result.Should().Equals(expected);
        }
    }
}
