using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Skip), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.Skip<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(enumerable, count);

            // Assert
            result.Should().Generate(expected);
        }
    }
}