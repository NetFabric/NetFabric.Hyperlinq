using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public static class TestEnumerable
    {
        public static IEnumerable<int> ReferenceType(int count)
        {
            for (var value = 0; value < count; value++)
                yield return value;            
        }

        public static Enumerable ValueType(int count) 
            => new Enumerable(count);

        public readonly struct Enumerable : IEnumerable<int>
        {
            readonly int count;

            public Enumerable(int count)
            {
                this.count = count;
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(count);
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(count);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            public struct Enumerator : IEnumerator<int>
            {
                readonly int count;
                int current;

                public Enumerator(int count)
                {
                    this.count = count;
                    current = -1;
                }

                public readonly int Current => current;
                readonly object IEnumerator.Current => current;

                public bool MoveNext() => ++current < count;

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }
        }
    }
}