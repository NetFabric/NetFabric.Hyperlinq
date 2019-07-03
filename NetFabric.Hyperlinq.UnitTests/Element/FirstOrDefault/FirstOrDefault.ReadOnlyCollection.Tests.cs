using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstOrDefaultReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        public void FirstOrDefault_With_Empty_Return_Default(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.FirstOrDefault<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void FirstOrDefaultPredicate_With_Empty_Return_Default(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.FirstOrDefault<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [MemberData(nameof(TestData.SingleSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SingleMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_With_ValidData_Should_Succeed(int[] source, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.FirstOrDefault<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefaultPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.FirstOrDefault<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}