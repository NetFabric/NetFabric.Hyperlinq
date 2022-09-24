using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Generation.ValueEnumerableTests
{
    public class RangeTests
    {
        [Theory]
        [InlineData(-1)]
        public void Range_With_NegativeCount_Must_Throw(int count)
        {
            // Arrange

            // Act
            Action action = () => _ = ValueEnumerable.Range(0, count);

            // Assert
            _ = action.Must()
                .Throw<ArgumentOutOfRangeException>()
                .EvaluateTrue(exception => exception.ParamName == "count");
        }

        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ValidData_Must_Succeed(int start, int count)
        {
            // Arrange
            var expected = Enumerable.Range(start, count);

            // Act
            var result = ValueEnumerable.Range(start, count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range_SkipTake), MemberType = typeof(TestData))]
        public void Range_Skip_With_ValidData_Must_Succeed(int start, int count, int skip)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).Skip(skip);

            // Act
            var result = ValueEnumerable.Range(start, count).Skip(skip);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range_SkipTake), MemberType = typeof(TestData))]
        public void Range_Take_With_ValidData_Must_Succeed(int start, int count, int take)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).Take(take);

            // Act
            var result = ValueEnumerable.Range(start, count).Take(take);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_Any_With_ValidData_Must_Succeed(int start, int count)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).Any();

            // Act
            var result = ValueEnumerable.Range(start, count).Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range_Contains), MemberType = typeof(TestData))]
        public void Range_Contains_With_ValidData_Must_Succeed(int start, int count, int value)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).Contains(value);

            // Act
            var result = ValueEnumerable.Range(start, count).Contains(value);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_ToArray_With_ValidData_Must_Succeed(int start, int count)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).ToArray();

            // Act
            var result = ValueEnumerable.Range(start, count).ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ToList_Must_Succeed(int start, int count)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).ToList();

            // Act
            var result = ValueEnumerable.Range(start, count).ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }


        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_SelectVector_Sum_Must_Succeed(int start, int count)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).Select(item => item * 2).Sum();

            // Act
            var result = ValueEnumerable.Range(start, count).SelectVector(item => item * 2, item => item * 2).Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }


        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_SelectVector_ToArray_Must_Succeed(int start, int count)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).Select(item => item * 2).ToArray();

            // Act
            var result = ValueEnumerable.Range(start, count).SelectVector(item => item * 2, item => item * 2).ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_SelectVector_ToList_Must_Succeed(int start, int count)
        {
            // Arrange
            var expected = Enumerable.Range(start, count).Select(item => item * 2).ToList();

            // Act
            var result = ValueEnumerable.Range(start, count).SelectVector(item => item * 2, item => item * 2).ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}