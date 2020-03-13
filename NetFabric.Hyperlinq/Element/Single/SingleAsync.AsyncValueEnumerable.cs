using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async ValueTask<TSource> SingleAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var result = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return result.ThrowOnEmpty();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TSource> SingleAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var result = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false);
            return result.ThrowOnEmpty();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TSource> SingleAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var result = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false);
            return result.ThrowOnEmpty();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult> SingleAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var (result, value) = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return result switch
            {
                ElementResult.Empty => Throw.EmptySequence<TResult>(),
                ElementResult.Success => await selector(value, cancellationToken).ConfigureAwait(false),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult> SingleAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var (result, value) = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return result switch
            {
                ElementResult.Empty => Throw.EmptySequence<TResult>(),
                ElementResult.Success => await selector(value, 0, cancellationToken).ConfigureAwait(false),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult> SingleAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var (result, value) = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false);
            return result switch
            {
                ElementResult.Empty => Throw.EmptySequence<TResult>(),
                ElementResult.Success => await selector(value, cancellationToken).ConfigureAwait(false),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        /////////////////////////
        // SingleOrDefaultAsync

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async ValueTask<TSource> SingleOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var result = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return result.DefaultOnEmpty();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TSource> SingleOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var result = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false);
            return result.DefaultOnEmpty();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TSource> SingleOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var result = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false);
            return result.DefaultOnEmpty();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult> SingleOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var (result, value) = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return result switch
            {
                ElementResult.Empty => default,
                ElementResult.Success => await selector(value, cancellationToken).ConfigureAwait(false),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult> SingleOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var (result, value) = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
            return result switch
            {
                ElementResult.Empty => default,
                ElementResult.Success => await selector(value, 0, cancellationToken).ConfigureAwait(false),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<TResult> SingleOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var (result, value) = await GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false);
            return result switch
            {
                ElementResult.Empty => default,
                ElementResult.Success => await selector(value, cancellationToken).ConfigureAwait(false),
                _ => Throw.NotSingleSequence<TResult>(),
            };
        }

        /////////////////////////
        // GetSingleAsync

        [Pure]
        static async ValueTask<(ElementResult Success, TSource Value)> GetSingleAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false)
                    ? await enumerator.MoveNextAsync().ConfigureAwait(false) 
                        ? (ElementResult.NotSingle, default)
                        : (ElementResult.Success, enumerator.Current)
                    : (ElementResult.Empty, default);
            }
        }

        [Pure]
        static async ValueTask<(ElementResult Success, TSource Value)> GetSingleAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false))
                    {
                        var value = enumerator.Current;

                        // found first, keep going until end or find second
                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false))
                                return (ElementResult.NotSingle, default);
                        }

                        return (ElementResult.Success, value);
                    }
                }

                return (ElementResult.Empty, default);
            }
        }

        [Pure]
        static async ValueTask<(ElementResult Success, TSource Value, int Index)> GetSingleAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        if (await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                        {
                            var value = (ElementResult.Success, enumerator.Current, index);

                            // found first, keep going until end or find second
                            for (index++; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                            {
                                if (await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                                    return (ElementResult.NotSingle, default, 0);
                            }

                            return value;
                        }
                    }
                }

                return (ElementResult.Empty, default, 0);
            }
        }
    }
}
