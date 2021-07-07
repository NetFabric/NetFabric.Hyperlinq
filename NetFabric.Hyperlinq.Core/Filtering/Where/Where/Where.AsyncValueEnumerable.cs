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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> Where<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            => new(in source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>
            : IAsyncValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;

            internal WhereEnumerable(in TEnumerable source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new(in this, cancellationToken);

            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IAsyncEnumerator<TSource>
                , IAsyncStateMachine
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
                TPredicate predicate;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly CancellationToken cancellationToken;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
#pragma warning disable IDE1006 // Naming Styles
                bool s__1;
                bool s__2;
#pragma warning restore IDE1006 // Naming Styles
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter u__2;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    predicate = enumerable.predicate;
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
                //    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //    {
                //        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false))
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

                public readonly ValueTask DisposeAsync()
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
                                goto IL_00bd;
                            default:
                                awaiter2 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                if (!awaiter2.IsCompleted)
                                {
                                    num = state = 1;
                                    u__1 = awaiter2;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                    return;
                                }
                                goto IL_0150;
                            case 1:
                                awaiter2 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_0150;
                            case 2:
                                {
                                    awaiter = u__2;
                                    u__2 = default;
                                    num = state = -1;
                                    break;
                                }
                            IL_00bd:
                                s__1 = awaiter3.GetResult();
                                if (!s__1)
                                {
                                    goto default;
                                }
                                result = true;
                                goto end_IL_0007;
                            IL_0150:
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
                                awaiter3 = predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false).GetAwaiter();
                                if (!awaiter3.IsCompleted)
                                {
                                    num = state = 0;
                                    u__1 = awaiter3;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
                                    return;
                                }
                                goto IL_00bd;
                        }
                        awaiter.GetResult();
                        result = false;
                    end_IL_0007:;
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

                readonly void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
                { }
            }
            
            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => source.CountAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync<TPredicate2>(TPredicate2 predicate = default, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, bool>
                => source.CountAsync<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAtAsync<TPredicate2>(TPredicate2 predicate = default, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
                => source.CountAtAsync<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), cancellationToken);
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync(CancellationToken cancellationToken = default)
                => source.AllAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync<TPredicate2>(TPredicate2 predicate = default, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, bool>
                => source.AllAsync<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAtAsync<TPredicate2>(TPredicate2 predicate = default, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
                => source.AllAtAsync<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => source.AnyAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync<TPredicate2>(TPredicate2 predicate = default, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, bool>
                => source.AnyAsync<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAtAsync<TPredicate2>(TPredicate2 predicate = default, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
                => source.AnyAtAsync<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), cancellationToken);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IAsyncFunction<TSource, TResult>
                => source.WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, bool>
                => source.Where<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
                => source.WhereAt<TEnumerable, TEnumerator, TSource, AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new AsyncPredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => source.ElementAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(index, cancellationToken, predicate);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> FirstAsync(CancellationToken cancellationToken = default)
                => source.FirstAsync<TEnumerable, TEnumerator, TSource, TPredicate>(cancellationToken, predicate);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> SingleAsync(CancellationToken cancellationToken = default)
                => source.SingleAsync<TEnumerable, TEnumerator, TSource, TPredicate>(cancellationToken, predicate);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TPredicate>(cancellationToken, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Lease<TSource>> ToArrayAsync(ArrayPool<TSource> pool, CancellationToken cancellationToken = default, bool clearOnDispose = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TPredicate>(pool, clearOnDispose, cancellationToken, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => source.ToListAsync<TEnumerable, TEnumerator, TSource, TPredicate>(cancellationToken, predicate);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TSource, TKey>
                => source.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(keySelector, comparer, cancellationToken, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TSource, TKey>
                where TElementSelector : struct, IAsyncFunction<TSource, TElement>
                => source.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, cancellationToken, predicate);
             
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, int, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int>
            where TPredicate : struct, IAsyncFunction<int, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, int, int, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, int?, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int?>
            where TPredicate : struct, IAsyncFunction<int?, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, int?, int, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, nint, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<nint, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nint>
            where TPredicate : struct, IAsyncFunction<nint, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, nint, nint, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, nint?, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<nint?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nint?>
            where TPredicate : struct, IAsyncFunction<nint?, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, nint?, nint, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, nuint, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<nuint, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nuint>
            where TPredicate : struct, IAsyncFunction<nuint, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, nuint, nuint, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, nuint?, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<nuint?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nuint?>
            where TPredicate : struct, IAsyncFunction<nuint?, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, nuint?, nuint, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, long, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long>
            where TPredicate : struct, IAsyncFunction<long, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, long, long, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, long?, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long?>
            where TPredicate : struct, IAsyncFunction<long?, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, long?, long, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, float, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float>
            where TPredicate : struct, IAsyncFunction<float, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, float, float, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, float?, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float?>
            where TPredicate : struct, IAsyncFunction<float?, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, float?, float, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, double, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double>
            where TPredicate : struct, IAsyncFunction<double, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, double, double, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, double?, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double?>
            where TPredicate : struct, IAsyncFunction<double?, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, double?, double, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, decimal, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal>
            where TPredicate : struct, IAsyncFunction<decimal, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, decimal, decimal, TPredicate>(cancellationToken, source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, decimal?, TPredicate> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal?>
            where TPredicate : struct, IAsyncFunction<decimal?, bool>
            => source.source.SumAsync<TEnumerable, TEnumerator, decimal?, decimal, TPredicate>(cancellationToken, source.predicate);
    }
}

