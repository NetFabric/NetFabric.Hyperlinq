using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.Skip
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Skip(source, count);

            // Act
            var result = ReadOnlyList.Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}