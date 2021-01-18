using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class SpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(source, predicate), selector);

            // Act
            var result = ArrayExtensions
                .Where(source.AsSpan(), predicate)
                .Select(selector);

            // Assert
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}