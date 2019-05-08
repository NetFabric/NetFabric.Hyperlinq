using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Take), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            var list = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.Take<Wrap.ReadOnlyList<int>, int>(list, count);

            // Assert
            result.Should().Generate(expected);
        }
    }
}