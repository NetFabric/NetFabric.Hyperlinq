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
        [GenericsTypeMapping("TEnumerator", typeof(AsyncValueEnumerableWrapper<>.DisposableAsyncEnumerator))]
        public readonly struct AsyncValueEnumerableWrapper<TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TSource>.DisposableAsyncEnumerator>
        {
            readonly TSource[] source;

            internal AsyncValueEnumerableWrapper(TSource[] source) 
                => this.source = source;

            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source, cancellationToken);
            }
            readonly DisposableAsyncEnumerator IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TSource>.DisposableAsyncEnumerator>.GetAsyncEnumerator(CancellationToken cancellationToken) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new DisposableAsyncEnumerator(source, cancellationToken);
            }
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new DisposableAsyncEnumerator(source, cancellationToken);
            }

            public readonly int Count => source.Length;

            public readonly ref readonly TSource this[int index] => ref source[index];

            public struct AsyncEnumerator
            {
                readonly TSource[] source;
                readonly CancellationToken cancellationToken;
                int index;

                internal AsyncEnumerator(TSource[] source, CancellationToken cancellationToken)
                {
                    this.source = source;
                    this.cancellationToken = cancellationToken;
                    index = -1;
                }

                [MaybeNull]
                public readonly ref readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => ref source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(++index < source.Length);
                }
            }

            public struct DisposableAsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly CancellationToken cancellationToken;
                int index;

                internal DisposableAsyncEnumerator(TSource[] source, CancellationToken cancellationToken)
                {
                    this.source = source;
                    this.cancellationToken = cancellationToken;
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
                    return new ValueTask<bool>(++index < source.Length);
                }

                public readonly ValueTask DisposeAsync()
                    => default;
            }
        }
    }
}