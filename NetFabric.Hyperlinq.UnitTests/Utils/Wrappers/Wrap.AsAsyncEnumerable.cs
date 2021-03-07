using System;
using System.Collections;
using System.Collections.Generic;
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
 
            public AsyncEnumerableExtensions.AsyncValueEnumerable<AsyncEnumerableWrapper<T>, AsyncEnumerator<T>, AsyncEnumerator<T>, T, GetAsyncEnumeratorFunction, GetAsyncEnumeratorFunction> AsAsyncValueEnumerable()
                => this.AsAsyncValueEnumerable<AsyncEnumerableWrapper<T>, AsyncEnumerator<T>, T, GetAsyncEnumeratorFunction>();
            
            public readonly struct GetAsyncEnumeratorFunction
                : IFunction<AsyncEnumerableWrapper<T>, CancellationToken, AsyncEnumerator<T>>
            {
                public AsyncEnumerator<T> Invoke(AsyncEnumerableWrapper<T> enumerable, CancellationToken _) 
                    => enumerable.GetAsyncEnumerator();
            }
        }
    }
}
