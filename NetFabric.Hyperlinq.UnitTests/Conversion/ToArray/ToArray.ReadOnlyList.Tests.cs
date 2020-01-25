using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToArrayValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(wrapped);

            // Act
            var result = wrapped
                .ToArray<Wrap.ValueReadOnlyList<int>, int>();

            // Assert
            _ = result.Must()
                .BeOfType<int[]>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_With_Predicate_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Where(wrapped, item => (item & 0x01) == 0));

            // Act
            var result = wrapped
                .Where<Wrap.ValueReadOnlyList<int>, int>(item => (item & 0x01) == 0)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeOfType<int[]>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}