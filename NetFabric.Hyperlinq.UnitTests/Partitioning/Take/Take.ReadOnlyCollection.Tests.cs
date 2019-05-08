using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Take), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            var collection = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.Take<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(collection, count);

            // Assert
            result.Should().Generate(expected);
        }
    }
}