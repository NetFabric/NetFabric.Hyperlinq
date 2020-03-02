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
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

        public readonly partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource> 
            : IAsyncValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly AsyncPredicate<TSource> predicate;

            internal WhereEnumerable(in TEnumerable source, AsyncPredicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new Enumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new Enumerator(in this, cancellationToken);

            public struct Enumerator
                : IAsyncEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly AsyncPredicate<TSource> predicate;
                readonly CancellationToken cancellationToken;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    predicate = enumerable.predicate;
                    this.cancellationToken = cancellationToken;
                }

                [MaybeNull]
                public readonly TSource Current
                    => enumerator.Current;

                public async ValueTask<bool> MoveNextAsync()
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false))
                            return true;
                    }
                    await DisposeAsync().ConfigureAwait(false);
                    return false;
                }

                public ValueTask DisposeAsync() 
                    => enumerator.DisposeAsync();
            }

            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.CountAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);
            public ValueTask<int> CountAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.CountAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);
            public ValueTask<int> CountAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.CountAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);

            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);
            public ValueTask<bool> AnyAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);
            public ValueTask<bool> AnyAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);

            public AsyncValueEnumerable.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(AsyncSelector<TSource, TResult> selector)
                => AsyncValueEnumerable.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public AsyncValueEnumerable.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(AsyncPredicate<TSource> predicate)
                => AsyncValueEnumerable.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public AsyncValueEnumerable.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(AsyncPredicateAt<TSource> predicate)
                => AsyncValueEnumerable.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public async ValueTask<TSource> FirstAsync(CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false))
                    .ThrowOnEmpty();
            public async ValueTask<TSource> FirstAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken).ConfigureAwait(false))
                    .ThrowOnEmpty();
            public async ValueTask<TSource> FirstAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken).ConfigureAwait(false))
                    .ThrowOnEmpty();

            public async ValueTask<TSource> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken).ConfigureAwait(false))
                    .DefaultOnEmpty();
            public async ValueTask<TSource> FirstOrDefaultAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken).ConfigureAwait(false))
                    .DefaultOnEmpty();
            public async ValueTask<TSource> FirstOrDefaultAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken).ConfigureAwait(false))
                    .DefaultOnEmpty();

            public async ValueTask<TSource> SingleAsync(CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken))
                    .ThrowOnEmpty();
            public async ValueTask<TSource> SingleAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken))
                    .ThrowOnEmpty();
            public async ValueTask<TSource> SingleAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken))
                    .ThrowOnEmpty();

            [return: MaybeNull]
            public async ValueTask<TSource> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken))
                    .DefaultOnEmpty();
            [return: MaybeNull]
            public async ValueTask<TSource> SingleOrDefaultAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken))
                    .DefaultOnEmpty();
            [return: MaybeNull]
            public async ValueTask<TSource> SingleOrDefaultAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken))
                    .DefaultOnEmpty();

            public ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToArrayAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);

            public ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToListAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);

            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey>(AsyncSelector<TSource, TKey> keySelector, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate, cancellationToken);
            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey>(AsyncSelector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, predicate, cancellationToken);
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(AsyncSelector<TSource, TKey> keySelector, AsyncSelector<TSource, TElement> elementSelector, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate, cancellationToken);
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(AsyncSelector<TSource, TKey> keySelector, AsyncSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, cancellationToken);

            public ValueTask ForEachAsync(AsyncAction<TSource> action, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ForEachAsync<TEnumerable, TEnumerator, TSource>(source, action, predicate, cancellationToken);
            public ValueTask ForEachAsync(AsyncActionAt<TSource> action, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ForEachAsync<TEnumerable, TEnumerator, TSource>(source, action, predicate, cancellationToken);
        }
    }
}

