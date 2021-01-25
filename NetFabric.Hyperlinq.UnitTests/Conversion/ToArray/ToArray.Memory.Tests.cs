using System;
using System.Buffers;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class MemoryTests
    {

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
                .ToArray(source.AsMemory(), pool);

            // Assert
            _ = result.Memory.Must()
                .BeEqualTo(expected);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ToArray_Predicate_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Where(source.AsMemory(), predicate)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ToArray_Predicate_MemoryPool_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var pool = MemoryPool<int>.Shared;
            var expected = Enumerable
                .Where(source, predicate)
                .ToArray();

            // Act
            using var result = ArrayExtensions
                .Where(source.AsMemory(), predicate)
                .ToArray(pool);

            // Assert
            _ = result.Memory.Must()
                .BeEqualTo(expected);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_PredicateAt_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Where(source.AsMemory(), predicate)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_PredicateAt_MemoryPool_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var pool = MemoryPool<int>.Shared;
            var expected = Enumerable
                .Where(source, predicate)
                .ToArray();

            // Act
            using var result = ArrayExtensions
                .Where(source.AsMemory(), predicate)
                .ToArray(pool);

            // Assert
            _ = result.Memory.Must()
                .BeEqualTo(expected);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Selector_Must_Succeed(int[] source, Func<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector)
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Select(source.AsMemory(), selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Selector_MemoryPool_Must_Succeed(int[] source, Func<int, string> selector)
        {
            // Arrange
            var pool = MemoryPool<string>.Shared;
            var expected = Enumerable
                .Select(source, selector)
                .ToArray();

            // Act
            using var result = ArrayExtensions
                .Select(source.AsMemory(), selector)
                .ToArray(pool);

            // Assert
            _ = result.Memory.Must()
                .BeEqualTo(expected);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_SelectorAt_Must_Succeed(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Select(source, selector)
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Select(source.AsMemory(), selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_SelectorAt_MemoryPool_Must_Succeed(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var pool = MemoryPool<string>.Shared;
            var expected = Enumerable
                .Select(source, selector)
                .ToArray();

            // Act
            using var result = ArrayExtensions
                .Select(source.AsMemory(), selector)
                .ToArray(pool);

            // Assert
            _ = result.Memory.Must()
                .BeEqualTo(expected);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Predicate_Selector_Must_Succeed(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate)
                .Select(selector)
                .ToArray();

            // Act
            var result = ArrayExtensions
                .Where(source.AsMemory(), predicate)
                .Select(selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Predicate_Selector_MemoryPool_Must_Succeed(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var pool = MemoryPool<string>.Shared;
            var expected = Enumerable
                .Where(source, predicate)
                .Select(selector)
                .ToArray();

            // Act
            using var result = ArrayExtensions
                .Where(source.AsMemory(), predicate)
                .Select(selector)
                .ToArray(pool);

            // Assert
            _ = result.Memory.Must()
                .BeEqualTo(expected);
        }
    }
}