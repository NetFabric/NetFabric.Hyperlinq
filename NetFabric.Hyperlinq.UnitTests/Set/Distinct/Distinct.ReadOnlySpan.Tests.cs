using NetFabric.Assertive;
using System;
using System.Buffers;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct
{
    public class ReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .Distinct(source);

            // Act
            var result = ArrayExtensions
                .Distinct((ReadOnlySpan<int>)source.AsSpan());

            // Assert
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_ToArray_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .Distinct(source)
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Distinct((ReadOnlySpan<int>)source.AsSpan())
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_ToArray_MemoryPool_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .Distinct(source)
                .ToArray();

            // Act
            using var result = ArrayExtensions
                .Distinct(source)
                .ToArray(MemoryPool<int>.Shared);

            // Assert
            _ = result.Memory.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_ToList_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .Distinct(source)
                .ToList();

            // Act
            var result = ArrayExtensions
                .Distinct<int>((ReadOnlySpan<int>)source.AsSpan())
                .ToList();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}
