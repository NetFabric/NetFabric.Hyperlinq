using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class RangeTests
    {
        [Theory]
        [InlineData(-1)]
        public void Range_With_NegativeCount_Should_Throw(int count)
        {
            // Arrange

            // Act
            Action action = () => ValueEnumerable.Range(0, count);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentOutOfRangeException>()
                .And
                .ParamName.Should()
                    .Be("count");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, -1)]
        public void Indexer_With_IndexOutOfRange_Should_Throw(int count, int index)
        {
            // Arrange

            // Act
            Func<int> action = () => ValueEnumerable.Range(0, count)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ValidData_Should_Succeed(int start, int count, int[] expected)
        {
            // Arrange

            // Act
            var result = ValueEnumerable.Range(start, count);

            // Assert
            result.Should().Generate(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeSkip), MemberType = typeof(TestData))]
        public void Range_With_Skip_Should_Succeed(int start, int count, int skipCount, int[] expected)
        {
            // Arrange

            // Act
            var result = ValueEnumerable.Range(start, count).Skip(skipCount);

            // Assert
            result.Should().Generate(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeTake), MemberType = typeof(TestData))]
        public void Range_With_Take_Should_Succeed(int start, int count, int takeCount, int[] expected)
        {
            // Arrange

            // Act
            var result = ValueEnumerable.Range(start, count).Take(takeCount);

            // Assert
            result.Should().Generate(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeSkipTake), MemberType = typeof(TestData))]
        public void Range_With_SkipTake_Should_Succeed(int start, int count, int skipCount, int takeCount, int[] expected)
        {
            // Arrange

            // Act
            var result = ValueEnumerable.Range(start, count).Skip(skipCount).Take(takeCount);

            // Assert
            result.Should().Generate(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ToArray_Should_Succeed(int start, int count, int[] expected)
        {
            // Arrange

            // Act
            var result = ValueEnumerable.Range(start, count).ToArray();

            // Assert
            result.Should().Equal(expected as int[]);
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ToList_Should_Succeed(int start, int count, int[] expected)
        {
            // Arrange

            // Act
            var result = ValueEnumerable.Range(start, count).ToList();

            // Assert
            result.Should().Equal(new List<int>(expected));
        }
    }
}