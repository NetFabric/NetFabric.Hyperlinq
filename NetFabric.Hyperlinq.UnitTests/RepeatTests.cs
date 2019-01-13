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
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Repeat_With_Value_Should_Succeed(int value)
        {
            // Arrange

            // Act
            var result = Enumerable.Repeat(value);

            // Assert
            using(var enumerator = result.GetEnumerator())
            {
                for(var index = 0; index < 10; index++)
                {
                    enumerator.MoveNext().Should().BeTrue();
                    enumerator.Current.Should().Be(value);
                    result[index].Should().Be(value);
                }
            }
        } 
        public static TheoryData<int, int, IReadOnlyList<int>> RepeatCountData =>
            new TheoryData<int, int, IReadOnlyList<int>> 
            {
                { 0, 0, new int[] {} },
                { 0, 1, new int[] { 0 } },
                { 0, 10, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
                { 10, 10, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 } },
            };

        [Theory]
        [MemberData(nameof(RepeatCountData))]
        public void Repeat_With_ValueAndValidCount_Should_Succeed(int value, int count, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Repeat(value, count);

            // Assert
            result.Count.Should().Be(expected.Count);
            result.Should().Equal(expected);
            for(var index = 0; index < result.Count; index++)
                result[index].Should().Be(expected[index]);
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
            Func<int> action = () => Enumerable.Repeat(0, count)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }
  
    }
}