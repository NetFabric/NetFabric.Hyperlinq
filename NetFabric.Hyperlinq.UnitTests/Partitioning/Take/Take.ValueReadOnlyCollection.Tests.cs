using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Take), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count, int[] expected)
        {
            // Arrange
            var collection = Wrap.AsValueReadOnlyCollection(source);

            // Act
            var result = ValueReadOnlyCollection.Take<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueReadOnlyCollection<int>.Enumerator, int>(collection, count);

            // Assert
            result.Should().Generate(expected);
        }
    }
}