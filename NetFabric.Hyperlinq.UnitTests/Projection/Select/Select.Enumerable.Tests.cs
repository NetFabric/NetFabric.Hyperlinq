using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectEnumerableTests
    {
        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsEnumerable(new int[0]);
            var selector = (Func<int, string>)null;

            // Act
            Action action = () => Enumerable.Select<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int, string>(enumerable, selector);

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
            var enumerable = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.Select<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int, string>(enumerable, selector);

            // Assert
            result.Should().Generate(expected);
        }
    }
}