using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Count), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Should_Succeed(int[] source, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.Count<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.CountPredicate), MemberType = typeof(TestData))]
        public void CountPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.Count<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}