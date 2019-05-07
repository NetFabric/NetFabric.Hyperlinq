using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsEnumerableEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void AsEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.AsEnumerable<Wrap.Enumerable<int>, int>(wrapped);

            // Assert
            result.Should().Equal(source);
        }
    }
}