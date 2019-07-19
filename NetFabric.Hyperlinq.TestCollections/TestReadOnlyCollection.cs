using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class TestReadOnlyCollection
    {
        public static IReadOnlyCollection<int> ReferenceType(int count)
            => new EnumerableReferenceType(count);

        public static EnumerableValueType ValueType(int count) 
            => new EnumerableValueType(count);

        public readonly struct EnumerableValueType : IReadOnlyCollection<int>
        {
            readonly int count;

            public EnumerableValueType(int count)
            {
                this.count = count;
            }

            public int Count => count;

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

        public class EnumerableReferenceType : IReadOnlyCollection<int>
        {
            readonly int count;

            public EnumerableReferenceType(int count)
            {
                this.count = count;
            }

            public int Count => count;

            public Enumerator GetEnumerator() => new Enumerator(count);
            IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(count);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            public class Enumerator : IEnumerator<int>
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