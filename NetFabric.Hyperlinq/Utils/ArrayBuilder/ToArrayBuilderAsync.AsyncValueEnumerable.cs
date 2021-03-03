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
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
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

        public static async ValueTask<IMemoryOwner<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, MemoryPool<TSource> pool, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
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
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TSource[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
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

        static async ValueTask<IMemoryOwner<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, MemoryPool<TSource> pool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
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
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TSource[]> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
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

        static async ValueTask<IMemoryOwner<TSource>> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, MemoryPool<TSource> pool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
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
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector: struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
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

        static async ValueTask<IMemoryOwner<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, MemoryPool<TResult> pool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector: struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
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
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector: struct, IAsyncFunction<TSource, int, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
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

        static async ValueTask<IMemoryOwner<TResult>> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, MemoryPool<TResult> pool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector: struct, IAsyncFunction<TSource, int, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
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
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
            where TSelector: struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
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

        static async ValueTask<IMemoryOwner<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate: struct, IAsyncFunction<TSource, bool>
            where TSelector: struct, IAsyncFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
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
            return builder.ToArray(pool);
        }
    }
}