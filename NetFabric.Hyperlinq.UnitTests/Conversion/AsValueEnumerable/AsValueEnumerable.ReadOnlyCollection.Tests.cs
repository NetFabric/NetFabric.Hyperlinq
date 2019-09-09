using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsValueEnumerableReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.AsValueEnumerable(wrapped);

            // Assert
            result.Should().BeOfType<ReadOnlyCollection.ValueEnumerableWrapper<int>>();
            result.Must().BeExactlyAs(wrapped);
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ElementAt_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.ElementAt(wrapped, index);

            // Act
            var result = ReadOnlyCollection.AsValueEnumerable(wrapped).ElementAt(index);

            // Assert
            result.Should().Be(expected);
        }
    }
}