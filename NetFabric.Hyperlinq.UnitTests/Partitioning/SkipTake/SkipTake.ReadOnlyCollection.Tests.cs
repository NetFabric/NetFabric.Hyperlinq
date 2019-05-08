using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTakeReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTake), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount, int[] expected)
        {
            // Arrange
            var collection = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.SkipTake<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(collection, skipCount, takeCount);

            // Assert
            result.Should().Generate(expected);
        }
    }
}