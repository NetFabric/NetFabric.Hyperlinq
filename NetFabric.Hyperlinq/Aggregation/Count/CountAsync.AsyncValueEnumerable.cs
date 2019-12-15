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
        public static async ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var count = 0;
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        count++;
                }
            }
            return count;
        }

        [Pure]
        public static ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<int> ExecuteAsync(TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            {
                var count = 0;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            if (await predicate(enumerator.Current, cancellationToken))
                                count++;
                        }
                    }
                }
                return count;
            }
        }

        [Pure]
        public static ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<int> ExecuteAsync(TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            {
                var count = 0;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        {
                            if (await predicate(enumerator.Current, index, cancellationToken))
                                count++;
                        }
                    }
                }
                return count;
            }
        }
    }
}
