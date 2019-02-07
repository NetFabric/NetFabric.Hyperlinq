using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RepeatEnumerable<TSource> Repeat<TSource>(TSource value) =>
            new RepeatEnumerable<TSource>(value);

        public readonly struct RepeatEnumerable<TSource> : IEnumerable<TSource>
        {
            readonly TSource value;

            internal RepeatEnumerable(TSource value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public TSource this[int index] => value;

            public readonly struct Enumerator : IEnumerator<TSource>
            {
                readonly TSource value;

                internal Enumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                }

                public TSource Current => value;
                object IEnumerator.Current => value;

                public bool MoveNext() => true;

                public void Reset() { }

                public void Dispose() { }
            }

            public SelectEnumerable<RepeatEnumerable<TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) =>
                Select<RepeatEnumerable<TSource>, Enumerator, TSource, TResult>(this, selector);

            public WhereEnumerable<RepeatEnumerable<TSource>, Enumerator, TSource> Where(Func<TSource, bool> predicate) =>
                Where<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource First() => First<RepeatEnumerable<TSource>, Enumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate) => First<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() => FirstOrDefault<RepeatEnumerable<TSource>, Enumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) => FirstOrDefault<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single() => Single<RepeatEnumerable<TSource>, Enumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) => Single<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() => SingleOrDefault<RepeatEnumerable<TSource>, Enumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) => SingleOrDefault<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);
        }
    }

    static class RepeatEnumerableExtensions
    {
        public static int Count<TSource>(this Enumerable.RepeatEnumerable<TSource> source)
            => Enumerable.Count<Enumerable.RepeatEnumerable<TSource>, Enumerable.RepeatEnumerable<TSource>.Enumerator, TSource>(source);
    }
}

