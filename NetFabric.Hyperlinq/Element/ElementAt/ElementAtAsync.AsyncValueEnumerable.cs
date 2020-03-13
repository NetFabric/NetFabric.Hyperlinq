using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        /////////////////
        // ElementAtAsync

        [Pure]
        public static ValueTask<TSource> ElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index < 0) Throw.ArgumentOutOfRangeException(nameof(index));

            return ExecuteAsync(source, index, cancellationToken);

            static async ValueTask<TSource> ExecuteAsync(TEnumerable source, int index, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (index-- == 0)
                            return enumerator.Current;
                    }
                }
                return Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
            }
        }

        [Pure]
        static ValueTask<TSource> ElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index < 0) Throw.ArgumentOutOfRangeException(nameof(index));

            return ExecuteAsync(source, index, predicate, cancellationToken);

            static async ValueTask<TSource> ExecuteAsync(TEnumerable source, int index, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) && index-- == 0)
                            return enumerator.Current;
                    }
                }
                return Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
            }
        }

        [Pure]
        static ValueTask<TSource> ElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index < 0) Throw.ArgumentOutOfRangeException(nameof(index));

            return ExecuteAsync(source, index, predicate, cancellationToken);

            static async ValueTask<TSource> ExecuteAsync(TEnumerable source, int index, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var itemIndex = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); itemIndex++)
                        {
                            if (await predicate(enumerator.Current, itemIndex, cancellationToken).ConfigureAwait(false) && index-- == 0)
                                return enumerator.Current;
                        }
                    }
                }
                return Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
            }
        }

        [Pure]
        static ValueTask<TResult> ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index < 0) Throw.ArgumentOutOfRangeException(nameof(index));

            return ExecuteAsync(source, index, selector, cancellationToken);

            static async ValueTask<TResult> ExecuteAsync(TEnumerable source, int index, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (index-- == 0)
                            return await selector(enumerator.Current, cancellationToken).ConfigureAwait(false);
                    }
                }
                return Throw.ArgumentOutOfRangeException<TResult>(nameof(index));
            }
        }

        [Pure]
        static ValueTask<TResult> ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index < 0) Throw.ArgumentOutOfRangeException(nameof(index));

            return ExecuteAsync(source, index, selector, cancellationToken);

            static async ValueTask<TResult> ExecuteAsync(TEnumerable source, int index, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var itemIndex = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); itemIndex++)
                        {
                            if (itemIndex == index)
                                return await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false);
                        }
                    }
                }
                return Throw.ArgumentOutOfRangeException<TResult>(nameof(index));
            }
        }

        [Pure]
        static ValueTask<TResult> ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index < 0) Throw.ArgumentOutOfRangeException(nameof(index));

            return ExecuteAsync(source, index, predicate, selector, cancellationToken);

            static async ValueTask<TResult> ExecuteAsync(TEnumerable source, int index, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) && index-- == 0)
                            return await selector(enumerator.Current, cancellationToken).ConfigureAwait(false);
                    }
                }
                return Throw.ArgumentOutOfRangeException<TResult>(nameof(index));
            }
        }

        /////////////////
        // ElementAtOrDefaultAsync

        [Pure]
        [return: MaybeNull]
        public static async ValueTask<TSource> ElementAtOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0) 
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (index == 0)
                            return enumerator.Current;
                    }
                }
            }
            return default!;
        }

        [Pure]
        [return: MaybeNull]
        static async ValueTask<TSource> ElementAtOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0) 
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) && index-- == 0)
                            return enumerator.Current;
                    }
                }
            }
            return default!;
        }

        [Pure]
        [return: MaybeNull]
        static async ValueTask<TSource> ElementAtOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0) 
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var itemIndex = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); itemIndex++)
                        {
                            if (await predicate(enumerator.Current, itemIndex, cancellationToken).ConfigureAwait(false) && index-- == 0)
                                return enumerator.Current;
                        }
                    }
                }
            }
            return default!;
        }

        [Pure]
        [return: MaybeNull]
        static async ValueTask<TResult> ElementAtOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0) 
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (index-- == 0)
                            return await selector(enumerator.Current, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            return default!;
        }

        [Pure]
        [return: MaybeNull]
        static async ValueTask<TResult> ElementAtOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0) 
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    checked
                    {
                        for (var itemIndex = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); itemIndex++)
                        {
                            if (itemIndex == index)
                                return await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false);
                        }
                    }
                }
            }
            return default!;
        }

        [Pure]
        [return: MaybeNull]
        static async ValueTask<TResult> ElementAtOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0) 
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false) && index-- == 0)
                            return await selector(enumerator.Current, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            return default!;
        }
    }
}
