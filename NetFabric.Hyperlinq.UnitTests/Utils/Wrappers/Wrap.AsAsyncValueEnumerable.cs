using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static AsyncValueEnumerable<T> AsAsyncValueEnumerable<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new AsyncValueEnumerable<T>(source);
        }

        public readonly struct AsyncValueEnumerable<T> 
            : IAsyncValueEnumerable<T, AsyncEnumerator<T>>
        {
            readonly T[] source;

            internal AsyncValueEnumerable(T[] source)
                => this.source = source;

            public readonly AsyncEnumerator<T> GetAsyncEnumerator(CancellationToken _) 
                => new AsyncEnumerator<T>(source);
            readonly IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken _) 
                => new AsyncEnumerator<T>(source);
        }
    }
}