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
#pragma warning restore IDE0044 // Add readonly modifier
                readonly IEqualityComparer<TSource>? comparer;
                Set<TSource> set;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
#pragma warning disable IDE1006 // Naming Styles
                bool s__1;
#pragma warning restore IDE1006 // Naming Styles
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

            async ValueTask<Set<TSource>> FillSetAsync(CancellationToken cancellationToken)
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

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken).ConfigureAwait(false)).Count;
            
            #endregion
            
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => source.AnyAsync<TEnumerable, TEnumerator, TSource>(cancellationToken);
            
            #endregion
            
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public DistinctEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public DistinctEnumerable<TEnumerable, TEnumerator, TSource> AsEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public async ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken).ConfigureAwait(false)).ToArray();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public async ValueTask<Lease<TSource>> ToArrayAsync(ArrayPool<TSource> pool, bool clearOnDispose, CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken).ConfigureAwait(false)).ToArray(pool, clearOnDispose);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public async ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken).ConfigureAwait(false)).ToList();
            
            #endregion
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, int> source)
            where TEnumerable : IAsyncValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, int>, DistinctEnumerable<TEnumerable, TEnumerator, int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, int?> source)
            where TEnumerable : IAsyncValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int?>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, int?>, DistinctEnumerable<TEnumerable, TEnumerator, int?>.Enumerator, int?, int>();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, nint> source)
            where TEnumerable : IAsyncValueEnumerable<nint, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nint>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, nint>, DistinctEnumerable<TEnumerable, TEnumerator, nint>.Enumerator, nint, nint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, nint?> source)
            where TEnumerable : IAsyncValueEnumerable<nint?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nint?>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, nint?>, DistinctEnumerable<TEnumerable, TEnumerator, nint?>.Enumerator, nint?, nint>();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, nuint> source)
            where TEnumerable : IAsyncValueEnumerable<nuint, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nuint>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, nuint>, DistinctEnumerable<TEnumerable, TEnumerator, nuint>.Enumerator, nuint, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, nuint?> source)
            where TEnumerable : IAsyncValueEnumerable<nuint?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nuint?>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, nuint?>, DistinctEnumerable<TEnumerable, TEnumerator, nuint?>.Enumerator, nuint?, nuint>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, long> source)
            where TEnumerable : IAsyncValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, long>, DistinctEnumerable<TEnumerable, TEnumerator, long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, long?> source)
            where TEnumerable : IAsyncValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long?>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, long?>, DistinctEnumerable<TEnumerable, TEnumerator, long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, float> source)
            where TEnumerable : IAsyncValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, float>, DistinctEnumerable<TEnumerable, TEnumerator, float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, float?> source)
            where TEnumerable : IAsyncValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float?>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, float?>, DistinctEnumerable<TEnumerable, TEnumerator, float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, double> source)
            where TEnumerable : IAsyncValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, double>, DistinctEnumerable<TEnumerable, TEnumerator, double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, double?> source)
            where TEnumerable : IAsyncValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double?>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, double?>, DistinctEnumerable<TEnumerable, TEnumerator, double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, decimal> source)
            where TEnumerable : IAsyncValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, decimal>, DistinctEnumerable<TEnumerable, TEnumerator, decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator>(this DistinctEnumerable<TEnumerable, TEnumerator, decimal?> source)
            where TEnumerable : IAsyncValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal?>
            => source.SumAsync<DistinctEnumerable<TEnumerable, TEnumerator, decimal?>, DistinctEnumerable<TEnumerable, TEnumerator, decimal?>.Enumerator, decimal?, decimal>();
    }
}

