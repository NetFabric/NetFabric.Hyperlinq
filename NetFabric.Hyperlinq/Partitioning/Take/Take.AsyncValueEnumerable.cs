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
            public Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new(in this, cancellationToken);

            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
                => new Enumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IAsyncEnumerator<TSource>
                , IAsyncStateMachine
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
#pragma warning restore IDE0044 // Add readonly modifier
                int counter;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
#pragma warning disable IDE1006 // Naming Styles
                bool s__1;
#pragma warning restore IDE1006 // Naming Styles
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
            public TakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => new(source, Utils.Take(this.count, count));
        }
    }
}