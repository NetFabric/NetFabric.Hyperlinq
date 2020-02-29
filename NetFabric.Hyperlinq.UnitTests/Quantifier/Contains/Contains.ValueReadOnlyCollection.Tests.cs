using System;
using System.Collections.Generic;
using System.Diagnostics;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Contains
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_ValidData_Should_Succeed(int[] source, int value, IEqualityComparer<int> comparer)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, comparer);

            // Act
            var result = ValueReadOnlyCollection
                .Contains<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, value, comparer);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}