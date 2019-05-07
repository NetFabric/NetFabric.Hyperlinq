using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        public void First_With_Empty_Should_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable.First<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void FirstPredicate_With_Empty_Should_Throw(int[] source, Func<int, long, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            Action action = () => ValueEnumerable.First<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SingleSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SingleMultiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Should_Succeed(int[] source, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.First<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void FirstPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerable.First<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}