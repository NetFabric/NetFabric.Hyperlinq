using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        public static ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncAction<TSource> actionAsync, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (actionAsync is null) Throw.ArgumentNullException(nameof(actionAsync));

            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, actionAsync, cancellationToken);

            static async ValueTask ExecuteAsync(TEnumerable source, AsyncAction<TSource> actionAsync, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using(enumerator.ConfigureAwait(false))
                { 
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        await actionAsync(enumerator.Current, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncAction<TSource> actionAsync, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        await actionAsync(item, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncAction<TSource> actionAsync, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate(item, index, cancellationToken).ConfigureAwait(false))
                            await actionAsync(item, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncAction<TResult> actionAsync, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    await actionAsync(await selector(enumerator.Current, cancellationToken), cancellationToken).ConfigureAwait(false);
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncAction<TResult> actionAsync, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(await selector(enumerator.Current, index, cancellationToken), cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncAction<TResult> actionAsync, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        await actionAsync(await selector(item, cancellationToken), cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public static ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncActionAt<TSource> actionAsync, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (actionAsync is null) Throw.ArgumentNullException(nameof(actionAsync));

            return ExecuteAsync(source, actionAsync, cancellationToken);

            static async ValueTask ExecuteAsync(TEnumerable source, AsyncActionAt<TSource> actionAsync, CancellationToken cancellationToken1)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken1);
                await using (enumerator.ConfigureAwait(false)) 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(enumerator.Current, index, cancellationToken1).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncActionAt<TSource> actionAsync, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate(item, cancellationToken).ConfigureAwait(false))
                            await actionAsync(item, index, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncActionAt<TSource> actionAsync, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate(item, index, cancellationToken).ConfigureAwait(false))
                            await actionAsync(item, index, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncActionAt<TResult> actionAsync, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(await selector(enumerator.Current, cancellationToken), index, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncActionAt<TResult> actionAsync, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(
                            await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false), 
                            index, 
                            cancellationToken)
                                .ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncActionAt<TResult> actionAsync, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        {
                            var projectedItem = await selector(item, cancellationToken).ConfigureAwait(false);
                            await actionAsync(projectedItem, index, cancellationToken).ConfigureAwait(false);
                        }
                    }
                }
            }
        }
    }
}

