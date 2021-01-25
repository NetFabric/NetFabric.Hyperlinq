using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate);

            // Act
            var result = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}