using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.ArraySegment
{
    public partial class Tests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);

            // Act
            var result = wrapped
                .AsValueEnumerable();

            // Assert
            result.SequenceEqual(source).Must().BeTrue();
        }
        
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Sum_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = new ArraySegment<int>(source);
            var expected = source
                .Skip(skipCount)
                .Take(takeCount)
                .Sum();

            // Act
            var result = wrapped
                .AsValueEnumerable()
                .Skip(skipCount)
                .Take(takeCount)
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }

    public class ArraySegmentValueEnumerableTests
        : ValueEnumerableTestsBase<ArrayExtensions.ArraySegmentValueEnumerable<int>>
    {
        public ArraySegmentValueEnumerableTests() 
            : base(array => new ArraySegment<int>(array).AsValueEnumerable())
        {}
    }
}