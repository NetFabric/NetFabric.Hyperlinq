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
        static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new(in source, skipCount, takeCount);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;
            readonly int takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }


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
                int skipCounter;
                int takeCounter;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                bool s__1;
                bool s__2;
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter u__2;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.takeCount;

                    state = default;
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
                //    while (skipCounter > 0)
                //    {
                //        if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                //            return false;

                //        skipCounter--;
                //    }

                //    if (takeCounter > 0)
                //    {
                //        if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //        {
                //            takeCounter--;
                //            return true;
                //        }

                //        takeCounter = 0;
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
                                goto IL_009f;
                            default:
                                if (skipCounter > 0)
                                {
                                    awaiter3 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter3.IsCompleted)
                                    {
                                        num = state = 0;
                                        u__1 = awaiter3;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
                                        return;
                                    }
                                    goto IL_009f;
                                }
                                if (takeCounter > 0)
                                {
                                    awaiter2 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter2.IsCompleted)
                                    {
                                        num = state = 1;
                                        u__1 = awaiter2;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                        return;
                                    }
                                    goto IL_017c;
                                }
                                goto IL_01c2;
                            case 1:
                                awaiter2 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_017c;
                            case 2:
                                {
                                    awaiter = u__2;
                                    u__2 = default;
                                    num = state = -1;
                                    break;
                                }
                            IL_009f:
                                s__1 = awaiter3.GetResult();
                                if (s__1)
                                {
                                    skipCounter--;
                                    goto default;
                                }
                                result = false;
                                goto end_IL_0007;
                            IL_017c:
                                s__2 = awaiter2.GetResult();
                                if (!s__2)
                                {
                                    takeCounter = 0;
                                    goto IL_01c2;
                                }
                                takeCounter--;
                                result = true;
                                goto end_IL_0007;
                            IL_01c2:
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
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => source.SkipTake<TEnumerable, TEnumerator, TSource>(skipCount + Math.Max(0, count), takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => source.SkipTake<TEnumerable, TEnumerator, TSource>(skipCount, Partition.Take(takeCount, count));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, int> source)
            where TEnumerable : IAsyncValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, int>, SkipTakeEnumerable<TEnumerable, TEnumerator, int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, int?> source)
            where TEnumerable : IAsyncValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int?>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, int?>, SkipTakeEnumerable<TEnumerable, TEnumerator, int?>.Enumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, long> source)
            where TEnumerable : IAsyncValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, long>, SkipTakeEnumerable<TEnumerable, TEnumerator, long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, long?> source)
            where TEnumerable : IAsyncValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long?>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, long?>, SkipTakeEnumerable<TEnumerable, TEnumerator, long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, float> source)
            where TEnumerable : IAsyncValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, float>, SkipTakeEnumerable<TEnumerable, TEnumerator, float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, float?> source)
            where TEnumerable : IAsyncValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float?>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, float?>, SkipTakeEnumerable<TEnumerable, TEnumerator, float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, double> source)
            where TEnumerable : IAsyncValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, double>, SkipTakeEnumerable<TEnumerable, TEnumerator, double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, double?> source)
            where TEnumerable : IAsyncValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double?>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, double?>, SkipTakeEnumerable<TEnumerable, TEnumerator, double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, decimal> source)
            where TEnumerable : IAsyncValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, decimal>, SkipTakeEnumerable<TEnumerable, TEnumerator, decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator>(this SkipTakeEnumerable<TEnumerable, TEnumerator, decimal?> source)
            where TEnumerable : IAsyncValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal?>
            => source.SumAsync<SkipTakeEnumerable<TEnumerable, TEnumerator, decimal?>, SkipTakeEnumerable<TEnumerable, TEnumerator, decimal?>.Enumerator, decimal?, decimal>();
    }
}
