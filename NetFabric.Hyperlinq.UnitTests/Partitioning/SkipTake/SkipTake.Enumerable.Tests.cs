using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTakeEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTake), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount, int[] expected)
        {
            // Arrange
            var enumerable = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.SkipTake<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(enumerable, skipCount, takeCount);

            // Assert
            result.Should().Generate(expected);
        }
    }
}