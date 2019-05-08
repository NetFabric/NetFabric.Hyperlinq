using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Skip), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            var list = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.Skip<Wrap.ReadOnlyList<int>, int>(list, count);

            // Assert
            result.Should().Generate(expected);
        }
    }
}