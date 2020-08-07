using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.First
{
    public class ArraySegmentTests
    {
        [Fact]
        public void First_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = ArrayExtensions
                .First(source);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        public void First_With_Empty_Must_Return_None(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);

            // Act
            var result = ArrayExtensions
                .First(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Must_Return_Some(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var expected = Enumerable
                .First(wrapped);

            // Act
            var result = ArrayExtensions
                .First(wrapped);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }
    }
}