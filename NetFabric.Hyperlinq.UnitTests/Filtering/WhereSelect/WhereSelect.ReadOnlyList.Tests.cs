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
            Action action = () => ReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, int, int>(list, null, item => item);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Fact]
        public void WhereSelect_With_NullSelector_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);

            // Act
            Action action = () => ReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, int, int>(list, item => (item & 0x01) == 0, null);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(wrapped, predicate.AsFunc()), selector.AsFunc());

            // Act
            var result = ReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, int, string>(wrapped, predicate, selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}