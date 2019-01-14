using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RangeEnumerable Range(int start, int count) 
        {
            var max = ((long)start) + count - 1;
            if(count < 0 || max > int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(count));

            return new RangeEnumerable(start, count);
        }

        public readonly struct RangeEnumerable : IReadOnlyList<int>
        {
            readonly int start;
            readonly int count;

            internal RangeEnumerable(int start, int count)
            {
                this.start = start;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => count;

            public int this[int index]
            {
                get
                {
                    if(index < 0 || index >= count)
                        throw new IndexOutOfRangeException(nameof(index));
                    return index + start;
                }
            }

            public struct Enumerator : IEnumerator<int>
            {
                int current;
                readonly int end;

                internal Enumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = checked(enumerable.start + enumerable.count);
                }

                public int Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext() => ++current < end;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}

