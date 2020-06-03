using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.Skip
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Skip(source, count);

            // Act
            var result = Array.Skip(source, count);

            // Assert
#if SPAN_SUPPORTED
            _ = result.Must()
                .BeEqualTo(expected);
#else
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
#endif
        }
    }
}