using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.ValueReadOnlyCollection
{
    public partial class Tests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueReadOnlyCollection2_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);

            // Act
            // ReSharper disable once HeapView.BoxingAllocation
            var result = wrapped
                .AsValueEnumerable<Wrap.Enumerator<int>, int>();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueReadOnlyCollection2_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = source
                .Sum();

            // Act
            // ReSharper disable once HeapView.BoxingAllocation
            var result = wrapped
                .AsValueEnumerable<Wrap.Enumerator<int>, int>()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }

    public class ValueReadOnlyCollectionTests2
        : ValueEnumerableTestsBase<
            ValueReadOnlyCollectionExtensions.ValueEnumerable<Wrap.Enumerator<int>, int>, 
            ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<IValueReadOnlyCollection<int, Wrap.Enumerator<int>>, Wrap.Enumerator<int>, int>,
            ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<IValueReadOnlyCollection<int, Wrap.Enumerator<int>>, Wrap.Enumerator<int>, int>>
    {
        public ValueReadOnlyCollectionTests2() 
            // ReSharper disable once HeapView.BoxingAllocation
            : base(array => Wrap.AsValueReadOnlyCollection(array).AsValueEnumerable<Wrap.Enumerator<int>, int>())
        {}
    }
}