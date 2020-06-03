using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static async ValueTask<bool> AnyAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false);
            }
        }

        
        public static ValueTask<bool> AnyAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<bool> ExecuteAsync(TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false))
                            return true;
                    }
                    return false;
                }
            }
        }

        public static ValueTask<bool> AnyAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<bool> ExecuteAsync(TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        {
                            if (await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                                return true;
                        }
                    }
                    return false;
                }
            }
        }
    }
}
