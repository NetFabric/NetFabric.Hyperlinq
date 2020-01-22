using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncEnumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TSource> AsAsyncValueEnumerable<TSource>(this IAsyncEnumerable<TSource> source)
            => new AsyncValueEnumerableWrapper<TSource>(source);

        public readonly partial struct AsyncValueEnumerableWrapper<TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TSource>.AsyncEnumerator>
        {
            readonly IAsyncEnumerable<TSource> source;

            internal AsyncValueEnumerableWrapper(IAsyncEnumerable<TSource> source)
            {
                this.source = source;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new AsyncEnumerator(source, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new AsyncEnumerator(source, cancellationToken);

            public readonly partial struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly IAsyncEnumerator<TSource> enumerator;

                internal AsyncEnumerator(IAsyncEnumerable<TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.GetAsyncEnumerator(cancellationToken);
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly ValueTask<bool> MoveNextAsync() 
                    => enumerator.MoveNextAsync();


                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly ValueTask DisposeAsync() 
                    => enumerator.DisposeAsync();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => AsyncEnumerable.ToArrayAsync(source, cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => AsyncEnumerable.ToListAsync(source, cancellationToken);
        }
    }
}