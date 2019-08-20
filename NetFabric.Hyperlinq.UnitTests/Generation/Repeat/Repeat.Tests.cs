using FluentAssertions;
using System;
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
            Action action = () => ValueEnumerable.Repeat(0, count);

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
            Func<int> action = () => ValueEnumerable.Repeat(0, count)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }
  
  
        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_With_ValidData_Should_Succeed(int value, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Repeat(value, count);

            // Act
            var result = ValueEnumerable.Repeat(value, count);

            // Assert
            Utils.ValueReadOnlyList.ShouldEqual<
                ValueEnumerable.RepeatEnumerable<int>,
                ValueEnumerable.RepeatEnumerable<int>.Enumerator,
                int>(result, expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat_SkipTake), MemberType = typeof(TestData))]
        public void Repeat_Skip_With_ValidData_Should_Succeed(int value, int count, int skipCount)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Skip(System.Linq.Enumerable.Repeat(value, count), skipCount);

            // Act
            var result = ValueEnumerable.Repeat(value, count).Skip(skipCount);

            // Assert
            Utils.ValueReadOnlyList.ShouldEqual<
                ValueEnumerable.RepeatEnumerable<int>,
                ValueEnumerable.RepeatEnumerable<int>.Enumerator,
                int>(result, expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat_SkipTake), MemberType = typeof(TestData))]
        public void Repeat_Take_With_ValidData_Should_Succeed(int value, int count, int takeCount)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Take(System.Linq.Enumerable.Repeat(value, count), takeCount);

            // Act
            var result = ValueEnumerable.Repeat(value, count).Take(takeCount);

            // Assert
            Utils.ValueReadOnlyList.ShouldEqual<
                ValueEnumerable.RepeatEnumerable<int>,
                ValueEnumerable.RepeatEnumerable<int>.Enumerator,
                int>(result, expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_All_With_ValidData_Should_Succeed(int value, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.All(System.Linq.Enumerable.Repeat(value, count), item => false);

            // Act
            var result = ValueEnumerable.Repeat(value, count).All(item => false);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_Any_With_ValidData_Should_Succeed(int value, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Any(System.Linq.Enumerable.Repeat(value, count));

            // Act
            var result = ValueEnumerable.Repeat(value, count).Any();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_ToArray_With_ValidData_Should_Succeed(int value, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Repeat(value, count));

            // Act
            var result = ValueEnumerable.Repeat(value, count).ToArray();

            // Assert
            result.Should().Equals(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_ToList_With_ValidData_Should_Succeed(int value, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Repeat(value, count));

            // Act
            var result = ValueEnumerable.Repeat(value, count).ToList();

            // Assert
            result.Should().Equals(expected);
        }
    }
}