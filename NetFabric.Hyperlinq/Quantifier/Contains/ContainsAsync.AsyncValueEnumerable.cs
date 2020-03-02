using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        [Pure]
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

        [Pure]
        static async ValueTask<bool> Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer, Predicate<TSource> predicate, CancellationToken cancellationToken)
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
                        if (predicate(enumerator.Current) && EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                            return true;
                    }
                }
                else
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (predicate(enumerator.Current) && comparer.Equals(enumerator.Current, value))
                            return true;
                    }
                }
            }
            return false;
        }

        [Pure]
        static async ValueTask<bool> Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer, PredicateAt<TSource> predicate, CancellationToken cancellationToken)
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
                            if (predicate(enumerator.Current, index) && EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
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
                            if (predicate(enumerator.Current, index) && comparer.Equals(enumerator.Current, value))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        [Pure]
        static async ValueTask<bool> Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, Selector<TSource, TResult> selector, CancellationToken cancellationToken)
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
                        if (EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current), value))
                            return true;
                    }
                }
                else
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (comparer.Equals(selector(enumerator.Current), value))
                            return true;
                    }
                }
            }
            return false;
        }

        [Pure]
        static async ValueTask<bool> Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, SelectorAt<TSource, TResult> selector, CancellationToken cancellationToken)
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
                            if (EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current, index), value))
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
                            if (comparer.Equals(selector(enumerator.Current, index), value))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        [Pure]
        static async ValueTask<bool> Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, Predicate<TSource> predicate, Selector<TSource, TResult> selector, CancellationToken cancellationToken)
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
                        if (predicate(enumerator.Current) && EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current), value))
                            return true;
                    }
                }
                else
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (predicate(enumerator.Current) && comparer.Equals(selector(enumerator.Current), value))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
