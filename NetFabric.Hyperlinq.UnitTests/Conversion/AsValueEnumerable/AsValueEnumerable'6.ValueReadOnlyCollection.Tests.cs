using System.Linq;
using NetFabric.Assertive;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.ValueReadOnlyCollection
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
                .AsValueReadOnlyCollection(source);

            // Act
            var result = ValueEnumerableExtensions
                .AsValueEnumerable<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(
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
                .AsValueReadOnlyCollection(source);

            // Act
            var result = ValueEnumerableExtensions
                .AsValueEnumerable<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(
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
                .AsValueReadOnlyCollection(source);
            var expected = source
                .Sum();

            // Act
            var result = ValueEnumerableExtensions
                .AsValueEnumerable<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(
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
            ValueReadOnlyCollectionExtensions.ValueEnumerable<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, Wrap.Enumerator<int>, int, FunctionWrapper<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>>, FunctionWrapper<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>>>, 
            ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>,
            ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>>
    {
        public ValueEnumerableTests6() 
            : base(array => ValueReadOnlyCollectionExtensions
                .AsValueEnumerable<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(Wrap.AsValueReadOnlyCollection(array), enumerable => enumerable.GetEnumerator()))
        {}
    }
}