using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.ValueEnumerable
{
    public partial class Tests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable2_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
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
        public void AsValueEnumerable2_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
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

    public class ValueEnumerableTests2
        : ValueEnumerableTestsBase<
            ValueEnumerableExtensions.ValueEnumerable<Wrap.Enumerator<int>, int>, 
            ValueEnumerableExtensions.SkipEnumerable<IValueEnumerable<int, Wrap.Enumerator<int>>, Wrap.Enumerator<int>, int>,
            ValueEnumerableExtensions.TakeEnumerable<IValueEnumerable<int, Wrap.Enumerator<int>>, Wrap.Enumerator<int>, int>>
    {
        public ValueEnumerableTests2() 
            // ReSharper disable once HeapView.BoxingAllocation
            : base(array => Wrap.AsValueEnumerable(array).AsValueEnumerable<Wrap.Enumerator<int>, int>())
        {}
    }
}