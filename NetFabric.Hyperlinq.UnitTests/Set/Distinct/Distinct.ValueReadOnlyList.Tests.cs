using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class DistinctValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Distinct(wrapped);

            // Act
            var result = ValueReadOnlyList.Distinct<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueReadOnlyList.DistinctEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>,
                ValueReadOnlyList.DistinctEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}
