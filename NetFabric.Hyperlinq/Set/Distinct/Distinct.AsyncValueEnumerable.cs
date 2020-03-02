using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TEnumerable, TEnumerator, TSource> Distinct<TEnumerable, TEnumerator, TSource>(
            this TEnumerable source, 
            IEqualityComparer<TSource>? comparer = null)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source, comparer);

        public readonly partial struct DistinctEnumerable<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly IEqualityComparer<TSource>? comparer;

            internal DistinctEnumerable(TEnumerable source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new Enumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new Enumerator(in this, cancellationToken);

            public struct Enumerator
                : IAsyncEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly IEqualityComparer<TSource>? comparer;
                EnumeratorState state;
                HashSet<TSource>? set;

                internal Enumerator(in DistinctEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    comparer = enumerable.comparer;
                    state = EnumeratorState.Uninitialized;
                    set = null;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => enumerator.Current;

                public async ValueTask<bool> MoveNextAsync()
                {
                    switch (state)
                    {
                        case EnumeratorState.Uninitialized:
                            if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                state = EnumeratorState.Complete;
                                goto case EnumeratorState.Complete;
                            }

                            set = new HashSet<TSource>(comparer)
                            {
                                enumerator.Current
                            };
                            state = EnumeratorState.Enumerating;
                            return true;

                        case EnumeratorState.Enumerating:
                            Debug.Assert(set is object);
                            while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                if (set!.Add(enumerator.Current))
                                    return true;
                            }

                            await DisposeAsync();
                            state = EnumeratorState.Complete;
                            goto case EnumeratorState.Complete;

                        case EnumeratorState.Complete:
                        default:
                            return false;
                    }
                }

                public async ValueTask DisposeAsync()
                {
                    await enumerator.DisposeAsync();
                    set?.Clear();
                    set = null;
                }
            }

            // helper function for optimization of non-lazy operations
            readonly async ValueTask<HashSet<TSource>> FillSetAsync(CancellationToken cancellationToken) 
            {
                var set = new HashSet<TSource>(comparer);
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        _ = set.Add(enumerator.Current);
                }
                return set;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => (await FillSetAsync(cancellationToken)).Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => AsyncValueEnumerable.AnyAsync<TEnumerable, TEnumerator, TSource>(source, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => HashSetBindings.ToArray<TSource>(await FillSetAsync(cancellationToken));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly async ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => HashSetBindings.ToList<TSource>(await FillSetAsync(cancellationToken));
        }
    }
}

