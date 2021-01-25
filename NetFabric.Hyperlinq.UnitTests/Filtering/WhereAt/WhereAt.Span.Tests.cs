using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereIndex
{
    public class SpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate);

            // Act
            var result = ArrayExtensions
                .Where(source.AsSpan(), predicate);

            // Assert
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}