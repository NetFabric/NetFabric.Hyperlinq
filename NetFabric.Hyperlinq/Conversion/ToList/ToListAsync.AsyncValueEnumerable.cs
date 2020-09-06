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
        public static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new List<TSource>(await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(source, ArrayPool<TSource>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
            => new List<TSource>(await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, ArrayPool<TSource>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TSource>> ToListAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
            => new List<TSource>(await ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, ArrayPool<TSource>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new List<TResult>(await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, ArrayPool<TResult>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new List<TResult>(await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, ArrayPool<TResult>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
            => new List<TResult>(await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, ArrayPool<TResult>.Shared, cancellationToken).ConfigureAwait(false));
    }
}
