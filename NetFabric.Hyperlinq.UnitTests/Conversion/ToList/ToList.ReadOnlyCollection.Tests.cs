using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ToListReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Conversion), MemberType = typeof(TestData))]
        public void ToList_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyCollection(source);
            var expected = new List<int>(source);

            // Act
            var result = ReadOnlyCollection.ToList<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int>(wrapped);

            // Assert
            result.Should().Equal(expected);
        }
    }
}