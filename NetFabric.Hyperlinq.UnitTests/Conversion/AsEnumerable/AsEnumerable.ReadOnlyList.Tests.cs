using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsEnumerableReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void AsEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.AsEnumerable<Wrap.ReadOnlyList<int>, int>(wrapped);

            // Assert
            result.Should().Equal(source);
        }
    }
}