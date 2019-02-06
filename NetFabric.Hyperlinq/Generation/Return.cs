using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static ReturnEnumerable<TSource> Return<TSource>(TSource value) =>
            new ReturnEnumerable<TSource>(value);

        public readonly struct ReturnEnumerable<TSource> : IReadOnlyList<TSource>
        {
            readonly TSource value;

            internal ReturnEnumerable(TSource value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => 1;

            public TSource this[int index]
            {
                get
                {
                    if(index != 0) ThrowIndexOutOfRange();
                    
                    return value;

                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
                }
            }

            public struct Enumerator : IEnumerator<TSource>
            {
                readonly TSource value;
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    moveNext = true;
                }

                public TSource Current => value;
                object IEnumerator.Current => value;

                public bool MoveNext()
                {
                    if(moveNext)
                    {
                        moveNext = false;
                        return true;
                    }
                    return false;
                }

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }

            //public ReadOnlyList.SelectReadOnlyList<ReturnEnumerable<TSource>, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) =>
            //    ReadOnlyList.Select<ReturnEnumerable<TSource>, TSource, TResult>(this, selector);

            //public ReadOnlyList.WhereReadOnlyList<ReturnEnumerable<TSource>, TSource> Where(Func<TSource, bool> predicate) =>
            //    ReadOnlyList.Where<ReturnEnumerable<TSource>, TSource>(this, predicate);

            //public TSource First() => ReadOnlyList.First<TSource>(this);
            //public TSource First(Func<TSource, bool> predicate) => First<TSource>(this, predicate);

            //public TSource FirstOrDefault() => FirstOrDefault<TSource>(this);
            //public TSource FirstOrDefault(Func<TSource, bool> predicate) => FirstOrDefault<TSource>(this, predicate);

            //public TSource Single() => Single<TSource>(this);
            //public TSource Single(Func<TSource, bool> predicate) => Single<TSource>(this, predicate);

            //public TSource SingleOrDefault() => SingleOrDefault<TSource>(this);
            //public TSource SingleOrDefault(Func<TSource, bool> predicate) => SingleOrDefault<TSource>(this, predicate);
        }
    }
}

