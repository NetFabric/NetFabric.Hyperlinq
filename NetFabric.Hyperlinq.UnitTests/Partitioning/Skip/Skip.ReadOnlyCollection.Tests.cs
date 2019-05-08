using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Skip), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            var collection = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.Skip<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(collection, count);

            // Assert
            result.Should().Generate(expected);
        }
    }
}