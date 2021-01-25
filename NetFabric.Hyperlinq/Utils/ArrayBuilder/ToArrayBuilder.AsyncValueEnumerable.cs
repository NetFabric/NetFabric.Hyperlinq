using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {

        static async ValueTask<LargeArrayBuilder<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ArrayPool<TSource> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    builder.Add(enumerator.Current);
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, ArrayPool<TSource> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        builder.Add(item);
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TSource>> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, ArrayPool<TSource> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        var item = enumerator.Current;
                        if (await predicate.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false))
                            builder.Add(item);
                    }
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, ArrayPool<TResult> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    builder.Add(await selector.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false));
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TResult>> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, ArrayPool<TResult> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        builder.Add(await selector.InvokeAsync(enumerator.Current, index, cancellationToken).ConfigureAwait(false));
                    }
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector, ArrayPool<TResult> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        builder.Add(await selector.InvokeAsync(item, cancellationToken).ConfigureAwait(false));
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return builder;
        }
    }
}
