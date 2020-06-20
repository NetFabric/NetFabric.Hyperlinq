using System;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToArray_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }
    }
}