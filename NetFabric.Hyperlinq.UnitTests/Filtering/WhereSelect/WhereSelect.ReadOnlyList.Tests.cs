using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(wrapped, predicate.AsFunc()), selector.AsFunc());

            // Act
            var result = ReadOnlyList
                .Where<Wrap.ValueReadOnlyList<int>, int>(wrapped, predicate)
                .Select(selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}