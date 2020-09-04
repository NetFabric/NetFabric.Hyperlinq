using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Generation.ValueEnumerableTests
{
    public class AsyncRepeatTests
    {
        [Theory]
        [InlineData(-1)]
        public void Repeat_With_NegativeCount_Must_Throw(int count)
        {
            // Arrange

            // Act
            Action action = () => _ = AsyncValueEnumerable.Repeat(0, count);

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
            var result = AsyncValueEnumerable.Repeat(value, count);

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat_SkipTake), MemberType = typeof(TestData))]
        public void Repeat_Skip_With_ValidData_Must_Succeed(int value, int count, int skip)
        {
            // Arrange
            var expected = Enumerable.Skip(Enumerable.Repeat(value, count), skip);

            // Act
            var result = AsyncValueEnumerable.Repeat(value, count).Skip(skip);

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat_SkipTake), MemberType = typeof(TestData))]
        public void Repeat_Take_With_ValidData_Must_Succeed(int value, int count, int take)
        {
            // Arrange
            var expected = Enumerable.Take(Enumerable.Repeat(value, count), take);

            // Act
            var result = AsyncValueEnumerable.Repeat(value, count).Take(take);

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public async ValueTask Repeat_All_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable.All(Enumerable.Repeat(value, count), item => false);

            // Act
            var result = await AsyncValueEnumerable.Repeat(value, count).AllAsync(item => false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public async ValueTask Repeat_Any_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable.Any(Enumerable.Repeat(value, count));

            // Act
            var result = await AsyncValueEnumerable.Repeat(value, count).AnyAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public async ValueTask Repeat_ToArray_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable.ToArray(Enumerable.Repeat(value, count));

            // Act
            var result = await AsyncValueEnumerable.Repeat(value, count).ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Repeat), MemberType = typeof(TestData))]
        public async ValueTask Repeat_ToList_With_ValidData_Must_Succeed(int value, int count)
        {
            // Arrange
            var expected = Enumerable.ToList(Enumerable.Repeat(value, count));

            // Act
            var result = await AsyncValueEnumerable.Repeat(value, count).ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}