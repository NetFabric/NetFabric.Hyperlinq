using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Take), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.Take(wrapped, count);

            // Act
            var result = ValueReadOnlyCollection.Take<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int>(wrapped, count);

            // Assert
            Utils.ValueReadOnlyCollection.ShouldEqual<
                ValueReadOnlyCollection.SkipTakeEnumerable<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int>,
                ValueReadOnlyCollection.SkipTakeEnumerable<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}