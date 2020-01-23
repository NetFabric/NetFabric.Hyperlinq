using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        [Pure]
        public static async ValueTask<long> LongCountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var count = 0L;
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
        public static ValueTask<long> LongCountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<long> ExecuteAsync(TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            {
                var count = 0L;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            var result = await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false);
                            count += Unsafe.As<bool, byte>(ref result);
                        }
                    }
                }
                return count;
            }
        }

        [Pure]
        public static ValueTask<long> LongCountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAtLong<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<long> ExecuteAsync(TEnumerable source, AsyncPredicateAtLong<TSource> predicate, CancellationToken cancellationToken)
            {
                var count = 0L;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var index = 0L; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        {
                            var result = await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false);
                            count += Unsafe.As<bool, byte>(ref result);
                        }
                    }
                }
                return count;
            }
        }
    }
}
