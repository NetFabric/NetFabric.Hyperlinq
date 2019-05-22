using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Count), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Should_Succeed(int[] source, int expected)
        {
            // Arrange

            // Act
            var result = Array.Count<int>(source);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.CountPredicate), MemberType = typeof(TestData))]
        public void CountPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = Array.Count<int>(source, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}