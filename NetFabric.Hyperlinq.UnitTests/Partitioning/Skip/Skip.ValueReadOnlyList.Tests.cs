using NetFabric.Assertive;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.Skip
{
    public class ValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = source
                .Skip(count);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Skip_Skip), MemberType = typeof(TestData))]
        public void Skip_Skip_With_ValidData_Must_Succeed(int[] source, int count0, int count1)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = source
                .Skip(count0)
                .Skip(count1);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(count0)
                .Skip(count1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Skip_Take_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = source
                .Skip(skip)
                .Take(take);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}