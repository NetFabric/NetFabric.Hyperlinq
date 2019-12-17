using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TSource> AsAsyncValueEnumerable<TSource>(this TSource[] source)
            => new AsyncValueEnumerableWrapper<TSource>(source);

        [GenericsTypeMapping("TEnumerable", typeof(AsyncValueEnumerableWrapper<>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsyncValueEnumerableWrapper<>.AsyncEnumerator))]
        public readonly struct AsyncValueEnumerableWrapper<TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TSource>.AsyncEnumerator>
        {
            readonly TSource[] source;

            internal AsyncValueEnumerableWrapper(TSource[] source)
            {
                this.source = source;
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

            public readonly int Count => source.Length;

            public readonly ref readonly TSource this[int index] => ref source[index];

            public struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly CancellationToken cancellationToken;
                readonly int count;
                int index;

                internal AsyncEnumerator(TSource[] source, CancellationToken cancellationToken)
                {
                    this.source = source;
                    this.cancellationToken = cancellationToken;
                    count = source.Length;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }
                [MaybeNull]
                readonly TSource IAsyncEnumerator<TSource>.Current 
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(++index < count);
                }

                public readonly ValueTask DisposeAsync() 
                    => default;
            }
        }
    }
}