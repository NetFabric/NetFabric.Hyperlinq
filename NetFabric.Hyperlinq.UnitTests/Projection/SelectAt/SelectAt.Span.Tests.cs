using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectIndex
{
    public class SpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Select(source, selector);

            // Act
            var result = ArrayExtensions.Select(source.AsSpan(), selector);

            // Assert
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}