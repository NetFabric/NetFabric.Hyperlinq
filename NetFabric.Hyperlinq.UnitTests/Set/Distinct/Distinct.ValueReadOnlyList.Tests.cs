using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class DistinctValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Distinct), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Distinct(wrapped);

            // Act
            var result = ValueReadOnlyList.Distinct<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int>(wrapped);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueReadOnlyList.DistinctEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int>,
                ValueReadOnlyList.DistinctEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int>.Enumerator,
                int>(result, expected);
        }
    }
}
