using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTakeValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTake), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount, int[] expected)
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.SkipTake<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(enumerable, skipCount, takeCount);

            // Assert
            result.Should().Generate(expected);
        }
    }
}