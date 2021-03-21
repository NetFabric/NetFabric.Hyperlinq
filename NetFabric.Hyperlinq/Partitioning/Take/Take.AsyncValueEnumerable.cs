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
        public static TakeEnumerable<TEnumerable, TEnumerator, TSource> Take<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new(in source, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct TakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal TakeEnumerable(in TEnumerable source, int count)
                => (this.source, this.count) = (source, count);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ValueTaskAwaiter u__2;

                internal Enumerator(in TakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    counter = enumerable.count;

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
                //    if (counter > 0)
                //    {
                //        if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //        {
                //            counter--;
                //            return true;
                //        }

                //        counter = 0;
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
                    => enumerator.DisposeAsync();

                void IAsyncStateMachine.MoveNext()
                {
                    var num = state;
                    bool result;
                    try
                    {
                        ValueTaskAwaiter awaiter;
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2;
                        if (num is not 0)
                        {
                            if (num == 1)
                            {
                                awaiter = u__2;
                                u__2 = default;
                                num = state = -1;
                                goto IL_014a;
                            }
                            if (counter <= 0)
                            {
                                goto IL_00e8;
                            }
                            awaiter2 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                            if (!awaiter2.IsCompleted)
                            {
                                num = state = 0;
                                u__1 = awaiter2;
                                builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                return;
                            }
                        }
                        else
                        {
                            awaiter2 = u__1;
                            u__1 = default;
                            num = state = -1;
                        }
                        s__1 = awaiter2.GetResult();
                        if (!s__1)
                        {
                            counter = 0;
                            goto IL_00e8;
                        }
                        counter--;
                        result = true;
                        goto end_IL_0007;
                    IL_014a:
                        awaiter.GetResult();
                        result = false;
                        goto end_IL_0007;
                    IL_00e8:
                        awaiter = DisposeAsync().GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = state = 1;
                            u__2 = awaiter;
                            builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                            return;
                        }
                        goto IL_014a;
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
            public TakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => source.Take<TEnumerable, TEnumerator, TSource>(Math.Min(this.count, count));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, int> source)
            where TEnumerable : IAsyncValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, int>, TakeEnumerable<TEnumerable, TEnumerator, int>.Enumerator, int, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, int?> source)
            where TEnumerable : IAsyncValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int?>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, int?>, TakeEnumerable<TEnumerable, TEnumerator, int?>.Enumerator, int?, int>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, long> source)
            where TEnumerable : IAsyncValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, long>, TakeEnumerable<TEnumerable, TEnumerator, long>.Enumerator, long, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, long?> source)
            where TEnumerable : IAsyncValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long?>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, long?>, TakeEnumerable<TEnumerable, TEnumerator, long?>.Enumerator, long?, long>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, float> source)
            where TEnumerable : IAsyncValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, float>, TakeEnumerable<TEnumerable, TEnumerator, float>.Enumerator, float, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, float?> source)
            where TEnumerable : IAsyncValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float?>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, float?>, TakeEnumerable<TEnumerable, TEnumerator, float?>.Enumerator, float?, float>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, double> source)
            where TEnumerable : IAsyncValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, double>, TakeEnumerable<TEnumerable, TEnumerator, double>.Enumerator, double, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, double?> source)
            where TEnumerable : IAsyncValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double?>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, double?>, TakeEnumerable<TEnumerable, TEnumerator, double?>.Enumerator, double?, double>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, decimal> source)
            where TEnumerable : IAsyncValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, decimal>, TakeEnumerable<TEnumerable, TEnumerator, decimal>.Enumerator, decimal, decimal>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator>(this TakeEnumerable<TEnumerable, TEnumerator, decimal?> source)
            where TEnumerable : IAsyncValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal?>
            => source.SumAsync<TakeEnumerable<TEnumerable, TEnumerator, decimal?>, TakeEnumerable<TEnumerable, TEnumerator, decimal?>.Enumerator, decimal?, decimal>();
    }
}