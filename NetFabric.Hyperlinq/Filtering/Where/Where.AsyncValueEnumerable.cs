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
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken) => new Enumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) => new Enumerator(in this, cancellationToken);

            public struct Enumerator
                : IAsyncEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly AsyncPredicate<TSource> predicate;
                readonly CancellationToken cancellationToken;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator();
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
                        if (await predicate(enumerator.Current, cancellationToken))
                            return true;
                    }
                    await DisposeAsync();
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

                public ValueTask DisposeAsync() => enumerator.DisposeAsync();
            }

            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.CountAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);
            public ValueTask<int> CountAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.CountAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);
            public ValueTask<int> CountAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.CountAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);

            public ValueTask<long> LongCountAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.LongCountAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);
            public ValueTask<long> LongCountAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.LongCountAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);

            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken);
            public ValueTask<bool> AnyAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);
            public ValueTask<bool> AnyAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);

            public AsyncValueEnumerable.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.WhereSelectAsync<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, cancellationToken);

            public ValueTask<AsyncValueEnumerable.WhereEnumerable<TEnumerable, TEnumerator, TSource>> Where(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.WhereAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);
            public ValueTask<AsyncValueEnumerable.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>> Where(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.WhereAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken);

            public async ValueTask<TSource> FirstAsync(CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken)).ThrowOnEmpty();
            public async ValueTask<TSource> FirstAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken)).ThrowOnEmpty();
            public async ValueTask<TSource> FirstAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken)).ThrowOnEmpty();

            public async ValueTask<TSource> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, predicate, cancellationToken)).DefaultOnEmpty();
            public async ValueTask<TSource> FirstOrDefaultAsync(AsyncPredicate<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken)).DefaultOnEmpty();
            public async ValueTask<TSource> FirstOrDefaultAsync(AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken = default)
                => (await AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), cancellationToken)).DefaultOnEmpty();

            public (ElementResult Success, TSource Value) TryFirstAsync()
                => AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (ElementResult Success, TSource Value) TryFirstAsync(AsyncPredicate<TSource> predicate)
                => AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public (int Index, TSource Value) TryFirstAsync(AsyncPredicateAt<TSource> predicate)
                => AsyncValueEnumerable.GetFirstAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource SingleAsync()
                => AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource SingleAsync(AsyncPredicate<TSource> predicate)
                => AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource SingleAsync(AsyncPredicateAt<TSource> predicate)
                => AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();

            [return: MaybeNull]
            public TSource SingleOrDefaultAsync()
                => AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            [return: MaybeNull]
            public TSource SingleOrDefaultAsync(AsyncPredicate<TSource> predicate)
                => AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            [return: MaybeNull]
            public TSource SingleOrDefaultAsync(AsyncPredicateAt<TSource> predicate)
                => AsyncValueEnumerable.GetSingleAsync<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();

            public List<TSource> ToListAsync()
                => AsyncValueEnumerable.ToListAsync<TEnumerable, TEnumerator, TSource>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionaryAsync<TKey>(AsyncSelector<TSource, TKey> keySelector)
                => AsyncValueEnumerable.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate);
            public Dictionary<TKey, TSource> ToDictionaryAsync<TKey>(AsyncSelector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => AsyncValueEnumerable.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionaryAsync<TKey, TElement>(AsyncSelector<TSource, TKey> keySelector, AsyncSelector<TSource, TElement> elementSelector)
                => AsyncValueEnumerable.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate);
            public Dictionary<TKey, TElement> ToDictionaryAsync<TKey, TElement>(AsyncSelector<TSource, TKey> keySelector, AsyncSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => AsyncValueEnumerable.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate);

            public ValueTask ForEachAsync(AsyncAction<TSource> action, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ForEachAsync<TEnumerable, TEnumerator, TSource>(source, action, predicate, cancellationToken);
            public ValueTask ForEachAsync(AsyncActionAt<TSource> action, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ForEachAsync<TEnumerable, TEnumerator, TSource>(source, action, predicate, cancellationToken);
        }
    }
}

