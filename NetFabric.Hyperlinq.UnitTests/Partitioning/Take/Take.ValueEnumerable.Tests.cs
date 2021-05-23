using NetFabric.Assertive;
using System.Linq;
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
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = source
                .Take(count);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Take(count);

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
            var expected = source
                .Take(count0)
                .Take(count1);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Take(count0)
                .Take(count1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.TakeSkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSkipMultiple), MemberType = typeof(TestData))]
        public void Take_Skip_With_ValidData_Must_Succeed(int[] source, int take, int skip)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = source
                .Take(take)
                .Skip(skip);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Take(take)
                .Skip(skip);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}