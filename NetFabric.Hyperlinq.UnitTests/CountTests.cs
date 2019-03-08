using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountTests
    {
        [Fact]
        public void Count_With_NullSource_Should_Throw()
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Count<IEnumerable<int>, IEnumerator<int>, int>(null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("source");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_Enumerable_ValueType(int expected)
        {
            // Arrange
            IEnumerable<int> source = TestEnumerable.ValueType(expected);

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
            IEnumerable<int> source = TestEnumerable.ReferenceType(expected);

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
    }
}