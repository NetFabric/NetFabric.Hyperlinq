using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectIndexValueReadOnlyListTests
    {
        [Fact]
        public void SelectIndex_With_NullSelector_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);
            var selector = (Func<int, string>)null;

            // Act
            Action action = () => ValueReadOnlyList.Select<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int, string>(list, selector);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SelectIndex_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Select(wrapped, (item, index) => (item + index).ToString());

            // Act
            var result = ValueReadOnlyList.Select<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int, string>(wrapped, (item, index) => (item + index).ToString());

            // Assert
            result.Must().BeEnumerable(expected);
        }
    }
}