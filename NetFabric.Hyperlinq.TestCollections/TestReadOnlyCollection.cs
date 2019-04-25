using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class TestReadOnlyCollection
    {
        public static IReadOnlyCollection<long> ReferenceType(int count)
            => new EnumerableReferenceType(count);

        public static EnumerableValueType ValueType(int count) 
            => new EnumerableValueType(count);

        public readonly struct EnumerableValueType : IReadOnlyCollection<long>
        {
            readonly int count;

            public EnumerableValueType(int count)
            {
                this.count = count;
            }

            public int Count => count;

            public Enumerator GetEnumerator() => new Enumerator(count);
            IEnumerator<long> IEnumerable<long>.GetEnumerator() => new Enumerator(count);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            public struct Enumerator : IEnumerator<long>
            {
                readonly int count;
                long current;

                public Enumerator(int count)
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

        public class EnumerableReferenceType : IReadOnlyCollection<long>
        {
            readonly int count;

            public EnumerableReferenceType(int count)
            {
                this.count = count;
            }

            public int Count => count;

            public Enumerator GetEnumerator() => new Enumerator(count);
            IEnumerator<long> IEnumerable<long>.GetEnumerator() => new Enumerator(count);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            public class Enumerator : IEnumerator<long>
            {
                readonly int count;
                long current;

                public Enumerator(int count)
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