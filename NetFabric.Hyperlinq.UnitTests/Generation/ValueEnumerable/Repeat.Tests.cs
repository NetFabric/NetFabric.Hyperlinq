using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Generation.ValueEnumerableTests
{
    public class RepeatTests
    {
        [Theory]
        [InlineData(-1)]
        public void Repeat_With_NegativeCount_Must_Throw(int count)
        {
            // Arrange

            // Act
            Action action = () => _ = ValueEnumerable.Repeat(0, count);

            // Assert
            _ = action.Must()
                .Throw<ArgumentOutOfRangeException>()
                .EvaluateTrue(exception => exception.ParamName == "count");
        }


        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable.Repeat(value, count);

            // Act
            var result = ValueEnumerable.Repeat(value, count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testIndexOf: false);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat_SkipTake), MemberType = typeof(TestData))]
        public void Repeat_Skip_With_ValidData_Must_Succeed(int value, int count, int skip)
        {
            // Arrange
            var expected = Enumerable
                .Repeat(value, count)
                .Skip(skip);

            // Act
            var result = ValueEnumerable
                .Repeat(value, count)
                .Skip(skip);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testIndexOf: false);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat_SkipTake), MemberType = typeof(TestData))]
        public void Repeat_Take_With_ValidData_Must_Succeed(int value, int count, int take)
        {
            // Arrange
            var expected = Enumerable
                .Repeat(value, count)
                .Take(take);

            // Act
            var result = ValueEnumerable
                .Repeat(value, count)
                .Take(take);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testIndexOf: false);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_All_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable
                .Repeat(value, count)
                .All(item => false);

            // Act
            var result = ValueEnumerable
                .Repeat(value, count)
                .All(item => false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_Any_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable
                .Repeat(value, count)
                .Any();

            // Act
            var result = ValueEnumerable
                .Repeat(value, count)
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_ToArray_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable
                .Repeat(value, count)
                .ToArray();

            // Act
            var result = ValueEnumerable
                .Repeat(value, count)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public void Repeat_ToList_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable
                .Repeat(value, count)
                .ToList();

            // Act
            var result = ValueEnumerable
                .Repeat(value, count)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testIndexOf: false);
        }
    }
}