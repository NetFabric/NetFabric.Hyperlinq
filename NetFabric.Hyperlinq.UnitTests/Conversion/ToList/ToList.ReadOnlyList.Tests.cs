using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToListReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void ToList_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = new List<int>(source);

            // Act
            var result = ReadOnlyList.ToList<Wrap.ReadOnlyList<int>, int>(wrapped);

            // Assert
            result.Should().Equal(expected);
        }
    }
}