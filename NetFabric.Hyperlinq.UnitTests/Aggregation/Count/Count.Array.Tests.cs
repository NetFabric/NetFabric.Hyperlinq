using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Count(source);

            // Act
            var result = Array.Count<int>(source);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.CountPredicate), MemberType = typeof(TestData))]
        public void CountPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Count(source, predicate);

            // Act
            var result = Array.Count<int>(source, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}