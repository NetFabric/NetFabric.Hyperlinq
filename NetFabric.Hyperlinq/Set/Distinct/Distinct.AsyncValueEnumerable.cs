using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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
            => new(source, comparer);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct DistinctEnumerable<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly IEqualityComparer<TSource>? comparer;

            internal DistinctEnumerable(TEnumerable source, IEqualityComparer<TSource>? comparer)
                => (this.source, this.comparer) = (source, comparer);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IAsyncEnumerator<TSource>
                , IAsyncStateMachine
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly IEqualityComparer<TSource>? comparer;
                Set<TSource> set;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                bool s__1;
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ValueTaskAwaiter u__2;

                internal Enumerator(in DistinctEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    comparer = enumerable.comparer;
                    set = new Set<TSource>(comparer);

                    state = default;
                    builder = default;
                    s__1 = default;
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
                //        if (set.Add(enumerator.Current))
                //            return true;
                //    }

                //    await DisposeAsync();
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
                {
                    set.Dispose();
                    return enumerator.DisposeAsync();
                }

                void IAsyncStateMachine.MoveNext()
                {
                    var num = state;
                    bool result;
                    try
                    {
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter;
                        if (num is 0)
                        {
                            awaiter = u__1;
                            u__1 = default;
                            num = state = -1;
                            goto IL_00c0;
                        }
                        if (num != 1)
                        {
                            goto IL_004c;
                        }
                        var awaiter2 = u__2;
                        u__2 = default;
                        num = state = -1;
                        goto IL_013c;
                    IL_00c0:
                        s__1 = awaiter.GetResult();
                        if (!s__1)
                        {
                            awaiter2 = DisposeAsync().GetAwaiter();
                            if (!awaiter2.IsCompleted)
                            {
                                num = state = 1;
                                u__2 = awaiter2;
                                builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                return;
                            }
                            goto IL_013c;
                        }
                        if (!set.Add(enumerator.Current))
                        {
                            goto IL_004c;
                        }
                        result = true;
                        goto end_IL_0007;
                    IL_004c:
                        awaiter = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = state = 0;
                            u__1 = awaiter;
                            builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                            return;
                        }
                        goto IL_00c0;
                    IL_013c:
                        awaiter2.GetResult();
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

            readonly async ValueTask<Set<TSource>> FillSetAsync(CancellationToken cancellationToken)
            {
                var set = new Set<TSource>(comparer);
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        _ = set.Add(enumerator.Current);
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken).ConfigureAwait(false)).Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => source.AnyAsync<TEnumerable, TEnumerator, TSource>(cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken).ConfigureAwait(false)).ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<IMemoryOwner<TSource>> ToArrayAsync(MemoryPool<TSource> pool, CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken).ConfigureAwait(false)).ToArray(pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken).ConfigureAwait(false)).ToList();
        }
    }
}

