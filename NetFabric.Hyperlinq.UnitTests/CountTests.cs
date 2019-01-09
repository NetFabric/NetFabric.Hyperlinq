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
            Action action = () => Enumerable.Count<IEnumerable<int>, int>(null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("source");
        }

        public static TheoryData<IReadOnlyCollection<int>> IEnumerableData =>
            new TheoryData<IReadOnlyCollection<int>> 
            {
                { new int[] {} },
                { new int[] { 0 }  },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
            };

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Count_With_ValidIEnumerable_Should_Succeed(IReadOnlyCollection<int> source)
        {
            // Arrange

            // Act
            var result = Enumerable.Count<IEnumerable<int>, int>(source);

            // Assert
            result.Should().Be(source.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ValidRange_Should_Succeed(int expected)
        {
            // Arrange
            var range = Enumerable.Range(0, expected);

            // Act
            var result = Enumerable.Count<Enumerable.RangeEnumerable, int>(range);

            // Assert
            result.Should().Be(expected);
        }        

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ValidSelect_Should_Succeed(int expected)
        {
            // Arrange
            var select = Enumerable.Range(0, expected)
                .Select<Enumerable.RangeEnumerable, int, int>(value => value);

            // Act
            var result = select.Count<Enumerable.SelectEnumerable<int, int>, int>();

            // Assert
            result.Should().Be(expected);
        }        

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Count_With_ValidWhere_Should_Succeed(int expected)
        {
            // Arrange
            var where = Enumerable.Range(0, expected)
                .Where<Enumerable.RangeEnumerable, int>(_ => true);

            // Act
            var result = where.Count<Enumerable.WhereEnumerable<int>, int>();

            // Assert
            result.Should().Be(expected);
        }        
    }
}