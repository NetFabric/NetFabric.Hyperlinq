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
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, AsyncFunctionWrapper<TSource, TResult>> Select<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TSource, CancellationToken, ValueTask<TResult>> selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => source.Select<TEnumerable, TEnumerator, TSource, TResult, AsyncFunctionWrapper<TSource, TResult>>(new AsyncFunctionWrapper<TSource, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> Select<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            => new(in source, selector);

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>
            : IAsyncValueEnumerable<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            readonly TEnumerable source;
            readonly TSelector selector;

            internal SelectEnumerable(in TEnumerable source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new(in this, cancellationToken);
            readonly IAsyncEnumerator<TResult> IAsyncEnumerable<TResult>.GetAsyncEnumerator(CancellationToken cancellationToken)
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IAsyncEnumerator<TResult>
                , IAsyncStateMachine
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                TSelector selector;
                readonly CancellationToken cancellationToken;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                bool s__1;
                TResult? s__2;
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
                TResult IAsyncEnumerator<TResult>.Current 
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
            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorCombination<TSelector, AsyncFunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, CancellationToken, ValueTask<TResult2>> selector)
                => Select<TResult2, AsyncFunctionWrapper<TResult, TResult2>>(new AsyncFunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector)
                where TSelector2 : struct, IAsyncFunction<TResult, TResult2>
                => source.Select<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorAtCombination<TSelector, AsyncFunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, CancellationToken, ValueTask<TResult2>> selector)
                => SelectAt<TResult2, AsyncFunctionWrapper<TResult, int, TResult2>>(new AsyncFunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector)
                where TSelector2 : struct, IAsyncFunction<TResult, int, TResult2>
                => source.SelectAt<TEnumerable, TEnumerator, TSource, TResult2, AsyncSelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new AsyncSelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => source.ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(index, selector, cancellationToken);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> FirstAsync(CancellationToken cancellationToken = default)
                => source.FirstAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> SingleAsync(CancellationToken cancellationToken = default)
                => source.SingleAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector, cancellationToken);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TResult[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<IMemoryOwner<TResult>> ToArrayAsync(MemoryPool<TResult> pool, CancellationToken cancellationToken = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector, pool, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TResult>> ToListAsync(CancellationToken cancellationToken = default)
                => source.ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector, cancellationToken);
            
            #endregion
        }
    }
}

