using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Take(wrapped, count);

            // Act
            var result = ValueReadOnlyList.Take<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, count);

            // Assert
            result.Must().BeEnumerable(expected);
        }
    }
}