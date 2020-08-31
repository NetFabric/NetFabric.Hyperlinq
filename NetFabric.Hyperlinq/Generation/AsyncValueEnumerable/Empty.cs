using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            EmptyEnumerable<TSource>.Instance;

        public partial class EmptyEnumerable<TSource>
            : IAsyncValueEnumerable<TSource, EmptyEnumerable<TSource>.DisposableEnumerator>
        {
            public static readonly EmptyEnumerable<TSource> Instance = new EmptyEnumerable<TSource>();

            EmptyEnumerable() { }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#pragma warning disable IDE0060 // Remove unused parameter
            public Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default)
                => new Enumerator();
#pragma warning restore IDE0060 // Remove unused parameter
            DisposableEnumerator IAsyncValueEnumerable<TSource, EmptyEnumerable<TSource>.DisposableEnumerator>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new DisposableEnumerator();
            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
                => new DisposableEnumerator();

            public readonly struct Enumerator
            {
                [MaybeNull]                
                public readonly TSource Current
                    => default;

                public readonly ValueTask<bool> MoveNextAsync() 
                    => default;
            }

            public readonly struct DisposableEnumerator
                : IAsyncEnumerator<TSource>
            {
                [MaybeNull]
                public readonly TSource Current
                    => default;
                readonly TSource IAsyncEnumerator<TSource>.Current
                    => default;

                public readonly ValueTask<bool> MoveNextAsync()
                    => default;

                public readonly ValueTask DisposeAsync() 
                    => default;
            }
        }
    }
}

