using NetFabric.Assertive;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.Enumerable
{
    public partial class Tests
    {
        [Fact]
        public void AsValueEnumerable1_Enumerator_With_ValidData_Must_Succeed()
        {
            // Arrange
            var wrapped = Wrap
                .AsEnumerable(System.Array.Empty<int>());

            // Act
            var result = wrapped
                .AsValueEnumerable<int>();

            // Assert
            _ = result.Must()
                .BeOfType<EnumerableExtensions.ValueEnumerable<int>>();
        }
         
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsEnumerable(source);
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
            EnumerableExtensions.ValueEnumerable<int>, 
            ValueEnumerableExtensions.SkipEnumerable<EnumerableExtensions.ValueEnumerable<int>, ValueEnumerator<int>, int>,
            ValueEnumerableExtensions.TakeEnumerable<EnumerableExtensions.ValueEnumerable<int>, ValueEnumerator<int>, int>>
    {
        public ValueEnumerableTests1() 
            : base(array => Wrap.AsEnumerable(array).AsValueEnumerable<int>())
        {}
    }

}