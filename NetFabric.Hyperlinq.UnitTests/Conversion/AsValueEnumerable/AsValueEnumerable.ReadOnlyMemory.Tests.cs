using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.ReadOnlyMemory
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
            var wrapped = (ReadOnlyMemory<int>)source.AsMemory();

            // Act
            var result = wrapped
                .AsValueEnumerable();

            // Assert
            result.Must().BeEnumerableOf<int>().BeEqualTo(source);
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

    public class MemoryValueEnumerableTests
        : ValueEnumerableTests<
            ArrayExtensions.MemoryValueEnumerable<int>,
            ValueEnumerableExtensions.WhereEnumerable<ArrayExtensions.MemoryValueEnumerable<int>, ArrayExtensions.MemoryValueEnumerable<int>.DisposableEnumerator, int, FunctionWrapper<int, bool>>,
            ValueEnumerableExtensions.WhereAtEnumerable<ArrayExtensions.MemoryValueEnumerable<int>, ArrayExtensions.MemoryValueEnumerable<int>.DisposableEnumerator, int, FunctionWrapper<int, int, bool>>>
    {
        public MemoryValueEnumerableTests() 
            : base(array => ((ReadOnlyMemory<int>)array.AsMemory()).AsValueEnumerable())
        {}
    }
}