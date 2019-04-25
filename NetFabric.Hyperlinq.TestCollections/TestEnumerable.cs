using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class TestEnumerable
    {
        public static IEnumerable<long> ReferenceType(long count)
        {
            for (var value = 0; value < count; value++)
                yield return value;            
        }

        public static Enumerable ValueType(long count) 
            => new Enumerable(count);

        public readonly struct Enumerable : IEnumerable<long>
        {
            readonly long count;

            public Enumerable(long count)
            {
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(count);
            IEnumerator<long> IEnumerable<long>.GetEnumerator() => new Enumerator(count);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            public struct Enumerator : IEnumerator<long>
            {
                readonly long count;
                long current;

                public Enumerator(long count)
                {
                    this.count = count;
                    current = -1;
                }

                public long Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext() => ++current < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}