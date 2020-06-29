using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ValueEnumerableTests
    {
        [Fact]
        public void Where_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var enumerable = Wrap
                .AsValueEnumerable(new int[0]);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(enumerable, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc());

            // Act
            var result = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}