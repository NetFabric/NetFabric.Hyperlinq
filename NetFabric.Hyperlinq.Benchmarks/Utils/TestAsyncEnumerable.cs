using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public static class TestAsyncEnumerable
    {

        public static Enumerable ValueType(int[] array) 
            => new Enumerable(array);

        public static IAsyncEnumerable<int> ReferenceType(int[] array)
            => new ReferenceEnumerable(array);

        public class Enumerable : IAsyncEnumerable<int>
        {
            readonly int[] array;

            public Enumerable(int[] array)
                => this.array = array;

            public Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new Enumerator(array, cancellationToken);
            IAsyncEnumerator<int> IAsyncEnumerable<int>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new Enumerator(array, cancellationToken);

            public struct Enumerator : IAsyncEnumerator<int>
            {
                readonly int[] array;
                readonly CancellationToken cancellationToken;
                int index;

                public Enumerator(int[] array, CancellationToken cancellationToken)
                {
                    this.array = array;
                    this.cancellationToken = cancellationToken;
                    index = -1;
                }

                public int Current => array[index];

                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(++index < array.Length);
                }

                public ValueTask DisposeAsync() 
                    => default;
            }
        }

        class ReferenceEnumerable : IAsyncEnumerable<int>
        {
            readonly int[] array;

            public ReferenceEnumerable(int[] array)
                => this.array = array;

            public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken)
                => new Enumerator(array, cancellationToken);

            class Enumerator : IAsyncEnumerator<int>
            {
                readonly int[] array;
                readonly CancellationToken cancellationToken;
                int index;

                public Enumerator(int[] array, CancellationToken cancellationToken)
                {
                    this.array = array;
                    this.cancellationToken = cancellationToken;
                    index = -1;
                }

                public int Current => array[index];

                public ValueTask<bool> MoveNextAsync()
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(++index < array.Length);
                }

                public ValueTask DisposeAsync()
                    => default;
            }
        }
    }
}