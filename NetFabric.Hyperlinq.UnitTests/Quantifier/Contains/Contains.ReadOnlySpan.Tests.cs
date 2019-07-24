using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ContainsReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Contains(source, value);

            // Act
            var result = ReadOnlySpanExtensions.Contains<int>(source, value);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_And_Comparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Contains(source, value, EqualityComparer<int>.Default);

            // Act
            var result = ReadOnlySpanExtensions.Contains<int>(source, value, EqualityComparer<int>.Default);

            // Assert
            result.Should().Be(expected);
        }    

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_And_NullComparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Contains(source, value, null);

            // Act
            var result = ReadOnlySpanExtensions.Contains<int>(source, value, null);

            // Assert
            result.Should().Be(expected);
        }  
    }
}