using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereReadOnlyListTests
    {
        [Fact]
        public void Where_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsReadOnlyList(new int[0]);
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => ReadOnlyList.Where<Wrap.ReadOnlyList<int>, int>(list, predicate);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.Where), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, int[] expected)
        {
            // Arrange
            var list = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.Where<IReadOnlyList<int>, int>(list, predicate);

            // Assert
            result.Should().Generate(expected);
        }
    }
}