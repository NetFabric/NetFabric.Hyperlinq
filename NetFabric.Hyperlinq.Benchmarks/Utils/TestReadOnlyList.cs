using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public static class TestReadOnlyList
    {
        public static IReadOnlyList<int> ReferenceType(int count)
            => new EnumerableReferenceType(count);

        public static EnumerableValueType ValueType(int count) 
            => new EnumerableValueType(count);

        public readonly struct EnumerableValueType : IReadOnlyList<int>
        {
            readonly int count;

            public EnumerableValueType(int count)
            {
                this.count = count;
            }

            public readonly int Count => count;

            public readonly int this[int index] => index;

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

        public class EnumerableReferenceType : IReadOnlyList<int>
        {
            readonly int count;

            public EnumerableReferenceType(int count)
            {
                this.count = count;
            }

            public int Count => count;

            public int this[int index] => index;

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