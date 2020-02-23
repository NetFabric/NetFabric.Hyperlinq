using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public partial class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable
                .Take(System.Linq.Enumerable
                .Skip(wrapped, skipCount), takeCount);

            // Act
            var result = ValueEnumerable
                .SkipTake<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTake_Take), MemberType = typeof(TestData))]
        public void SkipTake_Take_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount0, int takeCount1)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable
                .Take(System.Linq.Enumerable
                .Take(System.Linq.Enumerable
                .Skip(wrapped, skipCount), takeCount0), takeCount1);

            // Act
            var result = ValueEnumerable
                .SkipTake<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount0)
                .Take(takeCount1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}