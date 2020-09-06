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
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    builder.Add(enumerator.Current);
                }
            }
            return builder.ToArray();
        }

        public static async ValueTask<IMemoryOwner<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, MemoryPool<TSource> pool, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    builder.Add(enumerator.Current);
                }
            }
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TSource[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        builder.Add(item);
                }
            }
            return builder.ToArray();
        }

        static async ValueTask<IMemoryOwner<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, MemoryPool<TSource> pool, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        builder.Add(item);
                }
            }
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TSource[]> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
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
            return builder.ToArray();
        }

        static async ValueTask<IMemoryOwner<TSource>> ToArrayBuilderAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, MemoryPool<TSource> pool, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(ArrayPool<TSource>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
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
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    builder.Add(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false));
                }
            }
            return builder.ToArray();
        }

        static async ValueTask<IMemoryOwner<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, MemoryPool<TResult> pool, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    builder.Add(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false));
                }
            }
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        builder.Add(await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false));
                    }
                }
            }
            return builder.ToArray();
        }

        static async ValueTask<IMemoryOwner<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        builder.Add(await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false));
                    }
                }
            }
            return builder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        static async ValueTask<TResult[]> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        builder.Add(await selector(item, cancellationToken).ConfigureAwait(false));
                }
            }
            return builder.ToArray();
        }

        static async ValueTask<IMemoryOwner<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, TPredicate predicate, AsyncSelector<TSource, TResult> selector, MemoryPool<TResult> pool, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(ArrayPool<TResult>.Shared);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        builder.Add(await selector(item, cancellationToken).ConfigureAwait(false));
                }
            }
            return builder.ToArray(pool);
        }
    }
}