using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.Select
{
    public class AsyncValueEnumerableTests
    {
        [Fact]
        public void Select_Selector_With_Null_Must_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsAsyncValueEnumerable(new int[0]);
            var predicate = (AsyncSelector<int, string>)null;

            // Act
            Action action = () => _ = AsyncValueEnumerableExtensions
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(enumerable, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Select_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = System.Linq.Enumerable
                .Select(source, selector.AsFunc());

            // Act
            var result = AsyncValueEnumerableExtensions
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync());

            // Assert
            _ = result.Must()
                .BeAsyncEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}