using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereAsyncValueEnumerableTests
    {
        [Fact]
        public void Where_Predicate_With_Null_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsAsyncValueEnumerable(new int[0]);
            var predicate = (AsyncPredicate<int>)null;

            // Act
            Action action = () => _ = AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(enumerable, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        // [Theory]
        // [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        // [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        // [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        // public void Where_Predicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        // {
        //     // Arrange
        //     var wrapped = Wrap.AsAsyncValueEnumerable(source);
        //     var expected = System.Linq.Enumerable
        //         .Where<int>(source, predicate.AsFunc());

        //     // Act
        //     var result = AsyncValueEnumerable
        //         .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync());

        //     // Assert
        //     _ = result.Must()
        //         .BeAsyncEnumerableOf<int>()
        //         .BeEqualTo(expected);
        // }
    }
}