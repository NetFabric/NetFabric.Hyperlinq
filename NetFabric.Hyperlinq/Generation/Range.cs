using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RangeReadOnlyList Range(int start, int count)
        {
            var max = ((long)start) + count - 1;
            if (count < 0 || max > int.MaxValue) ThrowCountOutOfRange();

            return new RangeReadOnlyList(start, count);

            void ThrowCountOutOfRange() => throw new ArgumentOutOfRangeException(nameof(count));
        }

        public readonly struct RangeReadOnlyList : IReadOnlyList<int>
        {
            readonly int start;
            readonly int count;

            internal RangeReadOnlyList(int start, int count)
            {
                this.start = start;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Start => start;

            public int Count => count;

            public int this[int index]
            {
                get
                {
                    if(index < 0 || index >= count) ThrowIndexOutOfRange();

                    return index + start;

                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
                }
            }

            public struct Enumerator : IEnumerator<int>
            {
                readonly int end;
                int current;

                internal Enumerator(in RangeReadOnlyList enumerable)
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

            public ReadOnlyList.SelectReadOnlyList<RangeReadOnlyList, int, TResult> Select<TResult>(Func<int, TResult> selector) =>
                ReadOnlyList.Select<RangeReadOnlyList, int, TResult>(this, selector);

            public ReadOnlyList.WhereReadOnlyList<RangeReadOnlyList, int> Where(Func<int, bool> predicate) =>
                ReadOnlyList.Where<RangeReadOnlyList, int>(this, predicate);

            public int First() => ReadOnlyList.First<RangeReadOnlyList, int>(this);
            public int First(Func<int, bool> predicate) => ReadOnlyList.First<RangeReadOnlyList, int>(this, predicate);

            public int FirstOrDefault() => ReadOnlyList.FirstOrDefault<RangeReadOnlyList, int>(this);
            public int FirstOrDefault(Func<int, bool> predicate) => ReadOnlyList.FirstOrDefault<RangeReadOnlyList, int>(this, predicate);

            public int Single() => ReadOnlyList.Single<RangeReadOnlyList, int>(this);
            public int Single(Func<int, bool> predicate) => ReadOnlyList.Single<RangeReadOnlyList, int>(this, predicate);

            public int SingleOrDefault() => ReadOnlyList.SingleOrDefault<RangeReadOnlyList, int>(this);
            public int SingleOrDefault(Func<int, bool> predicate) => ReadOnlyList.SingleOrDefault<RangeReadOnlyList, int>(this, predicate);
        }
    }
}

