using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Skip), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Skip(wrapped, count);

            // Act
            var result = ValueReadOnlyList.Skip<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>(wrapped, count);

            // Assert
            Utils.ValueReadOnlyList.ShouldEqual<
                ValueReadOnlyList.SkipTakeEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>,
                ValueReadOnlyList.SkipTakeEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}