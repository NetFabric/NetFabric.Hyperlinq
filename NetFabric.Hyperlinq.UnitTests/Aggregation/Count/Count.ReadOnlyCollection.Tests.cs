using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Count), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Should_Succeed(int[] source, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.Count<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.CountPredicate), MemberType = typeof(TestData))]
        public void CountPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, long, bool> predicate, int expected)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.Count<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}