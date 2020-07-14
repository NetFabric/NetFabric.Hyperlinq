using NetFabric.Assertive;
using System;
using System.Buffers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ToArrayAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_MemoryPool_Must_Succeed(int[] source)
        {
            // Arrange
            var pool = MemoryPool<int>.Shared;
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ToArrayAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_Predicate_MemoryPool_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var pool = MemoryPool<int>.Shared;
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ToArrayAsync(pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_PredicateAt_MemoryPool_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var pool = MemoryPool<int>.Shared;
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ToArrayAsync(pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_Selector_With_ValidData_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_Selector_MemoryPool_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var pool = MemoryPool<string>.Shared;
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ToArrayAsync(pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_SelectorAt_With_ValidData_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_SelectorAt_MemoryPool_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var pool = MemoryPool<string>.Shared;
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ToArrayAsync(pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .Select(selector.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ToArrayAsync_Predicate_Selector_MemoryPool_Must_Succeed(int[] source, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var pool = MemoryPool<string>.Shared;
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .Select(selector.AsFunc())
                .ToArray();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .ToArrayAsync(pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }
    }
}