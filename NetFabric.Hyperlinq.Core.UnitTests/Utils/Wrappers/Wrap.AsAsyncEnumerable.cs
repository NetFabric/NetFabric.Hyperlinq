using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static AsyncEnumerableWrapper<T> AsAsyncEnumerable<T>(T[] source) 
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                _ => new AsyncEnumerableWrapper<T>(source)
            };

        public class AsyncEnumerableWrapper<T> 
            : IAsyncEnumerable<T>
        {
            readonly T[] source;

            internal AsyncEnumerableWrapper(T[] source)
                => this.source = source;

            public AsyncEnumerator<T> GetAsyncEnumerator() 
                => new(source);
            IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken _) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new AsyncEnumerator<T>(source);
             
            public readonly struct GetAsyncEnumeratorFunction
                : IFunction<AsyncEnumerableWrapper<T>, CancellationToken, AsyncEnumerator<T>>
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public AsyncEnumerator<T> Invoke(AsyncEnumerableWrapper<T> enumerable, CancellationToken _) 
                    => enumerable.GetAsyncEnumerator();
            }
        }
    }
}
