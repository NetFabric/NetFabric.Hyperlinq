using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.AsyncFunctionWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncFunctionWrapper<TSource, int, bool>> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, CancellationToken, ValueTask<bool>> predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => source.WhereAt<TEnumerable, TEnumerator, TSource, AsyncFunctionWrapper<TSource, int, bool>>(new AsyncFunctionWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> WhereAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
            => new(in source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>
            : IAsyncValueEnumerable<TSource, WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
        {
            readonly TEnumerable source;
            readonly TPredicate predicate;

            internal WhereAtEnumerable(in TEnumerable source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IAsyncEnumerator<TSource>
                , IAsyncStateMachine
            {
                int index;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                TPredicate predicate;
                readonly CancellationToken cancellationToken;

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
            
            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => source.CountAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync(CancellationToken cancellationToken = default)
                => source.AllAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync(Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
                => AllAsync(new AsyncFunctionWrapper<TSource, bool>(predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync<TPredicate2>(TPredicate2 predicate, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, bool>
                => source.AllAtAsync<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(new AsyncPredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync(Func<TSource, int, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
                => AllAtAsync(new AsyncFunctionWrapper<TSource, int, bool>(predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAtAsync<TPredicate2>(TPredicate2 predicate, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
                => source.AllAtAsync<TEnumerable, TEnumerator, TSource, AsyncPredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => source.AnyAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(Func<TSource, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
                => AnyAsync(new AsyncFunctionWrapper<TSource, bool>(predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync<TPredicate2>(TPredicate2 predicate, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, bool>
                => source.AnyAtAsync<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(new AsyncPredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(Func<TSource, int, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
                => AnyAtAsync(new AsyncFunctionWrapper<TSource, int, bool>(predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAtAsync<TPredicate2>(TPredicate2 predicate, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
                => source.AnyAtAsync<TEnumerable, TEnumerator, TSource, AsyncPredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), cancellationToken);

            #endregion
            #region Projection

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<AsyncFunctionWrapper<TSource, bool>, TPredicate, TSource>> Where(Func<TSource, CancellationToken, ValueTask<bool>> predicate)
                => Where(new AsyncFunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, bool>
                => source.WhereAt<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(new AsyncPredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicateAtPredicateAtCombination<TPredicate, AsyncFunctionWrapper<TSource, int, bool>, TSource>> Where(Func<TSource, int, CancellationToken, ValueTask<bool>> predicate)
                => WhereAt(new AsyncFunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
                => source.WhereAt<TEnumerable, TEnumerator, TSource, AsyncPredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => source.ElementAtAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(index, predicate, cancellationToken);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> FirstAsync(CancellationToken cancellationToken = default)
                => source.FirstAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> SingleAsync(CancellationToken cancellationToken = default)
                => source.SingleAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => source.ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<IMemoryOwner<TSource>> ToArrayAsync(MemoryPool<TSource> pool, CancellationToken cancellationToken = default)
                => source.ToArrayAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, pool, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => source.ToListAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey>(Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                => ToDictionaryAsync<TKey, AsyncFunctionWrapper<TSource, TKey>>(new AsyncFunctionWrapper<TSource, TKey>(keySelector), comparer, cancellationToken);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TSource, TKey>
                => source.ToDictionaryAtAsync<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(keySelector, comparer, predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TSource, CancellationToken, ValueTask<TKey>> keySelector, Func<TSource, CancellationToken, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                => ToDictionaryAsync<TKey, TElement, AsyncFunctionWrapper<TSource, TKey>, AsyncFunctionWrapper<TSource, TElement>>(new AsyncFunctionWrapper<TSource, TKey>(keySelector), new AsyncFunctionWrapper<TSource, TElement>(elementSelector), comparer, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TSource, TKey>
                where TElementSelector : struct, IAsyncFunction<TSource, TElement>
                => source.ToDictionaryAtAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate, cancellationToken);
             
            #endregion
        }
    }
}

