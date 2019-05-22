using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AnyReadOnlyListTests
    {
        [Fact]
        public void Any_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(new int[0]);
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => ReadOnlyList.Any<Wrap.ReadOnlyList<int>, int>(wrapped, predicate);

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
            var wrapped = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.Any<Wrap.ReadOnlyList<int>, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}