using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereSelectValueEnumerableTests
    {
        [Fact]
        public void WhereSelect_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);

            // Act
            Action action = () => ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, int>(enumerable, null, item => item);

            // Assert
            action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Fact]
        public void WhereSelect_With_NullSelector_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);

            // Act
            Action action = () => ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, int>(enumerable, item => (item & 0x01) == 0, null);

            // Assert
            action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelector), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(wrapped, predicate.AsFunc()), selector.AsFunc());

            // Act
            var result = ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int, string>(wrapped, predicate, selector);

            // Assert
            result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}