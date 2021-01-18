using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate);

            // Act
            var result = ArrayExtensions
                .Where(source, predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicatePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicatePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicatePredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Where_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate0, Func<int, bool> predicate1)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate0)
                .Where(predicate1);

            // Act
            var result = ArrayExtensions
                .Where(source, predicate0)
                .Where(predicate1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}