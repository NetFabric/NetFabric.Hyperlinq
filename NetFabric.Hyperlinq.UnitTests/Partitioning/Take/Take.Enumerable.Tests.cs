using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Take), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            var enumerable = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.Take<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(enumerable, count);

            // Assert
            result.Should().Generate(expected);
        }
    }
}