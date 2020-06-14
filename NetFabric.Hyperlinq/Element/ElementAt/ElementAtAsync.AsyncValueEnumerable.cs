using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        
        public static ValueTask<Option<TSource>> ElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, CancellationToken cancellationToken = default) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            return index < 0 
                ? new ValueTask<Option<TSource>>(Option.None) 
                : ExecuteAsync(source, index, cancellationToken);

            static async ValueTask<Option<TSource>> ExecuteAsync(TEnumerable source, int index, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (index-- == 0)
                            return Option.Some(enumerator.Current);
                    }
                }
                return Option.None;
            }
        }

        
        static ValueTask<Option<TSource>> ElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            return index < 0 
                ? new ValueTask<Option<TSource>>(Option.None) 
                : ExecuteAsync(source, index, predicate, cancellationToken);

            static async ValueTask<Option<TSource>> ExecuteAsync(TEnumerable source, int index, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) && index-- == 0)
                            return Option.Some(enumerator.Current);
                    }
                }
                return Option.None;
            }
        }

        
        static ValueTask<Option<TSource>> ElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            return index < 0 
                ? new ValueTask<Option<TSource>>(Option.None) 
                : ExecuteAsync(source, index, predicate, cancellationToken);

            static async ValueTask<Option<TSource>> ExecuteAsync(TEnumerable source, int index, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var sourceIndex = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); sourceIndex++)
                        {
                            if (await predicate(enumerator.Current, sourceIndex, cancellationToken).ConfigureAwait(false) && index-- == 0)
                                return Option.Some(enumerator.Current);
                        }
                    }
                }
                return Option.None;
            }
        }

        
        static ValueTask<Option<TResult>> ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            return index < 0 
                ? new ValueTask<Option<TResult>>(Option.None) 
                : ExecuteAsync(source, index, selector, cancellationToken);

            static async ValueTask<Option<TResult>> ExecuteAsync(TEnumerable source, int index, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (index-- == 0)
                            return Option.Some(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false));
                    }
                }
                return Option.None;
            }
        }

        
        static ValueTask<Option<TResult>> ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            return index < 0 
                ? new ValueTask<Option<TResult>>(Option.None) 
                : ExecuteAsync(source, index, selector, cancellationToken);

            static async ValueTask<Option<TResult>> ExecuteAsync(TEnumerable source, int index, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var sourceIndex = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); sourceIndex++)
                        {
                            if (sourceIndex == index)
                                return Option.Some(await selector(enumerator.Current, sourceIndex, cancellationToken).ConfigureAwait(false));
                        }
                    }
                }
                return Option.None;
            }
        }

        
        static ValueTask<Option<TResult>> ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            return index < 0 
                ? new ValueTask<Option<TResult>>(Option.None) 
                : ExecuteAsync(source, index, predicate, selector, cancellationToken);

            static async ValueTask<Option<TResult>> ExecuteAsync(TEnumerable source, int index, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) && index-- == 0)
                            return Option.Some(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false));
                    }
                }
                return Option.None;
            }
        }
    }
}
