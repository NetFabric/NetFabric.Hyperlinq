using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        
        public static async ValueTask<TSource[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared, false);
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
            return builder.ToArray();
        }

        public static async ValueTask<ValueMemoryOwner<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ArrayPool<TSource> pool, CancellationToken cancellationToken = default, bool clearOnDispose = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(pool, clearOnDispose);
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
            return builder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TSource[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared, false);
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
            return builder.ToArray();
        }

        static async ValueTask<ValueMemoryOwner<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, CancellationToken cancellationToken, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool, clearOnDispose);
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
            return builder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TSource[]> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared, false);
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
            return builder.ToArray();
        }

        static async ValueTask<ValueMemoryOwner<TSource>> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, ArrayPool<TSource> pool, CancellationToken cancellationToken, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool, clearOnDispose);
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
            return builder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector: struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared, false);
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
            return builder.ToArray();
        }

        static async ValueTask<ValueMemoryOwner<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, CancellationToken cancellationToken, bool clearOnDispose, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector: struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(pool, clearOnDispose);
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
            return builder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector: struct, IAsyncFunction<TSource, int, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared, false);
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
            return builder.ToArray();
        }

        static async ValueTask<ValueMemoryOwner<TResult>> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, CancellationToken cancellationToken, bool clearOnDispose, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector: struct, IAsyncFunction<TSource, int, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(pool, clearOnDispose);
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
            return builder.ToArray(pool, clearOnDispose);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
            where TSelector: struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared, false);
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
            return builder.ToArray();
        }

        static async ValueTask<ValueMemoryOwner<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, ArrayPool<TResult> pool, CancellationToken cancellationToken, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
            where TSelector: struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(pool, clearOnDispose);
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
            return builder.ToArray(pool, clearOnDispose);
        }
    }
}