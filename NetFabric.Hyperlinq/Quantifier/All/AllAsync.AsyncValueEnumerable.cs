using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        public static ValueTask<bool> AllAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return AllAsync<TEnumerable, TEnumerator, TSource, AsyncValuePredicate<TSource>>(source, new AsyncValuePredicate<TSource>(predicate), cancellationToken);
        }
        
        public static ValueTask<bool> AllAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<bool> ExecuteAsync(TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (!await predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false))
                            return false;
                    }
                    return true;
                }
            }
        }

        public static ValueTask<bool> AllAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return AllAtAsync<TEnumerable, TEnumerator, TSource, AsyncValuePredicateAt<TSource>>(source, new AsyncValuePredicateAt<TSource>(predicate), cancellationToken);
        }
        
        public static ValueTask<bool> AllAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<bool> ExecuteAsync(TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        {
                            if (!await predicate.InvokeAsync(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                                return false;
                        }
                    }
                    return true;
                }
            }
        }
    }
}
