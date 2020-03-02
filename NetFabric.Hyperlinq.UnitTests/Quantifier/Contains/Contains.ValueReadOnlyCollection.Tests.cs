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
        public void Contains_With_Null_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, null);

            // Act
            var result = ValueReadOnlyCollection
                .Contains<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, value, null);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_Comparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, EqualityComparer<int>.Default);

            // Act
            var result = ValueReadOnlyCollection
                .Contains<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}