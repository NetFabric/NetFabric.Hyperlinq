using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ReturnTests
    {
        [Theory]
        [MemberData(nameof(TestData.Return), MemberType = typeof(TestData))]
        public void Return_With_Value_Should_Succeed(int value)
        {
            // Arrange
            var expected = System.Linq.EnumerableEx.Return(value);

            // Act
            var result = ValueEnumerable.Return(value);

            // Assert
            Utils.ValueReadOnlyList.ShouldEqual<
                ValueEnumerable.ReturnEnumerable<int>,
                ValueEnumerable.ReturnEnumerable<int>.Enumerator,
                int>(result, expected);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        public void Indexer_With_IndexOutOfRange_Should_Throw(int value, int index)
        {
            // Arrange

            // Act
            Func<int> action = () => ValueEnumerable.Return(value)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }    
    }
}