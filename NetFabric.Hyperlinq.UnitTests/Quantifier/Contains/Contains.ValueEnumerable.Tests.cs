using System;
using System.Collections.Generic;
using System.Diagnostics;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ContainsValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_Should_Succeed(int[] source, int value, IEqualityComparer<int> comparer)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, comparer);

            // Act
            var result = ValueEnumerable
                .Contains<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, value, comparer);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}