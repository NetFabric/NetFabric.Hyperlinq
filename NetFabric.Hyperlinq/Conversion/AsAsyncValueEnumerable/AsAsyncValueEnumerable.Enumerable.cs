﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TSource> AsAsyncValueEnumerable<TSource>(this IEnumerable<TSource> source)
            => new AsyncValueEnumerableWrapper<TSource>(source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>(source, getAsyncEnumerator);

        [GenericsTypeMapping("TEnumerable", typeof(AsyncValueEnumerableWrapper<,,>))]
        public readonly struct AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator;

            internal AsyncValueEnumerableWrapper(TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator)
            {
                this.source = source;
                this.getAsyncEnumerator = getAsyncEnumerator;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => getAsyncEnumerator(source, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => getAsyncEnumerator(source, cancellationToken);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => Enumerable.ToArray(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => Enumerable.ToList(source);
        }

        [GenericsTypeMapping("TEnumerable", typeof(AsyncValueEnumerableWrapper<>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsyncValueEnumerableWrapper<>.AsyncEnumerator))]
        public struct AsyncValueEnumerableWrapper<TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TSource>.AsyncEnumerator>
        {
            readonly IEnumerable<TSource> source;

            internal AsyncValueEnumerableWrapper(IEnumerable<TSource> source)
            {
                this.source = source;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source);
            }
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source);
            }

            public readonly struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;

                internal AsyncEnumerator(IEnumerable<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                    => new ValueTask<bool>(enumerator.MoveNext());

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
                => Enumerable.ToArray(source);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => Enumerable.ToList(source);
        }
    }
}