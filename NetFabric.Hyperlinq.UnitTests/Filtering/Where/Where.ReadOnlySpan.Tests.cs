using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Where(predicate);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Where(predicate);

            // Assert
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}