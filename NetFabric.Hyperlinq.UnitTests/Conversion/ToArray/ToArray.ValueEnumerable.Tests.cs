using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToArrayValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.ToArray(wrapped);

            // Act
            var result = ValueEnumerable.ToArray<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int>(wrapped);

            // Assert
            result.Should()
                .BeOfType<int[]>().And
                .NotBeSameAs(source).And
                .Equal(expected);
        }
    }
}