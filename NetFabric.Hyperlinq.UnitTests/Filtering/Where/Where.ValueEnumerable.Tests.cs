using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereValueEnumerableTests
    {
        [Fact]
        public void Where_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => ValueEnumerable.Where<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(enumerable, predicate);

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
            var enumerable = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.Where<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(enumerable, predicate);

            // Assert
            result.Should().Generate(expected);
        }
    }
}