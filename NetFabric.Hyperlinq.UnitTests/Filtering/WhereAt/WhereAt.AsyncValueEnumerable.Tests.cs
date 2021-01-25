using NetFabric.Assertive;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereAt
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate);

            // Act
            var result = AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync());

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}