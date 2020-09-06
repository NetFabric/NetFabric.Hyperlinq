using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<Option<TSource>> SingleAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueTask<Option<TSource>> SingleAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
            => GetSingleAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ValueTask<Option<TSource>> SingleAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
            => GetSingleAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<Option<TResult>> SingleAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var option = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return await option.SelectAsync(selector, cancellationToken).ConfigureAwait(false);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<Option<TResult>> SingleAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var option = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return await option.SelectAsync(async (item, cancellationToken) => await selector(item, 0, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<Option<TResult>> SingleAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var option = await GetSingleAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken).ConfigureAwait(false);
            return await option.SelectAsync(selector, cancellationToken).ConfigureAwait(false);
        }

        /////////////////////////
        // GetSingleAsync

        
        static async ValueTask<Option<TSource>> GetSingleAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false)
                    ? await enumerator.MoveNextAsync().ConfigureAwait(false) 
                        ? Option.None
                        : Option.Some(enumerator.Current)
                    : Option.None;
            }
        }

        
        static async ValueTask<Option<TSource>> GetSingleAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (await predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false))
                    {
                        var value = enumerator.Current;

                        // found first, keep going until end or find second
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            if (await predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false))
                                return Option.None;
                        }

                        return Option.Some(value);
                    }
                }

                return Option.None;
            }
        }

        
        static async ValueTask<Option<TSource>> GetSingleAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken) 
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
                        if (await predicate.InvokeAsync(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                        {
                            var value = enumerator.Current;

                            // found first, keep going until end or find second
                            for (index++; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                            {
                                if (await predicate.InvokeAsync(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                                    return Option.None;
                            }

                            return Option.Some(value);
                        }
                    }
                }

                return Option.None;
            }
        }
    }
}
