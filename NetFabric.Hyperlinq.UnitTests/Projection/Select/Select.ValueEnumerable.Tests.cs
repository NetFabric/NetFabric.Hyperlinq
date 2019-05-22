using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectValueEnumerableTests
    {
        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);
            var selector = (Func<int, string>)null;

            // Act
            Action action = () => ValueEnumerable.Select<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int, string>(enumerable, selector);

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
            var enumerable = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.Select<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int, string>(enumerable, selector);

            // Assert
            result.Should().Generate(expected);
        }
    }
}