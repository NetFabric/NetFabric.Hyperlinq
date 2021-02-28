using NetFabric.Assertive;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.Take
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = source
                .Take(count);

            // Act
            var result = ValueReadOnlyCollectionExtensions
                .Take<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}