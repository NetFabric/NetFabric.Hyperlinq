﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        public static async ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var counter = 0;
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                checked
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        counter++;
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return counter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => source.CountAsync<TEnumerable, TEnumerator, TSource, AsyncFunctionWrapper<TSource, bool>>(new AsyncFunctionWrapper<TSource, bool>(predicate), cancellationToken);

        public static async ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
        {
            var counter = 0;
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                checked
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var result = await predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false);
                        counter += result.AsByte();
                    }
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return counter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => source.CountAtAsync<TEnumerable, TEnumerator, TSource, AsyncFunctionWrapper<TSource, int, bool>>(new AsyncFunctionWrapper<TSource, int, bool>(predicate), cancellationToken);

        public static async ValueTask<int> CountAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, int, bool>
        {
            var counter = 0;
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var result = await predicate.InvokeAsync(enumerator.Current, index, cancellationToken).ConfigureAwait(false);
                        counter += result.AsByte();
                    }
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return counter;
        }
    }
}
