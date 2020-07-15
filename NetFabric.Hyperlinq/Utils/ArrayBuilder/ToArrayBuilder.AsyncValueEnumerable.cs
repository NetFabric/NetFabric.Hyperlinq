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

        static async ValueTask<LargeArrayBuilder<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(TEnumerable source, ArrayPool<TSource> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            var enumerator = source.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    builder.Add(enumerator.Current);
                }
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(TEnumerable source, AsyncPredicate<TSource> predicate, ArrayPool<TSource> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            var enumerator = source.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        builder.Add(item);
                }
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TSource>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource>(TEnumerable source, AsyncPredicateAt<TSource> predicate, ArrayPool<TSource> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            var enumerator = source.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        var item = enumerator.Current;
                        if (await predicate(item, index, cancellationToken).ConfigureAwait(false))
                            builder.Add(item);
                    }
                }
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, AsyncSelector<TSource, TResult> selector, ArrayPool<TResult> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            var enumerator = source.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    builder.Add(await selector(enumerator.Current, cancellationToken).ConfigureAwait(false));
                }
            }
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, ArrayPool<TResult> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            var enumerator = source.GetAsyncEnumerator();
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
            return builder;
        }

        static async ValueTask<LargeArrayBuilder<TResult>> ToArrayBuilderAsync<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, ArrayPool<TResult> arrayPool, CancellationToken cancellationToken)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            var enumerator = source.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        builder.Add(await selector(item, cancellationToken).ConfigureAwait(false));
                }
            }
            return builder;
        }
    }
}
