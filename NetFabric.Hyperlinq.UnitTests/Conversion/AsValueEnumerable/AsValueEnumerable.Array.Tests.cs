using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var result = Array.AsValueEnumerable<int>(source);

            // Assert
            result.Should().Generate(source);
        }
    }
}