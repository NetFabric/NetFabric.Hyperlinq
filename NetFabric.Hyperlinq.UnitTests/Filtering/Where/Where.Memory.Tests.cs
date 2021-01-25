using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class MemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Where(source, predicate);

            // Act
            var result = ArrayExtensions
                .Where(source.AsMemory(), predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}