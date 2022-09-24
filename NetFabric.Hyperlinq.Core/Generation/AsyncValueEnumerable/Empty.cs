using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static EmptyEnumerable<TSource> Empty<TSource>() 
            => new();

        public readonly partial struct EmptyEnumerable<TSource>
            : IAsyncValueEnumerable<TSource, EmptyEnumerable<TSource>.DisposableEnumerator>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#pragma warning disable IDE0060 // Remove unused parameter
            public Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new();
#pragma warning restore IDE0060 // Remove unused parameter
            DisposableEnumerator IAsyncValueEnumerable<TSource, DisposableEnumerator>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new();
            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator();

            public readonly struct Enumerator
            {
                public TSource Current
                    => default!;

                public ValueTask<bool> MoveNextAsync() 
                    => default;
            }

            public readonly struct DisposableEnumerator
                : IAsyncEnumerator<TSource>
            {
                public TSource Current
                    => default!;

                TSource IAsyncEnumerator<TSource>.Current
                    => default!;

                public ValueTask<bool> MoveNextAsync()
                    => default;

                public ValueTask DisposeAsync() 
                    => default;
            }
        }
    }
}

