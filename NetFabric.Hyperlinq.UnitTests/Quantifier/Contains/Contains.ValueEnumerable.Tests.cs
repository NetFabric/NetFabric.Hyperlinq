using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ContainsValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Contains(wrapped, value);

            // Act
            var result = ValueEnumerable.Contains<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, value);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_And_Comparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Contains(wrapped, value, EqualityComparer<int>.Default);

            // Act
            var result = ValueEnumerable.Contains<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, value, EqualityComparer<int>.Default);

            // Assert
            result.Should().Be(expected);
        }    

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_And_NullComparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Contains(wrapped, value, null);

            // Act
            var result = ValueEnumerable.Contains<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, value, null);

            // Assert
            result.Should().Be(expected);
        }  
    }
}