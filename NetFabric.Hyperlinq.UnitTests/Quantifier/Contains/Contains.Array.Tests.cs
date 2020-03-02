using System;
using System.Collections.Generic;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Contains
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_Null_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Contains(source, value, null);

            // Act
            var result = Array
                .Contains<int>(source, value, null);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_Comparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Contains(source, value, EqualityComparer<int>.Default);

            // Act
            var result = Array
                .Contains<int>(source, value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}