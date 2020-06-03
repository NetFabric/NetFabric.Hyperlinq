using System;
using System.Collections.Generic;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.Select
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void Select_With_NullSelector_Must_Throw()
        {
            // Arrange
            var source = Wrap.AsValueReadOnlyList(new int[0]);
            var selector = (Selector<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyList.Select<Wrap.ValueReadOnlyList<int>, int, string>(source, selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Select(wrapped, selector.AsFunc());

            // Act
            var result = ReadOnlyList
                .Select<Wrap.ValueReadOnlyList<int>, int, string>(wrapped, selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}