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
            Action action = () => ValueEnumerable.Select<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, string>(enumerable, selector);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Select), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Should_Succeed(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Select(wrapped, selector);

            // Act
            var result = ValueEnumerable.Select<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, string>(wrapped, selector);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.SelectEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, string>,
                ValueEnumerable.SelectEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, string>.Enumerator,
                string>(result, expected);
        }
    }
}