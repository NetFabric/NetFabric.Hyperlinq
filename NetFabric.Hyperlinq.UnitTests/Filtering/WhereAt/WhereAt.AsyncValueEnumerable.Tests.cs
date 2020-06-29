using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereAt
{
    public class AsyncValueEnumerableTests
    {
        [Fact]
        public void Where_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsAsyncValueEnumerable(new int[0]);
            var predicate = (AsyncPredicateAt<int>)null;

            // Act
            Action action = () => _ = AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(enumerable, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc());

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