using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AnyValueEnumerableTests
    {
        [Fact]
        public void Select_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(new int[0]);

            // Act
            Action action = () => ValueEnumerable.Any<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.Any), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Should_Succeed(int[] source, Func<int, long, bool> predicate, bool expected)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.Any<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}