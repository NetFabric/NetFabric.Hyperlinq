using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToListEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void ToList_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsEnumerable(source);
            var expected = new List<int>(source);

            // Act
            var result = Enumerable.ToList<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Equal(expected);
        }
    }
}