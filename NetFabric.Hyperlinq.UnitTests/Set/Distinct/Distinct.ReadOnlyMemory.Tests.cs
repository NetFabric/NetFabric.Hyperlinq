using NetFabric.Assertive;
using System;
using System.Buffers;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct
{
    public class ReadOnlyMemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.Distinct(source);

            // Act
            var result = ArrayExtensions
                .Distinct((ReadOnlyMemory<int>)source.AsMemory());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_ToArray_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Distinct(source));

            // Act
            var result = ArrayExtensions
                .Distinct((ReadOnlyMemory<int>)source.AsMemory())
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
            var pool = MemoryPool<int>.Shared;
            var expected =
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Distinct(source));

            // Act
            using var result = ArrayExtensions
                .Distinct((ReadOnlyMemory<int>)source.AsMemory())
                .ToArray(pool);

            // Assert
            _ = result
                .SequenceEqual(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_ToList_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected =
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Distinct(source));

            // Act
            var result = ArrayExtensions
                .Distinct((ReadOnlyMemory<int>)source.AsMemory())
                .ToList();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}
