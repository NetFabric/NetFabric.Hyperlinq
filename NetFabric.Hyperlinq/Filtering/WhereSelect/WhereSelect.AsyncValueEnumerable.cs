using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        [Pure]
        static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            AsyncPredicate<TSource> predicate,
            AsyncSelector<TSource, TResult> selector)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> 
            : IAsyncValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly AsyncPredicate<TSource> predicate;
            readonly AsyncSelector<TSource, TResult> selector;

            internal WhereSelectEnumerable(in TEnumerable source, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new Enumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<TResult> IAsyncEnumerable<TResult>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new Enumerator(in this, cancellationToken);

            public struct Enumerator
                : IAsyncEnumerator<TResult>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly AsyncPredicate<TSource> predicate;
                readonly AsyncSelector<TSource, TResult> selector;
                readonly CancellationToken cancellationToken;
                TResult current;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    this.cancellationToken = cancellationToken;
                    current = default!;
                }

                [MaybeNull]
                public readonly TResult Current
                    => current;
                
                public async ValueTask<bool> MoveNextAsync()
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var item = enumerator.Current;
                        if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        {
                            current = await selector(item, cancellationToken).ConfigureAwait(false);
                            return true;
                        }
                    }
                    await DisposeAsync().ConfigureAwait(false);
                    return false;
                }

                public ValueTask DisposeAsync() 
                    => enumerator.DisposeAsync();
            }

            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.CountAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);

            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);
                
            public ValueTask<bool> ContainsAsync(TResult value, IEqualityComparer<TResult>? comparer = null, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ContainsAsync<TEnumerable, TEnumerator, TSource, TResult>(source, value, comparer, predicate, selector, cancellationToken);

            [Pure]
            public ValueTask<TResult> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult>(source, index, predicate, selector, cancellationToken);

            [Pure]
            [return: MaybeNull]
            public ValueTask<TResult> ElementAtOrDefaultAsync(int index, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ElementAtOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(source, index, predicate, selector, cancellationToken);

            [Pure]
            public ValueTask<TResult> FirstAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.FirstAsync<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, cancellationToken);

            [Pure]
            [return: MaybeNull]
            public ValueTask<TResult> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.FirstOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, cancellationToken);

            [Pure]
            public ValueTask<TResult> SingleAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.SingleAsync<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, cancellationToken);

            [Pure]
            [return: MaybeNull]
            public ValueTask<TResult> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.SingleOrDefaultAsync<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, cancellationToken);

            public ValueTask<TResult[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, cancellationToken);

            public ValueTask<List<TResult>> ToListAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToListAsync<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, cancellationToken);

            public ValueTask<Dictionary<TKey, TResult>> ToDictionaryAsync<TKey>(AsyncSelector<TResult, TKey> keySelector, CancellationToken cancellationToken = default)
                => ToDictionaryAsync<TKey>(keySelector, EqualityComparer<TKey>.Default, cancellationToken);
            public async ValueTask<Dictionary<TKey, TResult>> ToDictionaryAsync<TKey>(AsyncSelector<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
            {
                var dictionary = new Dictionary<TKey, TResult>(0, comparer);

                TResult result;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var item = enumerator.Current;
                        if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        {
                            result = await selector(item, cancellationToken).ConfigureAwait(false);
                            dictionary.Add(await keySelector(result, cancellationToken).ConfigureAwait(false), result);
                        }
                    }
                }

                return dictionary;
            }

            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(AsyncSelector<TResult, TKey> keySelector, AsyncSelector<TResult, TElement> elementSelector, CancellationToken cancellationToken = default)
                => ToDictionaryAsync<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public async ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(AsyncSelector<TResult, TKey> keySelector, AsyncSelector<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);

                TResult result;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var item = enumerator.Current;
                        if (await predicate(item, cancellationToken).ConfigureAwait(false))
                        {
                            result = await selector(item, cancellationToken).ConfigureAwait(false);
                            dictionary.Add(
                                await keySelector(result, cancellationToken).ConfigureAwait(false), 
                                await elementSelector(result, cancellationToken).ConfigureAwait(false));
                        }
                    }
                }

                return dictionary;
            }

            public ValueTask ForEachAsync(AsyncAction<TResult> action, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(source, action, predicate, selector, cancellationToken);
            public ValueTask ForEachAsync(AsyncActionAt<TResult> action, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(source, action, predicate, selector, cancellationToken);
        }
    }
}

