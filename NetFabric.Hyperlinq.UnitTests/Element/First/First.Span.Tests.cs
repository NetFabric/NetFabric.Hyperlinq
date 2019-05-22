using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstSpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        public void First_With_Empty_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => SpanExtensions.First<int>(source);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void FirstPredicate_With_Empty_Should_Throw(int[] source, Func<int, bool> predicate)
        {
            // Arrange

            // Act
            Action action = () => SpanExtensions.First<int>(source, predicate);

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

            // Act
            var result = SpanExtensions.First<int>(source);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void FirstPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = SpanExtensions.First<int>(source, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}