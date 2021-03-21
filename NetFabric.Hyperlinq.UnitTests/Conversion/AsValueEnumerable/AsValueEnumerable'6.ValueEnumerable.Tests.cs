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
        public void AsValueEnumerable6_Enumerator_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .AsValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(
                    wrapped,
                    enumerable => enumerable.GetEnumerator());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable6_Enumerator2_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .AsValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(
                    wrapped,
                    enumerable => enumerable.GetEnumerator());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable6_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = ValueEnumerableExtensions
                .AsValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(
                    wrapped,
                    enumerable => enumerable.GetEnumerator())
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
        
    public class ValueEnumerableTests6
        : ValueEnumerableTestsBase<
            ValueEnumerableExtensions.ValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, Wrap.Enumerator<int>, int, FunctionWrapper<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>>, FunctionWrapper<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>>>, 
            ValueEnumerableExtensions.SkipEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>,
            ValueEnumerableExtensions.TakeEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>>
    {
        public ValueEnumerableTests6() 
            : base(array => ValueEnumerableExtensions
                .AsValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(Wrap.AsValueEnumerable(array), enumerable => enumerable.GetEnumerator()))
        {}
    }
}