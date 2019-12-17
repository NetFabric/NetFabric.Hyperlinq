using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TSource> AsAsyncValueEnumerable<TSource>(this IReadOnlyList<TSource> source)
            => new AsyncValueEnumerableWrapper<TSource>(source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator)
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>(source, getAsyncEnumerator);

        [GenericsTypeMapping("TEnumerable", typeof(ValueEnumerableWrapper<,,>))]
        public readonly struct AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator;

            internal AsyncValueEnumerableWrapper(TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator)
            {
                this.source = source;
                this.getAsyncEnumerator = getAsyncEnumerator;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            public readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => getAsyncEnumerator(source, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => getAsyncEnumerator(source, cancellationToken);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyList.ToArray(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyList.ToList(source);
        }

        [GenericsTypeMapping("TEnumerable", typeof(AsyncValueEnumerableWrapper<>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsyncValueEnumerableWrapper<>.AsyncEnumerator))]
        public readonly struct AsyncValueEnumerableWrapper<TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TSource>.AsyncEnumerator>
        {
            readonly IReadOnlyList<TSource> source;

            internal AsyncValueEnumerableWrapper(IReadOnlyList<TSource> source)
            {
                this.source = source;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            public readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source, cancellationToken);
            }
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source, cancellationToken);
            }

            public readonly struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly CancellationToken cancellationToken;

                internal AsyncEnumerator(IReadOnlyList<TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.GetEnumerator();
                    this.cancellationToken = cancellationToken;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(enumerator.MoveNext());
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask DisposeAsync() 
                {
                    enumerator.Dispose();
                    return new ValueTask();
                }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyList.ToArray(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyList.ToList(source);
        }
    }
}