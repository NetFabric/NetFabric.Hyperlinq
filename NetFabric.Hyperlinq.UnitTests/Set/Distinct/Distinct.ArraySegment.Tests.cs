using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct
{
    public class ArraySegmentTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Distinct(source);

            // Act
            var result = ArrayExtensions
                .Distinct(wrapped);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Distinct_Skip_Take_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Distinct();

            // Act
            var result = ArrayExtensions
                .Skip(wrapped, skipCount)
                .Take(takeCount)
                .Distinct();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Distinct_Skip_Take_ToArray_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Distinct()
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Skip(wrapped, skipCount)
                .Take(takeCount)
                .Distinct()
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Distinct_Skip_Take_ToList_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Distinct()
                .ToList();

            // Act
            var result = ArrayExtensions
                .Skip(wrapped, skipCount)
                .Take(takeCount)
                .Distinct()
                .ToList();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}
