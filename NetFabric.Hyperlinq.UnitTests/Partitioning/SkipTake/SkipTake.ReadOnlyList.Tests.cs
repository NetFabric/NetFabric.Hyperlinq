using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTakeReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTake), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount, int[] expected)
        {
            // Arrange
            var list = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.SkipTake<Wrap.ReadOnlyList<int>, int>(list, skipCount, takeCount);

            // Assert
            result.Should().Generate(expected);
        }
    }
}