using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereSelectEnumerableTests
    {
        [Fact]
        public void WhereSelect_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsEnumerable(new int[0]);

            // Act
            Action action = () => Enumerable.WhereSelect<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int, int>(enumerable, null, item => item);

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
            var enumerable = Wrap.AsEnumerable(new int[0]);

            // Act
            Action action = () => Enumerable.WhereSelect<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int, int>(enumerable, _ => true, null);

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
            var enumerable = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.WhereSelect<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int, string>(enumerable, predicate, selector);

            // Assert
            result.Should().Generate(expected);
        }
    }
}