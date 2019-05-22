using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => ReadOnlySpanExtensions.Single<int>(source);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void SinglePredicate_With_Empty_Should_Throw(int[] source, Func<int, bool> predicate)
        {
            // Arrange

            // Act
            Action action = () => ReadOnlySpanExtensions.Single<int>(source, predicate);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SingleSingle), MemberType = typeof(TestData))]
        public void Single_With_ValidData_Should_Succeed(int[] source, int expected)
        {
            // Arrange

            // Act
            var result = ReadOnlySpanExtensions.Single<int>(source);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        public void SinglePredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = ReadOnlySpanExtensions.Single<int>(source, predicate);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SingleMultiple), MemberType = typeof(TestData))]
        public void Single_With_Multiple_Should_Throw(int[] source, int _)
        {
            // Arrange

            // Act
            Action action = () => ReadOnlySpanExtensions.Single<int>(source);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void SinglePredicate_With_Multiple_Should_Throw(int[] source, Func<int, bool> predicate, int _)
        {
            // Arrange

            // Act
            Action action = () => ReadOnlySpanExtensions.Single<int>(source, predicate);

            // Assert
            action.Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Sequence contains more than one element");
        }
    }
}