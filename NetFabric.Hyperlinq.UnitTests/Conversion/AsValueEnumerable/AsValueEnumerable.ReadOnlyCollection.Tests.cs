using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsValueEnumerableReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.AsValueEnumerable(wrapped);

            // Assert
            result.Should().BeOfType<ReadOnlyCollection.ValueEnumerableWrapper<int>>();
            Utils.ValueReadOnlyCollection.ShouldEqual<ReadOnlyCollection.ValueEnumerableWrapper<int>, ReadOnlyCollection.ValueEnumerableWrapper<int>.Enumerator, int>(result, wrapped);
        }
    }
}