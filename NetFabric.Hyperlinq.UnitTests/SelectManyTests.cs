using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectManyTests
    {
        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var enumerable = Enumerable.Empty<int>();

            // Act
            Action action = () => enumerable.SelectMany<int>(null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        public static TheoryData<int[], Func<int, Enumerable.RangeEnumerable>, int[]> IEnumerableData =>
            new TheoryData<int[], Func<int, Enumerable.RangeEnumerable>, int[]> 
            {
                { new int[] {}, new Func<int, Enumerable.RangeEnumerable>(value => Enumerable.Range(0, value)), new int[] {} },
                { new int[] { 1 }, new Func<int, Enumerable.RangeEnumerable>(value => Enumerable.Range(0, value)), new int[] { 0 } },
                { new int[] { 1, 2, 3 }, new Func<int, Enumerable.RangeEnumerable>(value => Enumerable.Range(0, value)), new int[] { 0, 0, 1, 0, 1, 2 } },
            };

        // [Theory]
        // [MemberData(nameof(IEnumerableData))]
        // public void SelectMany_With_ValidEnumerable_Should_Succeed(IEnumerable<int> source, Func<int, Enumerable.RangeEnumerable> selector, IEnumerable<int> expected)
        // {
        //     // Arrange

        //     // Act
        //     var result = source.SelectMany<int, Enumerable.RangeEnumerable, Enumerable.RangeEnumerable.ValueEnumerator, int>(selector);

        //     // Assert
        //     result.AsEnumerable().Should().Equal(expected);
        // }  

        // [Theory]
        // [MemberData(nameof(IEnumerableData))]
        // public void SelectMany_With_ValidReadOnlyList_Should_Succeed(IReadOnlyList<int> source, Func<int, Enumerable.RangeEnumerable> selector, IEnumerable<int> expected)
        // {
        //     // Arrange

        //     // Act
        //     var result = source.SelectMany<int, Enumerable.RangeEnumerable, Enumerable.RangeEnumerable.ValueEnumerator, int>(selector);

        //     // Assert
        //     result.AsEnumerable().Should().Equal(expected);
        // } 
    }
}