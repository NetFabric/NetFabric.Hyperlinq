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
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> Select<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => new(in source, selector);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>
            : IAsyncValueEnumerable<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            internal readonly TEnumerable source;
            internal readonly TSelector selector;

            internal SelectEnumerable(in TEnumerable source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

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
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly CancellationToken cancellationToken;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
#pragma warning disable IDE1006 // Naming Styles
                bool s__1;
                TResult? s__2;
#pragma warning restore IDE1006 // Naming Styles
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ConfiguredValueTaskAwaitable<TResult>.ConfiguredValueTaskAwaiter u__2;
                ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter u__3;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    selector = enumerable.selector;
                    this.cancellationToken = cancellationToken;
                    Current = default!;

                    state = -1;
                    builder = default;
                    s__1 = default;
                    s__2 = default;
                    u__1 = default;
                    u__2 = default;
                    u__3 = default;
                }

                public TResult Current { get; private set; }
                readonly TResult IAsyncEnumerator<TResult>.Current 
                    => Current;

                //public async ValueTask<bool> MoveNextAsync()
                //{
                //    if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //    {
                //        Current = await selector(enumerator.Current, cancellationToken).ConfigureAwait(false);
                //        return true;
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
                        ConfiguredValueTaskAwaitable<TResult>.ConfiguredValueTaskAwaiter awaiter2;
                        ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
                        switch (num)
                        {
                            default:
                                awaiter3 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                if (!awaiter3.IsCompleted)
                                {
                                    num = state = 0;
                                    u__1 = awaiter3;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
                                    return;
                                }
                                goto IL_0099;
                            case 0:
                                awaiter3 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_0099;
                            case 1:
                                awaiter2 = u__2;
                                u__2 = default;
                                num = state = -1;
                                goto IL_0143;
                            case 2:
                                {
                                    awaiter = u__3;
                                    u__3 = default;
                                    num = state = -1;
                                    break;
                                }
                            IL_0143:
                                s__2 = awaiter2.GetResult();
                                Current = s__2;
                                s__2 = default;
                                result = true;
                                goto end_IL_0007;
                            IL_0099:
                                s__1 = awaiter3.GetResult();
                                if (!s__1)
                                {
                                    awaiter = DisposeAsync().ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter.IsCompleted)
                                    {
                                        num = state = 2;
                                        u__3 = awaiter;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                                        return;
                                    }
                                    break;
                                }
                                awaiter2 = selector.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false).GetAwaiter();
                                if (!awaiter2.IsCompleted)
                                {
                                    num = state = 1;
                                    u__2 = awaiter2;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                    return;
                                }
                                goto IL_0143;
                        }
                        awaiter.GetResult();
                        result = false;
                    end_IL_0007:
                        ;
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
                => source.CountAsync<TEnumerable, TEnumerator, TSource>(cancellationToken);
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => source.AnyAsync<TEnumerable, TEnumerator, TSource>(cancellationToken);
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IAsyncFunction<TResult, TResult2>
                => source.Select<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IAsyncFunction<TResult, int, TResult2>
                => source.SelectAt<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new AsyncSelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => source.ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(index, cancellationToken, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> FirstAsync(CancellationToken cancellationToken = default)
                => source.FirstAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(cancellationToken, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> SingleAsync(CancellationToken cancellationToken = default)
                => source.SingleAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(cancellationToken, selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TResult[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(cancellationToken, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Lease<TResult>> ToArrayAsync(ArrayPool<TResult> pool, CancellationToken cancellationToken = default, bool clearOnDispose = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(pool, cancellationToken, clearOnDispose, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TResult>> ToListAsync(CancellationToken cancellationToken = default)
                => source.ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(cancellationToken, selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, int, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, int, int, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, int?, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, int?, int, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nint, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, nint>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, nint, nint, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nint?, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, nint?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, nint?, nint, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nuint, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, nuint>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, nuint, nuint, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nuint?, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, nuint?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, nuint?, nuint, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, long, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, long>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, long, long, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, long?, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, long?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, long?, long, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, float, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, float>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, float, float, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, float?, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, float?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, float?, float, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, double, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, double>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, double, double, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, double?, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, double?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, double?, double, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, decimal, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, decimal>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, decimal, decimal, TSelector>(cancellationToken, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, decimal?, TSelector> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, decimal?>
            => source.source.SumAsync<TEnumerable, TEnumerator, TSource, decimal?, decimal, TSelector>(cancellationToken, source.selector);
    }
}

