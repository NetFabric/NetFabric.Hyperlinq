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
        public static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                var list = new List<TSource>();
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    list.Add(enumerator.Current);
                return list;
            }
        }

        [Pure]
        static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                var list = new List<TSource>();
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false))
                        list.Add(enumerator.Current);
                }
                return list;
            }
        }

        [Pure]
        static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    var list = new List<TSource>();
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        if (await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                            list.Add(enumerator.Current);
                    }
                    return list;
                }
            }
        }

        [Pure]
    static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                var list = new List<TResult>();
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    list.Add(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false));
                return list;
            }
        }

        [Pure]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    var list = new List<TResult>();
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        list.Add(await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false));
                    return list;
                }
            }
        }

        [Pure]
        static async ValueTask<List<TResult>> ToListAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                var list = new List<TResult>();
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false))
                        list.Add(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false));
                }
                return list;
            }
        }
    }
}
