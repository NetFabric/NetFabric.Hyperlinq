using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<bool> AllAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            => source.AllAsync<TEnumerable, TEnumerator, TSource, TPredicate>(default, cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<bool> AllAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => source.AllAsync<TEnumerable, TEnumerator, TSource, AsyncFunctionWrapper<TSource, bool>>(new AsyncFunctionWrapper<TSource, bool>(predicate), cancellationToken);

        public static ValueTask<bool> AllAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<bool> ExecuteAsync(TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (!await predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false))
                            return false;
                    }
                    return true;
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<bool> AllAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => source.AllAtAsync<TEnumerable, TEnumerator, TSource, AsyncFunctionWrapper<TSource, int, bool>>(new AsyncFunctionWrapper<TSource, int, bool>(predicate), cancellationToken);

        public static ValueTask<bool> AllAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, predicate, cancellationToken);

            static async ValueTask<bool> ExecuteAsync(TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
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
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
