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

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>
            : IAsyncValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            readonly TEnumerable source;
            readonly TPredicate predicate;
            readonly TSelector selector;

            internal WhereSelectEnumerable(in TEnumerable source, TPredicate predicate, TSelector selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new(in this, cancellationToken);
            readonly IAsyncEnumerator<TResult> IAsyncEnumerable<TResult>.GetAsyncEnumerator(CancellationToken cancellationToken)
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IAsyncEnumerator<TResult>
                , IAsyncStateMachine
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                TPredicate predicate;
                TSelector selector;
                readonly CancellationToken cancellationToken;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                TSource item;
                bool s__2;
                TResult s__3;
                bool s__4;
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
                TResult IAsyncEnumerator<TResult>.Current
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
                                    awaiter3 = selector.InvokeAsync(item, cancellationToken).ConfigureAwait(false).GetAwaiter();
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
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => source.AnyAsync<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, cancellationToken);
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, AsyncSelectorSelectorCombination<TSelector, AsyncFunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, CancellationToken, ValueTask<TResult2>> selector)
                => Select<TResult2, AsyncFunctionWrapper<TResult, TResult2>>(new AsyncFunctionWrapper<TResult, TResult2>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector)
                where TSelector2 : struct, IAsyncFunction<TResult, TResult2>
                => source.WhereSelect<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(predicate, new AsyncSelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => source.ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(index, predicate, selector, cancellationToken);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> FirstAsync(CancellationToken cancellationToken = default)
                => source.FirstAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector, cancellationToken);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TResult>> SingleAsync(CancellationToken cancellationToken = default)
                => source.SingleAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector, cancellationToken);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TResult[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<IMemoryOwner<TResult>> ToArrayAsync(MemoryPool<TResult> pool, CancellationToken cancellationToken = default)
                => source.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector, pool, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TResult>> ToListAsync(CancellationToken cancellationToken = default)
                => source.ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TResult>> ToDictionaryAsync<TKey>(Func<TResult, CancellationToken, ValueTask<TKey>> keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                => ToDictionaryAsync<TKey, AsyncFunctionWrapper<TResult, TKey>>(new AsyncFunctionWrapper<TResult, TKey>(keySelector), comparer, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TResult>> ToDictionaryAsync<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TResult, TKey>
                => source.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(keySelector, comparer, cancellationToken, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TResult, CancellationToken, ValueTask<TKey>> keySelector, Func<TResult, CancellationToken, ValueTask<TElement>> elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                => ToDictionaryAsync<TKey, TElement, AsyncFunctionWrapper<TResult, TKey>, AsyncFunctionWrapper<TResult, TElement>>(new AsyncFunctionWrapper<TResult, TKey>(keySelector), new AsyncFunctionWrapper<TResult, TElement>(elementSelector), comparer, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TResult, TKey>
                where TElementSelector : struct, IAsyncFunction<TResult, TElement>
                => source.ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(keySelector, elementSelector, comparer, cancellationToken, predicate, selector);
            
            #endregion
        }
    }
}

