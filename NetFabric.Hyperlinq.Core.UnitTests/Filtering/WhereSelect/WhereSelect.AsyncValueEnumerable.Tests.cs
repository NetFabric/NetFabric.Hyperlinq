using NetFabric.Assertive;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Where(predicate)
                .Select(selector);

            // Act
            var result = wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .Select(selector.AsAsync());

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<string>()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async Task WhereSelect_Sum_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Where(predicate)
                .Select(item => item)
                .Sum();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .Select((item, _) => new ValueTask<int>(item))
                .SumAsync()
.ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}