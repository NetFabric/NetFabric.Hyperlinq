using NetFabric.Assertive;
using System;
using System.Collections.Generic;
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
            _ = action.Must()
                .Throw<ArgumentOutOfRangeException>()
                .EvaluateTrue(exception => exception.ParamName == "count");
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
            _ = action.Must().Throw<IndexOutOfRangeException>();
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ValidData_Should_Succeed(int start, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Range(start, count);

            // Act
            var result = ValueEnumerable.Range(start, count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range_SkipTake), MemberType = typeof(TestData))]
        public void Range_Skip_With_ValidData_Should_Succeed(int start, int count, int skipCount)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Skip(System.Linq.Enumerable.Range(start, count), skipCount);

            // Act
            var result = ValueEnumerable.Range(start, count).Skip(skipCount);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range_SkipTake), MemberType = typeof(TestData))]
        public void Range_Take_With_ValidData_Should_Succeed(int start, int count, int takeCount)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Take(System.Linq.Enumerable.Range(start, count), takeCount);

            // Act
            var result = ValueEnumerable.Range(start, count).Take(takeCount);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_Any_With_ValidData_Should_Succeed(int start, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Any(System.Linq.Enumerable.Range(start, count));

            // Act
            var result = ValueEnumerable.Range(start, count).Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range_Contains), MemberType = typeof(TestData))]
        public void Range_Contains_With_ValidData_Should_Succeed(int start, int count, int value)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Contains(System.Linq.Enumerable.Range(start, count), value);

            // Act
            var result = ValueEnumerable.Range(start, count).Contains(value);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_ToArray_With_ValidData_Should_Succeed(int start, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Range(start, count));

            // Act
            var result = ValueEnumerable.Range(start, count).ToArray();

            // Assert
            _ = result.Must()
                .BeOfType<int[]>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ToList_Should_Succeed(int start, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Range(start, count));

            // Act
            var result = ValueEnumerable.Range(start, count).ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}