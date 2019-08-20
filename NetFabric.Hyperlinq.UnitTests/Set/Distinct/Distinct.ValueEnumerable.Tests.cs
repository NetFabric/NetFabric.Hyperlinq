using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class DistinctValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Distinct), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Distinct(wrapped);

            // Act
            var result = ValueEnumerable.Distinct<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int>(wrapped);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.DistinctEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int>,
                ValueEnumerable.DistinctEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}
