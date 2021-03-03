using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>.AsyncEnumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsyncValueEnumerableWrapper(TEnumerable source) 
                => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source, cancellationToken);
            }
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
                // ReSharper disable once HeapView.BoxingAllocation
                => GetAsyncEnumerator(cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                TEnumerator enumerator;
                readonly CancellationToken cancellationToken;

                internal AsyncEnumerator(TEnumerable enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.GetEnumerator();
                    this.cancellationToken = cancellationToken;
                }

                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IAsyncEnumerator<TSource>.Current
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(enumerator.MoveNext());
                }

                public ValueTask DisposeAsync() 
                {
                    enumerator.Dispose();
                    return default;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => new(result: source.ToArray<TEnumerable, TEnumerator, TSource>());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => new(result: source.ToList<TEnumerable, TEnumerator, TSource>());
        }
    }
}