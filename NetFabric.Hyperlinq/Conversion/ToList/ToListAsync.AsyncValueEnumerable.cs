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
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var list = new List<TSource>();
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    list.Add(enumerator.Current);
            }
            return list;
        }

        [Pure]
        static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var list = new List<TSource>();
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (predicate(enumerator.Current))
                        list.Add(enumerator.Current);
                }
            }
            return list;
        }

        [Pure]
        static async ValueTask<List<TSource>> ToListAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            cancellationToken.ThrowIfCancellationRequested();

            var list = new List<TSource>();
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        if (predicate(enumerator.Current, index))
                            list.Add(enumerator.Current);
                    }
                }
            }
            return list;
        }
    }
}
