using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => (await source.ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(ArrayPool<TSource>.Shared, cancellationToken).ConfigureAwait(false)).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async ValueTask<IMemoryOwner<TSource>> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, MemoryPool<TSource> pool, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => (await source.ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(ArrayPool<TSource>.Shared, cancellationToken).ConfigureAwait(false)).ToArray(pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            => (await source.ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(ArrayPool<TSource>.Shared, cancellationToken, predicate).ConfigureAwait(false)).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<IMemoryOwner<TSource>> ToArrayAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, MemoryPool<TSource> pool, CancellationToken cancellationToken, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            => (await source.ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(ArrayPool<TSource>.Shared, cancellationToken, predicate).ConfigureAwait(false)).ToArray(pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TSource[]> ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
            => (await source.ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(ArrayPool<TSource>.Shared, cancellationToken, predicate).ConfigureAwait(false)).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<IMemoryOwner<TSource>> ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, MemoryPool<TSource> pool, CancellationToken cancellationToken, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
            => (await source.ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(ArrayPool<TSource>.Shared, cancellationToken, predicate).ConfigureAwait(false)).ToArray(pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult[]> ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => (await source.ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(ArrayPool<TResult>.Shared, cancellationToken, selector).ConfigureAwait(false)).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<IMemoryOwner<TResult>> ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, MemoryPool<TResult> pool, CancellationToken cancellationToken, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => (await source.ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(ArrayPool<TResult>.Shared, cancellationToken, selector).ConfigureAwait(false)).ToArray(pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult[]> ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int, TResult>
            => (await source.ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(ArrayPool<TResult>.Shared, cancellationToken, selector).ConfigureAwait(false)).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<IMemoryOwner<TResult>> ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, MemoryPool<TResult> pool, CancellationToken cancellationToken, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int, TResult>
            => (await source.ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(ArrayPool<TResult>.Shared, cancellationToken, selector).ConfigureAwait(false)).ToArray(pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult[]> ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => (await source.ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(ArrayPool<TResult>.Shared, cancellationToken, predicate, selector).ConfigureAwait(false)).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<IMemoryOwner<TResult>> ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, MemoryPool<TResult> pool, CancellationToken cancellationToken, TPredicate predicate, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => (await source.ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(ArrayPool<TResult>.Shared, cancellationToken, predicate, selector).ConfigureAwait(false)).ToArray(pool);
    }
}