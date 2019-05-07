using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleOrNullValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        public void SingleOrNull_With_Empty_Return_Default(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.SingleOrNull<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void SingleOrNullPredicate_With_Empty_Return_Default(int[] source, Func<int, long, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.SingleOrNull<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(TestData.SingleSingle), MemberType = typeof(TestData))]
        public void SingleOrNull_With_ValidData_Should_Succeed(int[] source, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.SingleOrNull<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        public void SingleOrNullPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.SingleOrNull<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SingleMultiple), MemberType = typeof(TestData))]
        public void SingleOrNull_With_Multiple_Should_Throw(int[] source, int _)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable.SingleOrNull<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void SingleOrNullPredicate_With_Multiple_Should_Throw(int[] source, Func<int, long, bool> predicate, int _)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable.SingleOrNull<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains more than one element");
        }         
    }
}