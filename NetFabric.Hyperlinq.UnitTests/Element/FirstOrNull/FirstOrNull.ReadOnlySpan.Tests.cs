using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstOrNullReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        public void FirstOrNull_With_Empty_Return_Default(int[] source)
        {
            // Arrange

            // Act
            var result = ReadOnlySpanExtensions.FirstOrNull<int>(source);

            // Assert
            result.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void FirstOrNullPredicate_With_Empty_Return_Default(int[] source, Func<int, long, bool> predicate)
        {
            // Arrange

            // Act
            var result = ReadOnlySpanExtensions.FirstOrNull<int>(source, predicate);

            // Assert
            result.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(TestData.SingleSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SingleMultiple), MemberType = typeof(TestData))]
        public void FirstOrNull_With_ValidData_Should_Succeed(int[] source, int expected)
        {
            // Arrange

            // Act
            var result = ReadOnlySpanExtensions.FirstOrNull<int>(source);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void FirstOrNullPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange

            // Act
            var result = ReadOnlySpanExtensions.FirstOrNull<int>(source, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}