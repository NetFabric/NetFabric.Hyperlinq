﻿using NetFabric.Assertive;
using System;
using System.Buffers;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct.ReadOnlyMemory
{
    public class Tests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = (ReadOnlyMemory<int>)source.AsMemory();
            var expected = source
                .Distinct();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Distinct();

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = (ReadOnlyMemory<int>)source.AsMemory();
            var expected = source
                .Distinct()
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Distinct()
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }

    public class MemoryDistinctEnumerableTests
        : ValueEnumerableTests<ArrayExtensions.MemoryDistinctEnumerable<int>,
            ValueEnumerableExtensions.SkipEnumerable<ArrayExtensions.MemoryDistinctEnumerable<int>, ArrayExtensions.MemoryDistinctEnumerable<int>.Enumerator, int>,
            ValueEnumerableExtensions.TakeEnumerable<ArrayExtensions.MemoryDistinctEnumerable<int>, ArrayExtensions.MemoryDistinctEnumerable<int>.Enumerator, int>,
            ValueEnumerableExtensions.WhereEnumerable<ArrayExtensions.MemoryDistinctEnumerable<int>, ArrayExtensions.MemoryDistinctEnumerable<int>.Enumerator, int, FunctionWrapper<int, bool>>,
            ValueEnumerableExtensions.WhereAtEnumerable<ArrayExtensions.MemoryDistinctEnumerable<int>, ArrayExtensions.MemoryDistinctEnumerable<int>.Enumerator, int, FunctionWrapper<int, int, bool>>
        >
    {
        public MemoryDistinctEnumerableTests() 
            : base(array => ((ReadOnlyMemory<int>)array.AsMemory()).AsValueEnumerable().Distinct())
        {}
    }
}
