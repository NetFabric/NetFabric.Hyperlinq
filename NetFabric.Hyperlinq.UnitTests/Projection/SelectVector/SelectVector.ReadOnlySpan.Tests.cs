using NetFabric.Assertive;
using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectVector
{
    public class ReadOnlySpanTests
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
            var result = ((ReadOnlySpan<int>)source.AsSpan())
                .SelectVector(vectorSelector, selector);

            // Assert
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

#endif    
    }
}