using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void WhereSelect_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = Wrap.AsReadOnlyList(new int[0]);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where<Wrap.ReadOnlyListWrapper<int>, int>(source, predicate)
                .Select(item => item.ToString());

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Fact]
        public void WhereSelect_Selector_With_Null_Must_Throw()
        {
            // Arrange
            var source = Wrap.AsReadOnlyList(new int[0]);
            var selector = (NullableSelector<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where<Wrap.ReadOnlyListWrapper<int>, int>(source, _ => true)
                .Select(selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate.AsFunc())
                .Select(selector.AsFunc());

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}