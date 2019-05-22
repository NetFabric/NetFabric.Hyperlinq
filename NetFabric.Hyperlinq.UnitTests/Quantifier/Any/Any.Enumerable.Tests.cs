using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AnyEnumerableTests
    {
        [Fact]
        public void Any_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap.AsEnumerable(new int[0]);
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => Enumerable.Any<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.Any), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, bool expected)
        {
            // Arrange
            var wrapped = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.Any<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}