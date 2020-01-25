using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AsValueEnumerableReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList
                .AsValueEnumerable<Wrap.ReadOnlyList<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyList.ValueEnumerableWrapper<Wrap.ReadOnlyList<int>, int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ElementAt_Should_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ElementAt(wrapped, index);

            // Act
            var result = ReadOnlyList
                .AsValueEnumerable<Wrap.ReadOnlyList<int>, int>(wrapped)
                .ElementAt(index);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}