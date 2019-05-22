using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectValueReadOnlyListTests
    {
        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);
            var selector = (Func<int, string>)null;

            // Act
            Action action = () => ValueReadOnlyList.Select<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int, string>(list, selector);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Select), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Should_Succeed(int[] source, Func<int, string> selector, string[] expected)
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ValueReadOnlyList.Select<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int, string>(list, selector);

            // Assert
            result.Should().Generate(expected);
        }
    }
}