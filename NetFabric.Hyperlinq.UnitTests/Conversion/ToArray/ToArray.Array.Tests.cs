using System;
using System.Buffers;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = ArrayExtensions
                .ToArray(source);

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_MemoryPool_Must_Succeed(int[] source)
        {
            // Arrange
            var pool = MemoryPool<int>.Shared;
            var expected = Enumerable
                .ToArray(source);

            // Act
            using var result = ArrayExtensions
                .ToArray(source, pool);

            // Assert
            _ = result.Memory
                .SequenceEqual(expected);
        }
    }
}