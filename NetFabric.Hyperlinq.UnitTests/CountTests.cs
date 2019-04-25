using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_Enumerable_ValueType(int expected)
        {
            // Arrange
            IEnumerable<long> source = TestEnumerable.ValueType(expected);

            // Act
            var result = source.Count();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_Enumerable_ReferenceType(int expected)
        {
            // Arrange
            IEnumerable<long> source = TestEnumerable.ReferenceType(expected);

            // Act
            var result = source.Count();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ReadOnlyCollection_ValueType(int expected)
        {
            // Arrange
            IEnumerable<int> source = TestReadOnlyCollection.ValueType(expected);

            // Act
            var result = source.Count();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ReadOnlyCollection_ReferenceType(int expected)
        {
            // Arrange
            IEnumerable<int> source = TestReadOnlyCollection.ReferenceType(expected);

            // Act
            var result = source.Count();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ReadOnlyList_ValueType(int expected)
        {
            // Arrange
            IEnumerable<int> source = TestReadOnlyList.ValueType(expected);

            // Act
            var result = source.Count();

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ReadOnlyList_ReferenceType(int expected)
        {
            // Arrange
            IEnumerable<int> source = TestReadOnlyList.ReferenceType(expected);

            // Act
            var result = source.Count();

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Test()
        {
            // Arrange
            IEnumerable<int> source = new List<int>(new[] { 0, 1, 2, 3, 4, 5 });

            // Act
            var result = source.Count();

            // Assert
            result.Should().Be(6);
        }
    }
}