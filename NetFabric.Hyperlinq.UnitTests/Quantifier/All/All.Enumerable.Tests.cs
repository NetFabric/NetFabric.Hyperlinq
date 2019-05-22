using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AllEnumerableTests
    {
        [Fact]
        public void All_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap.AsEnumerable(new int[0]);
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => Enumerable.All<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.All), MemberType = typeof(TestData))]
        public void All_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, bool expected)
        {
            // Arrange
            var wrapped = Wrap.AsEnumerable(source);

            // Act
            var result = Enumerable.All<Wrap.Enumerable<int>, Wrap.Enumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}