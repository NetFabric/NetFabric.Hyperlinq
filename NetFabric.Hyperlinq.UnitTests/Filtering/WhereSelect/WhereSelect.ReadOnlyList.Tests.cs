using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereSelectReadOnlyListTests
    {
        [Fact]
        public void WhereSelect_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsReadOnlyList(new int[0]);

            // Act
            Action action = () => ReadOnlyList.WhereSelect<Wrap.ReadOnlyList<int>, int, int>(list, null, item => item);

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
            var list = Wrap.AsReadOnlyList(new int[0]);

            // Act
            Action action = () => ReadOnlyList.WhereSelect<Wrap.ReadOnlyList<int>, int, int>(list, _ => true, null);

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
            var list = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.WhereSelect<IReadOnlyList<int>, int, string>(list, predicate, selector);

            // Assert
            result.Should().Generate(expected);
        }
    }
}