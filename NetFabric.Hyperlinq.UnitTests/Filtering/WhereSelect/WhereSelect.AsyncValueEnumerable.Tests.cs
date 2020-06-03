using NetFabric.Assertive;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class AsyncValueEnumerableTests
    {
        [Fact]
        public void WhereSelect_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsAsyncValueEnumerable(new int[0]);
            var predicate = (AsyncPredicate<int>)null;

            // Act
            Action action = () => _ = AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(enumerable, predicate)
                .Select((item, _) => new ValueTask<string>(item.ToString()));

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Fact]
        public void WhereSelect_Selector_With_Null_Must_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsAsyncValueEnumerable(new int[0]);
            var selector = (AsyncSelector<int, string>)null;

            // Act
            Action action = () => _ = AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(enumerable, (_, __) => new ValueTask<bool>(true))
                .Select(selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected =
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc());

            // Act
            var result = AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync());

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}