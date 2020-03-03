using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        [Pure]
        public static SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            AsyncSelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> 
            : IAsyncValueEnumerable<TResult, SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly AsyncSelectorAt<TSource, TResult> selector;

            internal SelectIndexEnumerable(in TEnumerable source, AsyncSelectorAt<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new Enumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<TResult> IAsyncEnumerable<TResult>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new Enumerator(in this, cancellationToken);

            public struct Enumerator
                : IAsyncEnumerator<TResult>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly AsyncSelectorAt<TSource, TResult> selector;
                readonly CancellationToken cancellationToken;
                int index;
                [MaybeNull] TResult current;

                internal Enumerator(in SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    selector = enumerable.selector;
                    this.cancellationToken = cancellationToken;
                    index = -1;
                    current = default!;
                }

                [MaybeNull]
                public readonly TResult Current
                    => current;

                public async ValueTask<bool> MoveNextAsync()
                {
                    if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        index++;
                        current = await selector(enumerator.Current, index, cancellationToken).ConfigureAwait(false);
                        return true;
                    }
                    await DisposeAsync().ConfigureAwait(false);
                    return false;
                }

                public ValueTask DisposeAsync() 
                    => enumerator.DisposeAsync();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.CountAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public AsyncValueEnumerable.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(AsyncSelector<TResult, TSelectorResult> selector)
                => AsyncValueEnumerable.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public AsyncValueEnumerable.SelectIndexEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(AsyncSelectorAt<TResult, TSelectorResult> selector)
                => AsyncValueEnumerable.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public async ValueTask<TResult> FirstAsync(CancellationToken cancellationToken = default)
            {
                var item = await AsyncValueEnumerable.FirstAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
                return await selector(item, 0, cancellationToken).ConfigureAwait(false);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public async ValueTask<TResult> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
            {
                var item = await AsyncValueEnumerable.FirstOrDefaultAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
                return await selector(item, 0, cancellationToken).ConfigureAwait(false);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public async ValueTask<TResult> SingleAsync(CancellationToken cancellationToken = default)
            {
                var item = await AsyncValueEnumerable.SingleAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
                return await selector(item, 0, cancellationToken).ConfigureAwait(false);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public async ValueTask<TResult> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
            {
                var item = await AsyncValueEnumerable.SingleOrDefaultAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken).ConfigureAwait(false);
                return await selector(item, 0, cancellationToken).ConfigureAwait(false);
            }

            public ValueTask<TResult[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, cancellationToken);

            public ValueTask<List<TResult>> ToListAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ToListAsync<TEnumerable, TEnumerator, TSource, TResult>(source, selector, cancellationToken);

            public ValueTask ForEachAsync(AsyncAction<TResult> action, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(source, action, selector, cancellationToken);
            public ValueTask ForEachAsync(AsyncActionAt<TResult> action, CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.ForEachAsync<TEnumerable, TEnumerator, TSource, TResult>(source, action, selector, cancellationToken);
        }
    }
}

