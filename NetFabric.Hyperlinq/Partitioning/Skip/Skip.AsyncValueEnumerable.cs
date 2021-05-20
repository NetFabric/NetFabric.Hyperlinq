using System;
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
        public static SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new(in source, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipEnumerable<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal SkipEnumerable(in TEnumerable source, int count)
            {
                this.source = source;
                this.count = count;
            }


            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
                => new Enumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IAsyncEnumerator<TSource>
                , IAsyncStateMachine
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                int counter;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                bool s__1;
                bool s__2;
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;

                internal Enumerator(in SkipEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    counter = enumerable.count;

                    state = default;
                    builder = default;
                    s__1 = default;
                    s__2 = default;
                    u__1 = default;
                }

                public readonly TSource Current
                    => enumerator.Current;
                readonly TSource IAsyncEnumerator<TSource>.Current
                    => enumerator.Current;

                //public async ValueTask<bool> MoveNextAsync()
                //{
                //    while (counter > 0)
                //    {
                //        if(!await enumerator.MoveNextAsync().ConfigureAwait(false))
                //            return false;

                //        counter--;
                //    }

                //    return await enumerator.MoveNextAsync().ConfigureAwait(false);                    
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
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter;
                        if (num is 0)
                        {
                            awaiter = u__1;
                            u__1 = default;
                            num = state = -1;
                            goto IL_0091;
                        }
                        if (num != 1)
                        {
                            goto IL_00cb;
                        }
                        var awaiter2 = u__1;
                        u__1 = default;
                        num = state = -1;
                        goto IL_0153;
                    IL_0091:
                        s__1 = awaiter.GetResult();
                        if (s__1)
                        {
                            counter--;
                            goto IL_00cb;
                        }
                        result = false;
                        goto end_IL_0007;
                    IL_0153:
                        s__2 = awaiter2.GetResult();
                        result = s__2;
                        goto end_IL_0007;
                    IL_00cb:
                        if (counter > 0)
                        {
                            awaiter = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                num = state = 0;
                                u__1 = awaiter;
                                builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                                return;
                            }
                            goto IL_0091;
                        }
                        awaiter2 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                        if (!awaiter2.IsCompleted)
                        {
                            num = state = 1;
                            u__1 = awaiter2;
                            builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                            return;
                        }
                        goto IL_0153;
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
            public SkipEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => source.Skip<TEnumerable, TEnumerator, TSource>(this.count + count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => source.SkipTake<TEnumerable, TEnumerator, TSource>(this.count, count);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, int> source)
            where TEnumerable : IAsyncValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, int>, SkipEnumerable<TEnumerable, TEnumerator, int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, int?> source)
            where TEnumerable : IAsyncValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int?>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, int?>, SkipEnumerable<TEnumerable, TEnumerator, int?>.Enumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, long> source)
            where TEnumerable : IAsyncValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, long>, SkipEnumerable<TEnumerable, TEnumerator, long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, long?> source)
            where TEnumerable : IAsyncValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long?>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, long?>, SkipEnumerable<TEnumerable, TEnumerator, long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, float> source)
            where TEnumerable : IAsyncValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, float>, SkipEnumerable<TEnumerable, TEnumerator, float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, float?> source)
            where TEnumerable : IAsyncValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float?>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, float?>, SkipEnumerable<TEnumerable, TEnumerator, float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, double> source)
            where TEnumerable : IAsyncValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, double>, SkipEnumerable<TEnumerable, TEnumerator, double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, double?> source)
            where TEnumerable : IAsyncValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double?>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, double?>, SkipEnumerable<TEnumerable, TEnumerator, double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, decimal> source)
            where TEnumerable : IAsyncValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, decimal>, SkipEnumerable<TEnumerable, TEnumerator, decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator>(this SkipEnumerable<TEnumerable, TEnumerator, decimal?> source)
            where TEnumerable : IAsyncValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal?>
            => source.SumAsync<SkipEnumerable<TEnumerable, TEnumerator, decimal?>, SkipEnumerable<TEnumerable, TEnumerator, decimal?>.Enumerator, decimal?, decimal>();
    }
}
