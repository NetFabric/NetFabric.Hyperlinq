using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static ReadOnlyList.RepeatCountReadOnlyList<TSource> Repeat<TSource>(TSource value, int count)
        {
            if (count < 0) ThrowCountOutOfRange();

            return new ReadOnlyList.RepeatCountReadOnlyList<TSource>(value, count);

            void ThrowCountOutOfRange() => throw new ArgumentOutOfRangeException(nameof(count));
        }
    }

    public static partial class ReadOnlyList
    {
        public readonly struct RepeatCountReadOnlyList<TSource> : IReadOnlyList<TSource>
        {
            readonly TSource value;
            readonly int count;

            internal RepeatCountReadOnlyList(TSource value, int count)
            {
                this.value = value;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => count;

            public TSource this[int index]
            {
                get
                {
                    if(index < 0 || index >= count)
                        ThrowIndexOutOfRange();
                    return value;

                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
                }
            }

            public struct Enumerator : IEnumerator<TSource>
            {
                readonly TSource value;
                int counter;

                internal Enumerator(in RepeatCountReadOnlyList<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count + 1;
                }

                public TSource Current => value;
                object IEnumerator.Current => value;

                public bool MoveNext() => --counter > 0;

                public void Reset() { }

                public void Dispose() { }
            }

            public SelectReadOnlyList<RepeatCountReadOnlyList<TSource>, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) =>
                Select<RepeatCountReadOnlyList<TSource>, TSource, TResult>(this, selector);

            public WhereReadOnlyList<RepeatCountReadOnlyList<TSource>, TSource> Where(Func<TSource, bool> predicate) =>
                Where<RepeatCountReadOnlyList<TSource>, TSource>(this, predicate);

            public TSource First() => ReadOnlyList.First<TSource>(this);
            public TSource First(Func<TSource, bool> predicate) => First<TSource>(this, predicate);

            public TSource FirstOrDefault() => FirstOrDefault<TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) => FirstOrDefault<TSource>(this, predicate);

            public TSource Single() => Single<TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) => Single<TSource>(this, predicate);

            public TSource SingleOrDefault() => SingleOrDefault<TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) => SingleOrDefault<TSource>(this, predicate);
        }
    }
}

