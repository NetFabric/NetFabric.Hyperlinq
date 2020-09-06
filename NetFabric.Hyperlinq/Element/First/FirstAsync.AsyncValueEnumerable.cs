using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        
        public static async ValueTask<Option<TSource>> FirstAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false) 
                    ? Option.Some(enumerator.Current)
                    : Option.None;
            }
        }

        
        static async ValueTask<Option<TSource>> FirstAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        return Option.Some(item);
                }   
            }
            return Option.None;
        }

        
        static async ValueTask<Option<TSource>> FirstAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false))
                            return Option.Some(item);
                    }   
                }
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async ValueTask<Option<TResult>> FirstAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false) 
                    ? Option.Some(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false))
                    : Option.None;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async ValueTask<Option<TResult>> FirstAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false) 
                    ? Option.Some(await selector(enumerator.Current, 0, cancellationToken).ConfigureAwait(false))
                    : Option.None;
            }
        }

        
        static async ValueTask<Option<TResult>> FirstAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        return Option.Some(await selector(item, cancellationToken).ConfigureAwait(false));
                }   
            }
            return Option.None;
        }
    }
}
