using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncValuePredicateAt<TSource>> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt<TEnumerable, TEnumerator, TSource, AsyncValuePredicateAt<TSource>>(source, new AsyncValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> WhereAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
            => new WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        public readonly partial struct WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>
            : IAsyncValueEnumerable<TSource, WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.Enumerator>
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;

            internal WhereAtEnumerable(TEnumerable source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new Enumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new Enumerator(in this, cancellationToken);

            public struct Enumerator
                : IAsyncEnumerator<TSource>
                , IAsyncStateMachine
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly TPredicate predicate;
                readonly CancellationToken cancellationToken;
                int index;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                bool s__1;
                bool s__2;
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter u__2;

                internal Enumerator(in WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    predicate = enumerable.predicate;
                    index = -1;
                    this.cancellationToken = cancellationToken;

                    state = -1;
                    builder = default;
                    s__1 = default;
                    s__2 = default;
                    u__1 = default;
                    u__2 = default;
                }

                [MaybeNull]
                public readonly TSource Current
                    => enumerator.Current;
                readonly TSource IAsyncEnumerator<TSource>.Current
                    => enumerator.Current;

                //public async ValueTask<bool> MoveNextAsync()
                //{
                //    for (;await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                //    {
                //        if (await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                //            return true;
                //    }
                //    await DisposeAsync().ConfigureAwait(false);
                //    return false;
                //}

                public ValueTask<bool> MoveNextAsync()
                {
                    state = -1;
                    builder = AsyncValueTaskMethodBuilder<bool>.Create();
                    builder.Start(ref this);
                    return builder.Task;
                }

                public ValueTask DisposeAsync()
                    => enumerator.DisposeAsync();

                void IAsyncStateMachine.MoveNext()
                {
                    var num = state;
                    bool result;
                    try
                    {
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter3;
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2;
                        ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
                        switch (num)
                        {
                            case 0:
                                awaiter3 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_00db;
                            default:
                                awaiter2 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                if (!awaiter2.IsCompleted)
                                {
                                    num = state = 1;
                                    u__1 = awaiter2;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                    return;
                                }
                                goto IL_016e;
                            case 1:
                                awaiter2 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_016e;
                            case 2:
                                {
                                    awaiter = u__2;
                                    u__2 = default;
                                    num = state = -1;
                                    break;
                                }
                            IL_00db:
                                s__1 = awaiter3.GetResult();
                                if (!s__1)
                                {
                                    goto default;
                                }
                                result = true;
                                goto end_IL_0007;
                            IL_016e:
                                s__2 = awaiter2.GetResult();
                                if (!s__2)
                                {
                                    awaiter = DisposeAsync().ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter.IsCompleted)
                                    {
                                        num = state = 2;
                                        u__2 = awaiter;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                                        return;
                                    }
                                    break;
                                }
                                awaiter3 = predicate.InvokeAsync(enumerator.Current, ++index, cancellationToken).ConfigureAwait(false).GetAwaiter();
                                if (!awaiter3.IsCompleted)
                                {
                                    num = state = 0;
                                    u__1 = awaiter3;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
                                    return;
                                }
                                goto IL_00db;
                        }
                        awaiter.GetResult();
                        result = false;
                    end_IL_0007: ;
                    }
                    catch (Exception exception)
                    {
                        state = -2;
                        builder.SetException(exception);
                        return;
                    }
                    state = -2;
                    builder.SetResult(result);
                }

                void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
                { }
            }

            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.CountAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.AnyAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicateAsyncPredicateAtCombination<AsyncValuePredicate<TSource>, TPredicate, TSource>> Where(AsyncPredicate<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new AsyncValuePredicate<TSource>(predicate));
            }

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicateAsyncPredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IAsyncPredicate<TSource>
                => WhereAt<TEnumerable, TEnumerator, TSource, AsyncPredicateAsyncPredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new AsyncPredicateAsyncPredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicateAtAsyncPredicateAtCombination<TPredicate, AsyncValuePredicateAt<TSource>, TSource>> Where(AsyncPredicateAt<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new AsyncValuePredicateAt<TSource>(predicate));
            }

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicateAtAsyncPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IAsyncPredicateAt<TSource>
                => WhereAt<TEnumerable, TEnumerator, TSource, AsyncPredicateAtAsyncPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new AsyncPredicateAtAsyncPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));


            public ValueTask<Option<TSource>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ElementAtAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, index, predicate, cancellationToken);


            public ValueTask<Option<TSource>> FirstAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.FirstAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);


            public ValueTask<Option<TSource>> SingleAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.SingleAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

            public ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

            public ValueTask<IMemoryOwner<TSource>> ToArrayAsync(MemoryPool<TSource> pool, CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, pool, cancellationToken);

            public ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToListAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey>(AsyncSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                => AsyncValueEnumerableExtensions.ToDictionaryAtAsync<TEnumerable, TEnumerator, TSource, TKey, TPredicate>(source, keySelector, comparer, predicate, cancellationToken);
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(AsyncSelector<TSource, TKey> keySelector, AsyncSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                => AsyncValueEnumerableExtensions.ToDictionaryAtAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TPredicate>(source, keySelector, elementSelector, comparer, predicate, cancellationToken);
        }
    }
}

