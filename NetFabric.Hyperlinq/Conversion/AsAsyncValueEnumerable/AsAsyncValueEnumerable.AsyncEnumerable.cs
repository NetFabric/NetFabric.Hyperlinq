using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TSource> AsAsyncValueEnumerable<TSource>(this IAsyncEnumerable<TSource> source)
            => new(source);

        [GeneratorIgnore] // TODO: to be removed
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator)
            where TEnumerable : IAsyncEnumerable<TSource>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new(source, getAsyncEnumerator);

        public readonly partial struct AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerable : IAsyncEnumerable<TSource>
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
                // ReSharper disable once HeapView.BoxingAllocation
                => getAsyncEnumerator(source, cancellationToken);
        }

        public readonly partial struct AsyncValueEnumerableWrapper<TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TSource>.AsyncEnumerator>
        {
            readonly IAsyncEnumerable<TSource> source;

            internal AsyncValueEnumerableWrapper(IAsyncEnumerable<TSource> source)
                => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new(source, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new AsyncEnumerator(source, cancellationToken);

            public readonly partial struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly IAsyncEnumerator<TSource> enumerator;

                internal AsyncEnumerator(IAsyncEnumerable<TSource> enumerable, CancellationToken cancellationToken)
                    => enumerator = enumerable.GetAsyncEnumerator(cancellationToken);

                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IAsyncEnumerator<TSource>.Current
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly ValueTask<bool> MoveNextAsync() 
                    => enumerator.MoveNextAsync();


                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly ValueTask DisposeAsync() 
                    => enumerator.DisposeAsync();
            }
        }
    }
}