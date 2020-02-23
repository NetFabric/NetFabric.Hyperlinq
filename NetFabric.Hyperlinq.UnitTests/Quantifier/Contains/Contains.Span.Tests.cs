using System;
using System.Collections.Generic;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public partial class SpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_Should_Succeed(int[] source, int value, IEqualityComparer<int> comparer)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Contains(source, value, comparer);

            // Act
            var result = Array
                .Contains<int>(source.AsSpan(), value, comparer);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}