using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectAt
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void Select_With_NullSelector_Must_Throw()
        {
            // Arrange
            var source = Wrap.AsValueReadOnlyList(new int[0]);
            var selector = (NullableSelectorAt<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions.Select<Wrap.ValueReadOnlyList<int>, int, string>(source, selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Select(wrapped, selector.AsFunc());

            // Act
            var result = ReadOnlyListExtensions
                .Select<Wrap.ValueReadOnlyList<int>, int, string>(wrapped, selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}