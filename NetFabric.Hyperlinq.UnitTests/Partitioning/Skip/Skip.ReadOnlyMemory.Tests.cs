using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipReadOnlyMemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Skip(source, count);

            // Act
            var result = Array.Skip((ReadOnlyMemory<int>)source.AsMemory(), count);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}