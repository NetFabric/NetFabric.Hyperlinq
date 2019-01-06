using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RangeEnumerable Range(int start, int count) =>
            new RangeEnumerable(start, count);

        public struct RangeEnumerable : IEnumerable<int>
        {
            readonly int start;
            readonly int count;

            public RangeEnumerable(int start, int count)
            {
                this.start = start;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(ref this);
            IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(ref this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(ref this);

            public struct Enumerator : IEnumerator<int>
            {
                int current;
                readonly int end;

                public Enumerator(ref RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = enumerable.start + enumerable.count;
                }

                public int Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext() => current++ < end;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}

