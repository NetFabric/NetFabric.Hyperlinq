using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereSelectValueEnumerableTests
    {
        [Fact]
        public void WhereSelect_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);

            // Act
            Action action = () => ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int, int>(enumerable, null, item => item);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Fact]
        public void WhereSelect_With_NullSelector_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);

            // Act
            Action action = () => ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int, int>(enumerable, _ => true, null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.WhereSelect), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, Func<int, string> selector, string[] expected)
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int, string>(enumerable, predicate, selector);

            // Assert
            result.Should().Generate(expected);
        }
    }
}