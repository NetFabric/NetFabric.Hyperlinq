using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Take), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Take(wrapped, count);

            // Act
            var result = ValueReadOnlyList.Take<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>(wrapped, count);

            // Assert
            Utils.ValueReadOnlyList.ShouldEqual<
                ValueReadOnlyList.SkipTakeEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>,
                ValueReadOnlyList.SkipTakeEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}