using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class RepeatTests
    {
        [Theory]
        [InlineData(-1)]
        public void Repeat_With_NegativeCount_Should_Throw(int count)
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Repeat(0, count);

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
        public void Indexer_With_IndexOutOfRepeat_Should_Throw(int count, int index)
        {
            // Arrange

            // Act
            Func<int> action = () => Enumerable.Repeat(0, count)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }
  
  
        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_With_ValidData_Should_Succeed(int value, int count, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Repeat(value, count);

            // Assert
            result.Should().Generate(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeSkip), MemberType = typeof(TestData))]
        public void Range_With_Skip_Should_Succeed(long value, long count, long skipCount, IReadOnlyList<long> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(value, count).Skip(skipCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeTake), MemberType = typeof(TestData))]
        public void Range_With_Take_Should_Succeed(long value, long count, long takeCount, IReadOnlyList<long> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(value, count).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeSkipTake), MemberType = typeof(TestData))]
        public void Range_With_SkipTake_Should_Succeed(long value, long count, long skipCount, long takeCount, IReadOnlyList<long> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(value, count).Skip(skipCount).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
    }
}