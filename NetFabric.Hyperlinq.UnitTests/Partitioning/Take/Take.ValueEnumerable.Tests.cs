using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.Take
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Take(wrapped, count);

            // Act
            var result = ValueEnumerable
                .Take<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Take_Take), MemberType = typeof(TestData))]
        public void Take_Take_With_ValidData_Must_Succeed(int[] source, int count0, int count1)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Take(
                    System.Linq.Enumerable.Take(wrapped, count0), count1);

            // Act
            var result = ValueEnumerable
                .Take<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, count0)
                .Take(count1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}