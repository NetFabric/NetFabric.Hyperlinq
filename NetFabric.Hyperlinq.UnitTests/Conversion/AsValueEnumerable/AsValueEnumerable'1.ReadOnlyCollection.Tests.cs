using NetFabric.Assertive;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.ReadOnlyCollection
{
    public partial class Tests
    {
        [Fact]
        public void AsValueEnumerable1_Enumerator_With_ValidData_Must_Succeed()
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(System.Array.Empty<int>());

            // Act
            var result = wrapped
                .AsValueEnumerable<int>();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyCollectionExtensions.ValueEnumerable<int>>();
        }
         
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyCollection(source);
            var expected = source
                .Sum();
    
            // Act
            var result = wrapped
                .AsValueEnumerable<int>()
                .Sum();
    
            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }    
    }

    public class ValueEnumerableTests1
        : ValueEnumerableTestsBase<
            ReadOnlyCollectionExtensions.ValueEnumerable<int>,
            ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ReadOnlyCollectionExtensions.ValueEnumerable<int>, ValueEnumerator<int>, int>,
            ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ReadOnlyCollectionExtensions.ValueEnumerable<int>, ValueEnumerator<int>, int>>
    {
        public ValueEnumerableTests1()
            : base(array => Wrap.AsReadOnlyCollection(array).AsValueEnumerable<int>())
        {
        }
    }
}