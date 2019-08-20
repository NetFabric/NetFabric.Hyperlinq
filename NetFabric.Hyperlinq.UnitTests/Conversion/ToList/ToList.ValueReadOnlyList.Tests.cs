using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToListValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void ToList_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.ToList(wrapped);

            // Act
            var result = ValueReadOnlyList.ToList<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            result.Should()
                .BeOfType<List<int>>().And
                .NotBeSameAs(source).And
                .Equal(expected);
        }
    }
}