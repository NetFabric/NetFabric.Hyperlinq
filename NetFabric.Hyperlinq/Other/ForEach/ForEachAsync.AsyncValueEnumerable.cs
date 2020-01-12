using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        public static ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, CancellationToken, ValueTask> actionAsync, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (actionAsync is null) Throw.ArgumentNullException(nameof(actionAsync));

            return ExecuteAsync(source, actionAsync, cancellationToken);

            static async ValueTask ExecuteAsync(TEnumerable source, Func<TSource, CancellationToken, ValueTask> actionAsync, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using(enumerator.ConfigureAwait(false))
                { 
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        await actionAsync(enumerator.Current, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, CancellationToken, ValueTask> actionAsync, Predicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (predicate(enumerator.Current))
                        await actionAsync(enumerator.Current, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, CancellationToken, ValueTask> actionAsync, PredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        if (predicate(enumerator.Current, index))
                            await actionAsync(enumerator.Current, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TResult, CancellationToken, ValueTask> actionAsync, Selector<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    await actionAsync(selector(enumerator.Current), cancellationToken).ConfigureAwait(false);
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TResult, CancellationToken, ValueTask> actionAsync, SelectorAt<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(selector(enumerator.Current, index), cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TResult, CancellationToken, ValueTask> actionAsync, Predicate<TSource> predicate, Selector<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (predicate(enumerator.Current))
                        await actionAsync(selector(enumerator.Current), cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public static ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, CancellationToken, ValueTask> actionAsync, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (actionAsync is null) Throw.ArgumentNullException(nameof(actionAsync));

            return ExecuteAsync(source, actionAsync, cancellationToken);

            static async ValueTask ExecuteAsync(TEnumerable source, Func<TSource, int, CancellationToken, ValueTask> actionAsync, CancellationToken cancellationToken1)
            {
                var enumerator = source.GetAsyncEnumerator();
                await using (enumerator.ConfigureAwait(false)) 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(enumerator.Current, index, cancellationToken1);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, CancellationToken, ValueTask> actionAsync, Predicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        if (predicate(enumerator.Current))
                            await actionAsync(enumerator.Current, index, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, CancellationToken, ValueTask> actionAsync, PredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        if (predicate(enumerator.Current, index))
                            await actionAsync(enumerator.Current, index, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TResult, int, CancellationToken, ValueTask> actionAsync, Selector<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(selector(enumerator.Current), index, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TResult, int, CancellationToken, ValueTask> actionAsync, SelectorAt<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(selector(enumerator.Current, index), index, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        static async ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TResult, int, CancellationToken, ValueTask> actionAsync, Predicate<TSource> predicate, Selector<TSource, TResult> selector, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using(enumerator.ConfigureAwait(false))
            { 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        if (predicate(enumerator.Current))
                            await actionAsync(selector(enumerator.Current), index, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
        }
    }
}

