using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class LongCountArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Count), MemberType = typeof(TestData))]
        public void LongCount_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = System.Linq.Enumerable.LongCount(source);

            // Act
            var result = Array.LongCount<int>(source);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.CountPredicate), MemberType = typeof(TestData))]
        public void LongCountPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected = System.Linq.Enumerable.LongCount(source, predicate);

            // Act
            var result = Array.LongCount<int>(source, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}