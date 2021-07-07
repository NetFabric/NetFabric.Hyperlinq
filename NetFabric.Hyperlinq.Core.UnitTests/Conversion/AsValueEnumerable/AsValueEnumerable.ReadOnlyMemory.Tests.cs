using System.Linq;
using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable
{
    public partial class ReadOnlyMemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = (ReadOnlyMemory<int>)source.AsMemory();

            // Act
            var result = wrapped
                .AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(source, testRefStructs: false);
            result.SequenceEqual(source).Must().BeTrue();
        }
        
        [Theory]
        [MemberData(nameof(TestData.Skip_Skip), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Skip_Skip_With_ValidData_Must_Succeed(int[] source, int count0, int count1)
        {
            // Arrange
            var wrapped = (ReadOnlyMemory<int>)source.AsMemory();
            var expected = source
                .Skip(count0)
                .Skip(count1);

            // Act
            var result = wrapped
                .AsValueEnumerable()
                .Skip(count0)
                .Skip(count1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            result.SequenceEqual(expected).Must().BeTrue();
        }
        
        [Theory]
        [MemberData(nameof(TestData.Take_Take), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Take_Take_With_ValidData_Must_Succeed(int[] source, int count0, int count1)
        {
            // Arrange
            var wrapped = (ReadOnlyMemory<int>)source.AsMemory();
            var expected = source
                .Take(count0)
                .Take(count1);

            // Act
            var result = wrapped
                .AsValueEnumerable()
                .Take(count0)
                .Take(count1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            result.SequenceEqual(expected).Must().BeTrue();
        }
        
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Count_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = (ReadOnlyMemory<int>)source.AsMemory();
            var expected = source
                .Skip(skipCount)
                .Take(takeCount)
                .Count();

            // Act
            var result = wrapped
                .AsValueEnumerable()
                .Skip(skipCount)
                .Take(takeCount)
                .Count();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Sum_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = (ReadOnlyMemory<int>)source.AsMemory();
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
}