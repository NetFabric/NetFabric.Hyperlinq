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

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int offset;
            readonly int count;

            internal SkipTakeEnumerable(in TEnumerable source, int offset, int count)
                => (this.source, this.offset, this.count) = (source, offset, count);

            internal SkipTakeEnumerable(in TEnumerable source, (int Offset, int Count) slice)
                => (this.source, offset, count) = (source, slice.Offset, slice.Count);

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
                int skipCounter;
                int takeCounter;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
#pragma warning disable IDE1006 // Naming Styles
                bool s__1;
                bool s__2;
#pragma warning restore IDE1006 // Naming Styles
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter u__2;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    skipCounter = enumerable.offset;
                    takeCounter = enumerable.count;

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
                {
                }
            }

            #region Partitioning

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => new(source, Utils.Skip(this.count, offset + count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => new(source, offset, Utils.Take(this.count, count));

            #endregion
        }
    }
}
