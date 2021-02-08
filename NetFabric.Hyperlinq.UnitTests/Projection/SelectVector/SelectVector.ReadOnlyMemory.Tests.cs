using NetFabric.Assertive;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectVector
{
    public class ReadOnlyMemoryTests
    {
#if NET5_0

        [Theory]
        [MemberData(nameof(TestData.SelectVector), MemberType = typeof(TestData))]
        public void SelectVector_With_ValidData_Must_Succeed(int[] source, Func<Vector<int>, Vector<int>> vectorSelector, Func<int, int> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector);

            // Act
            var result = ((ReadOnlyMemory<int>)source.AsMemory()).AsValueEnumerable()
                .SelectVector(vectorSelector, selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectVector), MemberType = typeof(TestData))]
        public void SelectVector_ToArray_With_ValidData_Must_Succeed(int[] source, Func<Vector<int>, Vector<int>> vectorSelector, Func<int, int> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector)
                .ToArray();

            // Act
            var result = ((ReadOnlyMemory<int>)source.AsMemory()).AsValueEnumerable()
                .SelectVector(vectorSelector, selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

#endif    
    }
}