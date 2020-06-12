using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.Take
{
    public class MemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Take(source, count);

            // Act
            var result = ArrayExtensions
                .Take(source.AsMemory(), count);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}