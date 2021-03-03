using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public partial class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = wrapped
                .AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
        }
        
        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Skip_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = source
                .Skip(count);

            // Act
            var result = wrapped
                .AsValueEnumerable()
                .Skip(count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Take_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = source
                .Take(count);

            // Act
            var result = wrapped
                .AsValueEnumerable()
                .Take(count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Sum_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = source
                .Skip(skipCount)
                .Take(takeCount)
                .Sum();

            // Act
            var result = wrapped
                .AsValueEnumerable()
                .Skip(skipCount)
                .Take(takeCount)
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}