using NetFabric.Assertive;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectVector
{
    public class ReadOnlySpanTests
    {

        [Theory]
        [MemberData(nameof(TestData.SelectVector), MemberType = typeof(TestData))]
        public void SelectVector_ToArray_With_ValidData_Must_Succeed(int[] source, Func<Vector<int>, Vector<int>> vectorSelector, Func<int, int> selector)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Select(selector)
                .ToArray();

            // Act
            var result = wrapped.AsValueEnumerable()
                .SelectVector(vectorSelector, selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

    }
}