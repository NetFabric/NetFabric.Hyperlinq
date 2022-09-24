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
            readonly int offset;

            internal SkipEnumerable(in TEnumerable source, int offset)
                => (this.source, this.offset) = (source, offset);

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
                bool s__2;
#pragma warning restore IDE1006 // Naming Styles
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;

                internal Enumerator(in SkipEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    counter = enumerable.offset;

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
            public SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => new(source, offset + count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => new(source, offset, count);
        }
    }
}
