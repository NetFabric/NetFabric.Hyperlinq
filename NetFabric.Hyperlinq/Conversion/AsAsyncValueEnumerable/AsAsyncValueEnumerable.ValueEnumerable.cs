using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TEnumerator, TSource> AsAsyncValueEnumerable<TEnumerator, TSource>(this IValueEnumerable<TSource, TEnumerator> source)
            where TEnumerator : struct, IEnumerator<TSource>
            => new AsyncValueEnumerableWrapper<TEnumerator, TSource>(source);

        public partial struct AsyncValueEnumerableWrapper<TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TEnumerator, TSource>.AsyncEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly IValueEnumerable<TSource, TEnumerator> source;

            internal AsyncValueEnumerableWrapper(IValueEnumerable<TSource, TEnumerator> source) 
                => this.source = source;

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

            public readonly partial struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly TEnumerator enumerator;
                readonly CancellationToken cancellationToken;

                internal AsyncEnumerator(IValueEnumerable<TSource, TEnumerator> enumerable, CancellationToken cancellationToken)
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
        }
    }
}