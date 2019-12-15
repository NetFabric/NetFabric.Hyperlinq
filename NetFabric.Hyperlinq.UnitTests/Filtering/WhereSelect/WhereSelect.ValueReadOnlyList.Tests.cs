using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereSelectValueReadOnlyListTests
    {
        [Fact]
        public void WhereSelect_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);

            // Act
            Action action = () => ValueReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int, int>(list, null, item => item);

            // Assert
            action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Fact]
        public void WhereSelect_With_NullSelector_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);

            // Act
            Action action = () => ValueReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int, int>(list, _ => true, null);

            // Assert
            action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.WhereSelect), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(wrapped, predicate.AsFunc()), selector);

            // Act
            var result = ValueReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int, string>(wrapped, predicate, selector);

            // Assert
            result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}