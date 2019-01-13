using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ReturnTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Return_With_Value_Should_Succeed(int value)
        {
            // Arrange

            // Act
            var result = Enumerable.Return(value);

            // Assert
            using(var enumerator = result.GetEnumerator())
            {   
                enumerator.MoveNext().Should().BeTrue();
                enumerator.Current.Should().Be(value);
                enumerator.MoveNext().Should().BeFalse();
            }
            result[0].Should().Be(value);
        } 

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        public void Indexer_With_IndexOutOfRange_Should_Throw(int value, int index)
        {
            // Arrange

            // Act
            Func<int> action = () => Enumerable.Return(value)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }    
    }
}