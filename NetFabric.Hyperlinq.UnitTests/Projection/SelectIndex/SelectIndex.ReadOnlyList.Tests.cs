using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectIndex
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void SelectIndex_With_NullSelector_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);
            var selector = (Selector<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyList.Select<Wrap.ValueReadOnlyList<int>, int, string>(list, selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SelectIndex_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Select(wrapped, (item, index) => (item + index).ToString());

            // Act
            var result = ReadOnlyList
                .Select<Wrap.ValueReadOnlyList<int>, int, string>(wrapped, (item, index) => (item + index).ToString());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}