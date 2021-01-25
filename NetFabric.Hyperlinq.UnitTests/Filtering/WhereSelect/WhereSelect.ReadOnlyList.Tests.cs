using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate)
                .Select(selector);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Select(selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}