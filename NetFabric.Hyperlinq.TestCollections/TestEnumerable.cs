using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
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

            public Enumerator GetEnumerator() => new Enumerator(count);
            IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(count);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            public struct Enumerator : IEnumerator<int>
            {
                readonly int count;
                int current;

                public Enumerator(int count)
                {
                    this.count = count;
                    current = -1;
                }

                public int Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext() => ++current < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}