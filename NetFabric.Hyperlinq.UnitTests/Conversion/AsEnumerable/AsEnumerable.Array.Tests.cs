using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsEnumerableArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void AsEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange

            // Act
            var result = Array.AsEnumerable<int>(source);

            // Assert
            result.Should().Equal(source);
        }
    }
}