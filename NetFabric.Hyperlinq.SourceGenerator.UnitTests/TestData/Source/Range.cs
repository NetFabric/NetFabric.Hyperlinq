using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static RangeEnumerable Range(int start, int count)
            => new RangeEnumerable(start, count);

        [GeneratorMapping("TSource", "int", true)]
        public readonly partial struct RangeEnumerable
            : IValueReadOnlyCollection<int, RangeEnumerable.DisposableEnumerator>
            , ICollection<int>
        {
            readonly int start;
            readonly int end;

            internal RangeEnumerable(int start, int count)
            {
                this.start = start;
                Count = count;
                end = checked(start + count);
            }

            public readonly int Count { get; }


            public readonly Enumerator GetEnumerator()
                => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<int, DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator();
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator()
                => new DisposableEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator();

            bool ICollection<int>.IsReadOnly
                => true;

            public void CopyTo(int[] array, int arrayIndex)
            {
            }

            public bool Contains(int value)
                => value >= start && value < end;

            void ICollection<int>.Add(int item)
                => throw new NotSupportedException();
            void ICollection<int>.Clear()
                => throw new NotSupportedException();
            bool ICollection<int>.Remove(int item)
                => throw new NotSupportedException();

            public struct Enumerator
            {
            }

            public struct DisposableEnumerator
                : IEnumerator<int>
            {
                public readonly int Current => 0;
                readonly int IEnumerator<int>.Current => 0;
                readonly object IEnumerator.Current => 0;

                public bool MoveNext()
                    => false;

                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}
