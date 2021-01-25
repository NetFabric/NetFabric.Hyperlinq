using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(wrapped, predicate), selector);

            // Act
            var result = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .Select(selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}