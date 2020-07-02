using System;
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
        public static DistinctEnumerable<TEnumerable, TEnumerator, TSource> Distinct<TEnumerable, TEnumerator, TSource>(
            this TEnumerable source,
            IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source, comparer);

        public readonly partial struct DistinctEnumerable<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly IEqualityComparer<TSource>? comparer;

            internal DistinctEnumerable(TEnumerable source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }


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
                readonly IEqualityComparer<TSource>? comparer;
                EnumeratorState enumeratorState;
                Set<TSource> set;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                EnumeratorState s__1;
                bool s__2;
                bool s__3;
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ValueTaskAwaiter u__2;

                internal Enumerator(in DistinctEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    comparer = enumerable.comparer;
                    enumeratorState = EnumeratorState.Uninitialized;
                    set = new Set<TSource>(comparer);

                    state = default;
                    builder = default;
                    s__1 = default;
                    s__2 = default;
                    s__3 = default;
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
                //    switch (enumeratorState)
                //    {
                //        case EnumeratorState.Uninitialized:
                //            if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                //            {
                //                enumeratorState = EnumeratorState.Complete;
                //                goto case EnumeratorState.Complete;
                //            }

                //            set = new Set<TSource>(comparer)
                //            {
                //                enumerator.Current
                //            };
                //            enumeratorState = EnumeratorState.Enumerating;
                //            return true;

                //        case EnumeratorState.Enumerating:
                //            while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //            {
                //                if (set!.Add(enumerator.Current))
                //                    return true;
                //            }

                //            await DisposeAsync();
                //            enumeratorState = EnumeratorState.Complete;
                //            goto case EnumeratorState.Complete;

                //        case EnumeratorState.Complete:
                //        default:
                //            return false;
                //    }
                //}

                public ValueTask<bool> MoveNextAsync()
                {
                    state = -1;
                    builder = AsyncValueTaskMethodBuilder<bool>.Create();
                    builder.Start(ref this);
                    return builder.Task;
                }

                public ValueTask DisposeAsync()
                {
                    enumeratorState = EnumeratorState.Complete;
                    set.Dispose();
                    return enumerator.DisposeAsync();
                }

                void IAsyncStateMachine.MoveNext()
                {
                    var num = state;
                    bool result;
                    try
                    {
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter3;
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2;
                        ValueTaskAwaiter awaiter;
                        switch (num)
                        {
                            default:
                                {
                                    var enumeratorState = s__1 = this.enumeratorState;
                                    switch (s__1)
                                    {
                                        case EnumeratorState.Uninitialized:
                                            break;
                                        case EnumeratorState.Enumerating:
                                            goto IL_0174;
                                        default:
                                            goto end_IL_0008;
                                    }
                                    awaiter3 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter3.IsCompleted)
                                    {
                                        num = state = 0;
                                        u__1 = awaiter3;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
                                        return;
                                    }
                                    goto IL_00d0;
                                }
                            case 0:
                                awaiter3 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_00d0;
                            case 1:
                                awaiter2 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_01e8;
                            case 2:
                                {
                                    awaiter = u__2;
                                    u__2 = default;
                                    num = state = -1;
                                    goto IL_0266;
                                }
                            IL_0174:
                                awaiter2 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                if (!awaiter2.IsCompleted)
                                {
                                    num = state = 1;
                                    u__1 = awaiter2;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                    return;
                                }
                                goto IL_01e8;
                            IL_00d0:
                                s__2 = awaiter3.GetResult();
                                if (!s__2)
                                {
                                    enumeratorState = EnumeratorState.Complete;
                                    break;
                                }
                                set = new Set<TSource>(comparer)
                                {
                                    enumerator.Current
                                };
                                enumeratorState = EnumeratorState.Enumerating;
                                result = true;
                                goto end_IL_0007;
                            IL_01e8:
                                s__3 = awaiter2.GetResult();
                                if (!s__3)
                                {
                                    awaiter = DisposeAsync().GetAwaiter();
                                    if (!awaiter.IsCompleted)
                                    {
                                        num = state = 2;
                                        u__2 = awaiter;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                                        return;
                                    }
                                    goto IL_0266;
                                }
                                if (!set.Add(enumerator.Current))
                                {
                                    goto IL_0174;
                                }
                                result = true;
                                goto end_IL_0007;
                            IL_0266:
                                awaiter.GetResult();
                                enumeratorState = EnumeratorState.Complete;
                                break;
                            end_IL_0008:
                                break;
                        }
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

            readonly async ValueTask<Set<TSource>> FillSetAsync(CancellationToken cancellationToken)
            {
                var set = new Set<TSource>(comparer);
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        _ = set.Add(enumerator.Current);
                }
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken)).Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.AnyAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken)).ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken)).ToList();
        }
    }
}

