using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public partial class ReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection
                .AsValueEnumerable(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollection.ValueEnumerableWrapper<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ElementAt_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.ElementAt(wrapped, index);

            // Act
            var result = ReadOnlyCollection
                .AsValueEnumerable(wrapped)
                .ElementAt(index);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}