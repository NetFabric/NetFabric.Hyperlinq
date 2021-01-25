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
            // ReSharper disable once HeapView.BoxingAllocation
            => new(collection: await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(source, ArrayPool<TSource>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            // ReSharper disable once HeapView.BoxingAllocation
            => new(collection: await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, ArrayPool<TSource>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TSource>> ToListAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
            // ReSharper disable once HeapView.BoxingAllocation
            => new(collection: await ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, ArrayPool<TSource>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            // ReSharper disable once HeapView.BoxingAllocation
            => new(collection: await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector, ArrayPool<TResult>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int, TResult>
            // ReSharper disable once HeapView.BoxingAllocation
            => new(collection: await ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector, ArrayPool<TResult>.Shared, cancellationToken).ConfigureAwait(false));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            // ReSharper disable once HeapView.BoxingAllocation
            => new(collection: await ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector, ArrayPool<TResult>.Shared, cancellationToken).ConfigureAwait(false));
    }
}
