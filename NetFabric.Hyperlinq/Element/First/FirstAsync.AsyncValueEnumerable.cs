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
        public static async ValueTask<TSource> FirstAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var result = await GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return result.ThrowOnEmpty();
        }

        [Pure]
        public static ValueTask<TSource> FirstAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<TSource> ExecuteAsync(TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            {
                var result = await GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false);
                return result.ThrowOnEmpty();
            }
        }

        [Pure]
        public static async ValueTask<TSource> FirstOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var result = await GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return result.DefaultOnEmpty();
        }

        [Pure]
        public static ValueTask<TSource> FirstOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<TSource> ExecuteAsync(TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            {
                var result = await GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false);
                return result.DefaultOnEmpty();
            }
        }

        [Pure]
        static async ValueTask<(ElementResult Success, TSource Value)> GetFirstAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false)
                    ? (ElementResult.Success, enumerator.Current)
                    : (ElementResult.Empty, default);
            }
        }

        [Pure]
        static async ValueTask<(ElementResult Success, TSource Value)> GetFirstAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        return (ElementResult.Success, item);
                }   

                return (ElementResult.Empty, default);
            }
        }

        [Pure]
        static async ValueTask<(int Index, TSource Value)> GetFirstAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate(item, index, cancellationToken).ConfigureAwait(false))
                            return (index, item);
                    }
                }   

                return ((int)ElementResult.Empty, default);
            }
        }    
    }
}
