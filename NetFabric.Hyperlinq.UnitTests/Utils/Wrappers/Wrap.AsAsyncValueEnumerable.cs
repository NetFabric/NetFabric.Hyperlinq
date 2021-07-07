using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static AsyncValueEnumerableWrapper<T> AsAsyncValueEnumerable<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new AsyncValueEnumerableWrapper<T>(source)
            };

        public readonly struct AsyncValueEnumerableWrapper<T> 
            : IAsyncValueEnumerable<T, AsyncEnumerator<T>>
        {
            readonly T[] source;

            internal AsyncValueEnumerableWrapper(T[] source)
                => this.source = source;

            public AsyncEnumerator<T> GetAsyncEnumerator() 
                => new(source);

            AsyncEnumerator<T> IAsyncValueEnumerable<T, AsyncEnumerator<T>>.GetAsyncEnumerator(CancellationToken _) 
                => new(source);

            IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken _) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new AsyncEnumerator<T>(source);
            
            public readonly struct GetAsyncEnumeratorFunction
                : IFunction<AsyncValueEnumerableWrapper<T>, CancellationToken, AsyncEnumerator<T>>
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public AsyncEnumerator<T> Invoke(AsyncValueEnumerableWrapper<T> enumerable, CancellationToken _) 
                    => enumerable.GetAsyncEnumerator();
            }
        }
    }
}