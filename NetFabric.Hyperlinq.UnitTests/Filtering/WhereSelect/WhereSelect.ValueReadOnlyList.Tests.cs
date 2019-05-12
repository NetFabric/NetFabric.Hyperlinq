using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereSelectValueReadOnlyListTests
    {
        [Fact]
        public void WhereSelect_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);

            // Act
            Action action = () => ValueReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int, int>(list, null, (item, _) => item);

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
            var list = Wrap.AsValueReadOnlyList(new int[0]);

            // Act
            Action action = () => ValueReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int, int>(list, (_, __) => true, null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.WhereSelect), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Should_Succeed(int[] source, Func<int, long, bool> predicate, Func<int, long, string> selector, string[] expected)
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ValueReadOnlyList.WhereSelect<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int, string>(list, predicate, selector);

            // Assert
            result.Should().Generate(expected);
        }
    }
}