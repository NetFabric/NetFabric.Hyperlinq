using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Generation.ValueEnumerableTests
{
    public class ReturnTests
    {
        [Theory]
        [MemberData(nameof(TestData.Return), MemberType = typeof(TestData))]
        public void Return_With_Value_Must_Succeed(int value)
        {
            // Arrange
            var expected = System.Linq.EnumerableEx.Return(value);

            // Act
            var result = ValueEnumerable.Return(value);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        public void Indexer_With_IndexOutOfRange_Must_Throw(int value, int index)
        {
            // Arrange

            // Act
            Func<int> action = () => ValueEnumerable.Return(value)[index];

            // Assert
            _ = action.Must().Throw<IndexOutOfRangeException>();
        }    
    }
}