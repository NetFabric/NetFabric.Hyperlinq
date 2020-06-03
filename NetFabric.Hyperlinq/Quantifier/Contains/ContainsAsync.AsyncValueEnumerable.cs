using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static async ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer = null, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                if (comparer is null)
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                            return true;
                    }
                }
                else
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (comparer.Equals(enumerator.Current, value))
                            return true;
                    }
                }
            }
            return false;
        }

        
        static async ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                if (comparer is null)
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) 
                        && EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                            return true;
                    }
                }
                else
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) 
                        && comparer.Equals(enumerator.Current, value))
                            return true;
                    }
                }
            }
            return false;
        }

        
        static async ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                if (comparer is null)
                {
                    checked
                    {
                        for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        {
                            if (await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false) 
                            && EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                                return true;
                        }
                    }
                }
                else
                {
                    checked
                    {
                        for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        {
                            if (await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false) 
                            && comparer.Equals(enumerator.Current, value))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        
        static async ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                if (comparer is null)
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (EqualityComparer<TResult>.Default.Equals(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false), value))
                            return true;
                    }
                }
                else
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (comparer.Equals(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false), value))
                            return true;
                    }
                }
            }
            return false;
        }

        
        static async ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                if (comparer is null)
                {
                    checked
                    {
                        for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false), value))
                                return true;
                        }
                    }
                }
                else
                {
                    checked
                    {
                        for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        {
                            if (comparer.Equals(await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false), value))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        
        static async ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                if (comparer is null)
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) 
                        && EqualityComparer<TResult>.Default.Equals(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false), value))
                            return true;
                    }
                }
                else
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) 
                        && comparer.Equals(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false), value))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
