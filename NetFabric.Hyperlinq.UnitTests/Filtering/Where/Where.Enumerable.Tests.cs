using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereEnumerableTests
    {
        [Fact]
        public void Where_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsEnumerable(new int[0]);

            // Act
            Action action = () => Enumerable.Where<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(enumerable, null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.Where), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Should_Succeed(int[] source, Func<int, long, bool> predicate, int[] expected)
        {
            // Arrange
            var enumerable = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.Where<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(enumerable, predicate);

            // Assert
            result.Should().Generate(expected);
        }
    }
}