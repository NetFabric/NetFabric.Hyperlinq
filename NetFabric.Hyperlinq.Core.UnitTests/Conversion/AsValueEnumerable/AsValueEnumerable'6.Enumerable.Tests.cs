using System.Linq;
using NetFabric.Assertive;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public partial class EnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable6_Enumerator_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsEnumerable(source);

            // Act
            var result = wrapped
                .AsValueEnumerable<Wrap.EnumerableWrapper<int>, Wrap.Enumerator<int>, int>(
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
                .AsEnumerable(source);

            // Act
            var result = wrapped
                .AsValueEnumerable<Wrap.EnumerableWrapper<int>, Wrap.Enumerator<int>, ValueEnumerator<int>, int>(
                    enumerable => enumerable.GetEnumerator(), 
                    enumerable => new ValueEnumerator<int>(((IEnumerable<int>)enumerable).GetEnumerator()));

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
                .AsEnumerable(source);
            var expected = source
                .Sum();

            // Act
            var result = wrapped
                .AsValueEnumerable<Wrap.EnumerableWrapper<int>, Wrap.Enumerator<int>, ValueEnumerator<int>, int>(
                    enumerable => enumerable.GetEnumerator(), 
                    enumerable => new ValueEnumerator<int>(((IEnumerable<int>)enumerable).GetEnumerator()))
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}