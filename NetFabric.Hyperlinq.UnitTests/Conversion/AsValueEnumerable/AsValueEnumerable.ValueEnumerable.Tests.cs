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
            var result = ValueEnumerable.AsValueEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int>(wrapped);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int>(result, wrapped);
        }
    }
}