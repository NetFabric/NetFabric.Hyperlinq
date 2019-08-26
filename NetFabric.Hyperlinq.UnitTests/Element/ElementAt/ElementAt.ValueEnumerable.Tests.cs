using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ElementAtValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.ElementAtOutOfRange), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Should_Throw(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable.ElementAt<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, index);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.ElementAt(wrapped, index);

            // Act
            var result = ValueEnumerable.ElementAt<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, index);

            // Assert
            result.Should().Be(expected);
        }
    }
}