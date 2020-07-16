using NetFabric.Assertive;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct
{
    public class ArrayTests
    {
        [Theory]
        [InlineData(200)]
        public void Distinct_With_LargeData_Must_Succeed(int count)
        {
            // Arrange
            var source = ValueEnumerable.Range(0, count).ToArray();
            var expected = Enumerable
                .Distinct(source);

            // Act
            var result = ArrayExtensions
                .Distinct(source);

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
        public void Distinct_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = Enumerable
                .Distinct(source);

            // Act
            var result = ArrayExtensions
                .Distinct(source);

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
            var expected = Enumerable
                .Distinct(source)
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Distinct(source)
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
            var expected = Enumerable
                .Distinct(source)
                .ToArray();

            // Act
            using var result = ArrayExtensions
                .Distinct(source)
                .ToArray(pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
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
                .Distinct(source)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}
