using System;
using System.Collections;
using System.Collections.Generic;
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

            public readonly AsyncEnumerator<T> GetAsyncEnumerator() 
                => new(source);
            readonly AsyncEnumerator<T> IAsyncValueEnumerable<T, AsyncEnumerator<T>>.GetAsyncEnumerator(CancellationToken _) 
                => new(source);
            readonly IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken _) 
                => new AsyncEnumerator<T>(source);
        }
    }
}