using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public static class TestAsyncEnumerable
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async IAsyncEnumerable<int> ReferenceType(int count)
        {
            for (var value = 0; value < count; value++)
                yield return value;            
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        public static AsyncEnumerable ValueType(int count) 
            => new AsyncEnumerable(count);

        public class AsyncEnumerable : IAsyncEnumerable<int>
        {
            readonly int count;

            public AsyncEnumerable(int count)
                => this.count = count;

            public AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new AsyncEnumerator(count, cancellationToken);
            IAsyncEnumerator<int> IAsyncEnumerable<int>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new AsyncEnumerator(count, cancellationToken);

            public struct AsyncEnumerator : IAsyncEnumerator<int>
            {
                readonly int count;
                readonly CancellationToken cancellationToken;

                public AsyncEnumerator(int count, CancellationToken cancellationToken)
                {
                    this.count = count;
                    this.cancellationToken = cancellationToken;
                    Current = -1;
                }

                public int Current { get; private set; }

                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(++Current < count);
                }

                public ValueTask DisposeAsync() 
                    => default;
            }
        }
    }
}