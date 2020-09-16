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
        public static SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source,
            AsyncSelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        public readonly partial struct SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IAsyncValueEnumerable<TResult, SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly AsyncSelectorAt<TSource, TResult> selector;

            internal SelectAtEnumerable(in TEnumerable source, AsyncSelectorAt<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new Enumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<TResult> IAsyncEnumerable<TResult>.GetAsyncEnumerator(CancellationToken cancellationToken)
                => new Enumerator(in this, cancellationToken);

            public struct Enumerator
                : IAsyncEnumerator<TResult>
                , IAsyncStateMachine
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly AsyncSelectorAt<TSource, TResult> selector;
                readonly CancellationToken cancellationToken;
                int index;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                bool s__1;
                [MaybeNull, AllowNull] TResult s__2;
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ConfiguredValueTaskAwaitable<TResult>.ConfiguredValueTaskAwaiter u__2;
                ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter u__3;

                internal Enumerator(in SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    selector = enumerable.selector;
                    this.cancellationToken = cancellationToken;
                    index = -1;
                    Current = default!;

                    state = -1;
                    builder = default;
                    s__1 = default;
                    s__2 = default;
                    u__1 = default;
                    u__2 = default;
                    u__3 = default;
                }

                [MaybeNull, AllowNull]
                public TResult Current { get; private set; }
                TResult IAsyncEnumerator<TResult>.Current
                    => Current!;

                //public async ValueTask<bool> MoveNextAsync()
                //{
                //    if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //    {
                //        Current = await selector(enumerator.Current, ++index, cancellationToken).ConfigureAwait(false);
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
                                goto IL_0161;
                            case 2:
                                {
                                    awaiter = u__3;
                                    u__3 = default;
                                    num = state = -1;
                                    break;
                                }
                            IL_0161:
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
                                awaiter2 = selector(enumerator.Current, ++index, cancellationToken).ConfigureAwait(false).GetAwaiter();
                                if (!awaiter2.IsCompleted)
                                {
                                    num = state = 1;
                                    u__2 = awaiter2;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                    return;
                                }
                                goto IL_0161;
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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.CountAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.AnyAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2> Select<TResult2>(AsyncSelector<TResult, TResult2> selector)
                => AsyncValueEnumerableExtensions.Select<TEnumerable, TEnumerator, TSource, TResult2>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2> Select<TResult2>(AsyncSelectorAt<TResult, TResult2> selector)
                => AsyncValueEnumerableExtensions.Select<TEnumerable, TEnumerator, TSource, TResult2>(source, Utils.Combine(this.selector, selector));


            public ValueTask<Option<TResult>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult>(source, index, selector, cancellationToken);


            public ValueTask<Option<TResult>> FirstAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.FirstAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, cancellationToken);


            public ValueTask<Option<TResult>> SingleAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.SingleAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, cancellationToken);

            public ValueTask<TResult[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<IMemoryOwner<TResult>> ToArrayAsync(MemoryPool<TResult> pool, CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, pool, cancellationToken);

            public ValueTask<List<TResult>> ToListAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToListAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, cancellationToken);
        }
    }
}

