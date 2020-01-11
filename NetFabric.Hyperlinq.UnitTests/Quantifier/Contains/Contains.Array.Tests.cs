using System;
using System.Collections.Generic;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ContainsArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Contains(source, value);

            // Act
            var result = source
                .Contains<int>(value);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_And_Comparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Contains(source, value, EqualityComparer<int>.Default);

            // Act
            var result = source
                .Contains<int>(value, EqualityComparer<int>.Default);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }    

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_And_NullComparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Contains(source, value, null);

            // Act
            var result = source
                .Contains<int>(value, null);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }  
    }
}