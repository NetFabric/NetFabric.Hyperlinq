using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => (await source.ToArrayAsync<TEnumerable, TEnumerator, TSource>(cancellationToken).ConfigureAwait(false)).AsList();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            => (await source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken).ConfigureAwait(false)).AsList();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TSource>> ToListAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
            => (await source.ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken).ConfigureAwait(false)).AsList();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => (await source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector, cancellationToken).ConfigureAwait(false)).AsList();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int, TResult>
            => (await source.ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector, cancellationToken).ConfigureAwait(false)).AsList();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => (await source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector, cancellationToken).ConfigureAwait(false)).AsList();
    }
}
