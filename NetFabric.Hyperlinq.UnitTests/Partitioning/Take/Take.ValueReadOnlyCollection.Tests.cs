using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.Take(wrapped, count);

            // Act
            var result = ValueReadOnlyCollection.Take<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, count);

            // Assert
            Utils.ValueReadOnlyCollection.ShouldEqual<
                ValueReadOnlyCollection.SkipTakeEnumerable<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>,
                ValueReadOnlyCollection.SkipTakeEnumerable<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}