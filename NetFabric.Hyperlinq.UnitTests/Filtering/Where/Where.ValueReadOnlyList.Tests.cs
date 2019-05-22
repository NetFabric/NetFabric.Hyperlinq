using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereValueReadOnlyListTests
    {
        [Fact]
        public void Where_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => ValueReadOnlyList.Where<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int>(list, predicate);

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
            var list = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ValueReadOnlyList.Where<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int>(list, predicate);

            // Assert
            result.Should().Generate(expected);
        }
    }
}