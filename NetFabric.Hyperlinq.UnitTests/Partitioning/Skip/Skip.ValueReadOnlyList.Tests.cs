using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Skip(wrapped, count);

            // Act
            var result = ValueReadOnlyList.Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, count);

            // Assert
            result.Must().BeExactlyAs(expected);
        }
    }
}