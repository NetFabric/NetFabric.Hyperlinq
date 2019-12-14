using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static AsyncEnumerable<T> AsAsyncEnumerable<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new AsyncEnumerable<T>(source);
        }

        public readonly struct AsyncEnumerable<T> 
            : IAsyncEnumerable<T>
        {
            readonly T[] source;

            internal AsyncEnumerable(T[] source)
            {
                this.source = source;
            }

            public readonly AsyncEnumerator<T> GetAsyncEnumerator() => new AsyncEnumerator<T>(source);
            readonly IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken _) => new AsyncEnumerator<T>(source);
        }
    }
}