using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectTests
    {
        [Fact]
        public void Select_With_NullSource_Should_Throw()
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Select<IEnumerable<int>, int, int>(null, value => value);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("source");
        }

        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var enumerable = Enumerable.Empty<int>();

            // Act
            Action action = () => Enumerable.Select<IEnumerable<int>, int, int>(enumerable, (Func<int, int>)null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        public static TheoryData<IReadOnlyList<int>, Func<int, int>, IReadOnlyList<int>> IEnumerableData =>
            new TheoryData<IReadOnlyList<int>, Func<int, int>, IReadOnlyList<int>> 
            {
                { new int[] {}, new Func<int, int>(value => value), new int[] {} },
                { new int[] { 1 }, new Func<int, int>(value => value), new int[] { 1 } },
                { new int[] { 1 }, new Func<int, int>(value => value * 2), new int[] { 2 } },
                { new int[] { 1, 2, 3 }, new Func<int, int>(value => value * 2), new int[] { 2, 4, 6 } },
            };

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Select_With_ValidEnumeration_Should_Succeed(IReadOnlyList<int> source, Func<int, int> selector, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = source.Select(selector);

            // Assert
            // result.Count.Should().Be(expected.Count);
            result.Should().Equal(expected);
            // for(var index = 0; index < result.Count; index++)
            //     result[index].Should().Be(selector(expected[index]));
        }      
    }
}