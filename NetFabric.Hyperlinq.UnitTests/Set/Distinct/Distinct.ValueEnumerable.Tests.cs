using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class DistinctValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Distinct(wrapped);

            // Act
            var result = ValueEnumerable.Distinct<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.DistinctEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>,
                ValueEnumerable.DistinctEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}
