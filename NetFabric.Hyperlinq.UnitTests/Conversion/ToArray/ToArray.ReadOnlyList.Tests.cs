using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToArrayReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.ToArray<Wrap.ReadOnlyList<int>, int>(wrapped);

            // Assert
            result.Should().Equal(source);
        }
    }
}