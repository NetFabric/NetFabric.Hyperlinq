using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsValueEnumerableValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.AsValueEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(result, wrapped);
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ElementAt_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.ElementAt(wrapped, index);

            // Act
            var result = ValueEnumerable.AsValueEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped)
                .ElementAt<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(index);

            // Assert
            result.Should().Be(expected);
        }
    }
}