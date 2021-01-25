using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.Select
{
    public class MemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, Func<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Select(source, selector);

            // Act
            var result = ArrayExtensions.Select(source.AsMemory(), selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}