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
        static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate> WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(
            this TEnumerable source,
            TPredicate predicate,
            AsyncSelector<TSource, TResult> selector)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
            => new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(in source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate>
            : IAsyncValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate>.Enumerator>
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            readonly TEnumerable source;
            readonly TPredicate predicate;
            readonly AsyncSelector<TSource, TResult> selector;

            internal WhereSelectEnumerable(in TEnumerable source, TPredicate predicate, AsyncSelector<TSource, TResult> selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);


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
                readonly TPredicate predicate;
                readonly AsyncSelector<TSource, TResult> selector;
                readonly CancellationToken cancellationToken;

                int state;
                AsyncValueTaskMethodBuilder<bool> builder;
                [MaybeNull, AllowNull] TSource item;
                bool s__2;
                [MaybeNull, AllowNull] TResult s__3;
                bool s__4;
                ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter u__1;
                ConfiguredValueTaskAwaitable<TResult>.ConfiguredValueTaskAwaiter u__2;
                ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter u__3;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    this.cancellationToken = cancellationToken;
                    Current = default!;

                    state = -1;
                    builder = default;
                    item = default;
                    s__2 = default;
                    s__3 = default;
                    s__4 = default;
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
                //    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                //    {
                //        var item = enumerator.Current;
                //        if (await predicate(item, cancellationToken).ConfigureAwait(false))
                //        {
                //            Current = await selector(item, cancellationToken).ConfigureAwait(false);
                //            return true;
                //        }
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
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter4;
                        ConfiguredValueTaskAwaitable<TResult>.ConfiguredValueTaskAwaiter awaiter3;
                        ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2;
                        ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
                        switch (num)
                        {
                            case 0:
                                awaiter4 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_00d2;
                            case 1:
                                awaiter3 = u__2;
                                u__2 = default;
                                num = state = -1;
                                goto IL_0172;
                            default:
                                awaiter2 = enumerator.MoveNextAsync().ConfigureAwait(false).GetAwaiter();
                                if (!awaiter2.IsCompleted)
                                {
                                    num = state = 2;
                                    u__1 = awaiter2;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
                                    return;
                                }
                                goto IL_0214;
                            case 2:
                                awaiter2 = u__1;
                                u__1 = default;
                                num = state = -1;
                                goto IL_0214;
                            case 3:
                                {
                                    awaiter = u__3;
                                    u__3 = default;
                                    num = state = -1;
                                    break;
                                }
                            IL_00d2:
                                s__2 = awaiter4.GetResult();
                                if (s__2)
                                {
                                    awaiter3 = selector(item, cancellationToken).ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter3.IsCompleted)
                                    {
                                        num = state = 1;
                                        u__2 = awaiter3;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
                                        return;
                                    }
                                    goto IL_0172;
                                }
                                goto default;
                            IL_0214:
                                s__4 = awaiter2.GetResult();
                                if (!s__4)
                                {
                                    awaiter = DisposeAsync().ConfigureAwait(false).GetAwaiter();
                                    if (!awaiter.IsCompleted)
                                    {
                                        num = state = 3;
                                        u__3 = awaiter;
                                        builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                                        return;
                                    }
                                    break;
                                }
                                item = enumerator.Current;
                                awaiter4 = predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false).GetAwaiter();
                                if (!awaiter4.IsCompleted)
                                {
                                    num = state = 0;
                                    u__1 = awaiter4;
                                    builder.AwaitUnsafeOnCompleted(ref awaiter4, ref this);
                                    return;
                                }
                                goto IL_00d2;
                            IL_0172:
                                s__3 = awaiter3.GetResult();
                                Current = s__3;
                                s__3 = default;
                                result = true;
                                goto end_IL_0007;
                        }
                        awaiter.GetResult();
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

            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.CountAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.AnyAsync<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, cancellationToken);

            public ValueTask<Option<TResult>> ElementAtAsync(int index, CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, index, predicate, selector, cancellationToken);


            public ValueTask<Option<TResult>> FirstAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.FirstAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, cancellationToken);


            public ValueTask<Option<TResult>> SingleAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.SingleAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, cancellationToken);

            public ValueTask<TResult[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, cancellationToken);

            public ValueTask<IMemoryOwner<TResult>> ToArrayAsync(MemoryPool<TResult> pool, CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, pool, cancellationToken);

            public ValueTask<List<TResult>> ToListAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerableExtensions.ToListAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector, cancellationToken);

            public async ValueTask<Dictionary<TKey, TResult>> ToDictionaryAsync<TKey>(AsyncSelector<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
            {
                var dictionary = new Dictionary<TKey, TResult>(0, comparer);

                TResult result;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var item = enumerator.Current;
                        if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        {
                            result = await selector(item, cancellationToken).ConfigureAwait(false);
                            dictionary.Add(await keySelector(result, cancellationToken).ConfigureAwait(false), result);
                        }
                    }
                }

                return dictionary;
            }

            public async ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(AsyncSelector<TResult, TKey> keySelector, AsyncSelector<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);

                TResult result;
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var item = enumerator.Current;
                        if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        {
                            result = await selector(item, cancellationToken).ConfigureAwait(false);
                            dictionary.Add(
                                await keySelector(result, cancellationToken).ConfigureAwait(false),
                                await elementSelector(result, cancellationToken).ConfigureAwait(false));
                        }
                    }
                }

                return dictionary;
            }
        }
    }
}

