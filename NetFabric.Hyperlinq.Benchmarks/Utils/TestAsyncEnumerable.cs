using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public static class TestAsyncEnumerable
    {
        public static async IAsyncEnumerable<int> ReferenceType(int count)
        {
            for (var value = 0; value < count; value++)
                yield return value;            
        }

        public static AsyncEnumerable ValueType(int count) 
            => new AsyncEnumerable(count);

        public readonly struct AsyncEnumerable : IAsyncEnumerable<int>
        {
            readonly int count;

            public AsyncEnumerable(int count)
                => this.count = count;

            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new AsyncEnumerator(count, cancellationToken);
            readonly IAsyncEnumerator<int> IAsyncEnumerable<int>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new AsyncEnumerator(count, cancellationToken);

            public struct AsyncEnumerator : IAsyncEnumerator<int>
            {
                readonly int count;
                readonly CancellationToken cancellationToken;
                int current;

                public AsyncEnumerator(int count, CancellationToken cancellationToken)
                {
                    this.count = count;
                    this.cancellationToken = cancellationToken;
                    current = -1;
                }

                public int Current 
                    => current;

                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(++current < count);
                }

                public ValueTask DisposeAsync() 
                    => default;
            }
        }
    }
}