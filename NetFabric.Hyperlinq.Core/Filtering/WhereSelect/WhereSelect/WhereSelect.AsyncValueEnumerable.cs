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
        static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(
            this TEnumerable source,
            TPredicate predicate,
            TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => new(in source, predicate, selector);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>
            : IAsyncValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;
            internal readonly TSelector selector;

            internal WhereSelectEnumerable(in TEnumerable source, TPredicate predicate, TSelector selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new(in this, cancellationToken);

            IAsyncEnumerator<TResult> IAsyncEnumerable<TResult>.GetAsyncEnumerator(CancellationToken cancellationToken)
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IAsyncEnumerator<TResult>
                , IAsyncStateMachine
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
                TPredicate predicate;
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly CancellationToken cancellationToken;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                TSource? item;
#pragma warning disable IDE1006 // Naming Styles
                bool s__2;
                TResult? s__3;
                bool s__4;
#pragma warning restore IDE1006 // Naming Styles
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ConfiguredValueTaskAwaitable<TResult>.ConfiguredValueTaskAwaiter u__2;
                ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter u__3;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    this.cancellationToken = cancellationToken;
                    Current = default!;

                    state = -1;
                    builder = default;
                    item = default;
                    s__2 = default;
                    s__3 = default;
                    s__4 = default;
                    u__1 = default;
                    u__2 = default;
                    u__3 = default;
                }

                public TResult Current { get; private set; }
                readonly TResult IAsyncEnumerator<TResult>.Current
                    => Current;

                //public async ValueTask<bool> MoveNextAsync()
                //{
                //    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //    {
                //        var item = enumerator.Current;
                //        if (await predicate(item, cancellationToken).ConfigureAwait(false))
                //        {
                //            Current = await selector(item, cancellationToken).ConfigureAwait(false);
                //            return true;
                //        }
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
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter4;
                        ConfiguredValueTaskAwaitable<TResult>.ConfiguredValueTaskAwaiter awaiter3;
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2;
                        ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
                        switch (num)
                        {
                            case 0:
                                awaiter4 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_00d2;
                            case 1:
                                awaiter3 = u__2;
                                u__2 = default;
                                num = state = -1;
                                goto IL_0172;
                            default:
                                awaiter2 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                if (!awaiter2.IsCompleted)
                                {
                                    num = state = 2;
                                    u__1 = awaiter2;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                    return;
                                }
                                goto IL_0214;
                            case 2:
                                awaiter2 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_0214;
                            case 3:
                                {
                                    awaiter = u__3;
                                    u__3 = default;
                                    num = state = -1;
                                    break;
                                }
                            IL_00d2:
                                s__2 = awaiter4.GetResult();
                                if (s__2)
                                {
                                    awaiter3 = selector.InvokeAsync(item!, cancellationToken).ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter3.IsCompleted)
                                    {
                                        num = state = 1;
                                        u__2 = awaiter3;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
                                        return;
                                    }
                                    goto IL_0172;
                                }
                                goto default;
                            IL_0214:
                                s__4 = awaiter2.GetResult();
                                if (!s__4)
                                {
                                    awaiter = DisposeAsync().ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter.IsCompleted)
                                    {
                                        num = state = 3;
                                        u__3 = awaiter;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                                        return;
                                    }
                                    break;
                                }
                                item = enumerator.Current;
                                awaiter4 = predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false).GetAwaiter();
                                if (!awaiter4.IsCompleted)
                                {
                                    num = state = 0;
                                    u__1 = awaiter4;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter4, ref this);
                                    return;
                                }
                                goto IL_00d2;
                            IL_0172:
                                s__3 = awaiter3.GetResult();
                                Current = s__3;
                                s__3 = default;
                                result = true;
                                goto end_IL_0007;
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

                void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
                { }
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => source.CountAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync<TPredicate2>(TPredicate2 predicate = default, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TResult, bool>
                => AsyncValueEnumerableExtensions.CountAsync<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(this, predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAtAsync<TPredicate2>(TPredicate2 predicate = default, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TResult, int, bool>
                => AsyncValueEnumerableExtensions.CountAtAsync<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(this, predicate, cancellationToken);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync(CancellationToken cancellationToken = default)
                => source.AllAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync<TPredicate2>(TPredicate2 predicate, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TResult, bool>
                => this.AllAsync<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAtAsync<TPredicate2>(TPredicate2 predicate, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TResult, int, bool>
                => this.AllAtAsync<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => source.AnyAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync<TPredicate2>(TPredicate2 predicate, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TResult, bool>
                => this.AnyAsync<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAtAsync<TPredicate2>(TPredicate2 predicate, CancellationToken cancellationToken = default)
                where TPredicate2 : struct, IAsyncFunction<TResult, int, bool>
                => this.AnyAtAsync<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate, cancellationToken);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IAsyncFunction<TResult, bool>
                => this.Where<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IAsyncFunction<TResult, int, bool>
                => this.WhereAt<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IAsyncFunction<TResult, TResult2>
                => source.WhereSelect<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(predicate, new AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => source.ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(index, cancellationToken, predicate, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> FirstAsync(CancellationToken cancellationToken = default)
                => source.FirstAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(cancellationToken, predicate, selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> SingleAsync(CancellationToken cancellationToken = default)
                => source.SingleAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(cancellationToken, predicate, selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TResult[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(cancellationToken, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Lease<TResult>> ToArrayAsync(ArrayPool<TResult> pool, CancellationToken cancellationToken = default, bool clearOnDispose = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(pool, clearOnDispose, cancellationToken, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TResult>> ToListAsync(CancellationToken cancellationToken = default)
                => source.ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(cancellationToken, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TResult>> ToDictionaryAsync<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TResult, TKey>
                => source.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(keySelector, comparer, cancellationToken, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TResult, TKey>
                where TElementSelector : struct, IAsyncFunction<TResult, TElement>
                => source.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(keySelector, elementSelector, comparer, cancellationToken, predicate, selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, int, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, int>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, int, int, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, int?, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, int?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, int?, int, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, nint, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, nint>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, nint, nint, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, nint?, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, nint?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, nint?, nint, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, nuint, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, nuint>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, nuint, nuint, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, nuint?, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, nuint?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, nuint?, nuint, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, long, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, long>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, long, long, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, long?, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, long?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, long?, long, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, float, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, float>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, float, float, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, float?, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, float?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, float?, float, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, double, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, double>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, double, double, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, double?, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, double?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, double?, double, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, decimal, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, decimal>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, decimal, decimal, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, decimal?, TPredicate, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, decimal?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, decimal?, decimal, TPredicate, TSelector>(cancellationToken, source.predicate, source.selector);
    }
}

