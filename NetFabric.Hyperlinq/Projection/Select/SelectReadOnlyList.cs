using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectReadOnlyList<TEnumerable, TSource, TResult> Select<TEnumerable, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IReadOnlyList<TSource> 
        {
            if(source == null) ThrowSourceNull();
            if(selector is null) ThrowSelectorNull();

            return new SelectReadOnlyList<TEnumerable, TSource, TResult>(in source, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public readonly struct SelectReadOnlyList<TEnumerable, TSource, TResult> 
            : IReadOnlyList<TResult>
            where TEnumerable : IReadOnlyList<TSource> 
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectReadOnlyList(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => source.Count;

            public TResult this[int index] => selector(source[index]);

            public struct Enumerator : IEnumerator<TResult>
            {
                SelectReadOnlyList<TEnumerable, TSource, TResult> enumerable;
                readonly int count;
                int index;

                internal Enumerator(in SelectReadOnlyList<TEnumerable, TSource, TResult> enumerable)
                {
                    this.enumerable = enumerable;
                    count = enumerable.Count;
                    index = -1;
                }

                public TResult Current => enumerable[index];
                object IEnumerator.Current => enumerable[index];

                public bool MoveNext() => ++index < count;

                public void Reset() => index = -1;

                public void Dispose() {}
            }

            public SelectReadOnlyList<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector) 
                => Select<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult, TSelectorResult>(this, selector);

            public WhereReadOnlyList<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult> Where(Func<TResult, bool> predicate) 
                => Where<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this, predicate);

            public TResult First() 
                => First<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this);
            public TResult First(Func<TResult, bool> predicate) 
                => First<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this, predicate);

            public TResult FirstOrDefault() 
                => FirstOrDefault<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate) 
                => FirstOrDefault<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this, predicate);

            public TResult Single() 
                => Single<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate) 
                => Single<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this, predicate);

            public TResult SingleOrDefault() 
                => SingleOrDefault<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate) 
                => SingleOrDefault<SelectReadOnlyList<TEnumerable, TSource, TResult>, TResult>(this, predicate);

            public IEnumerable<TResult> ToEnumerable()
                => this;

            public TResult[] ToArray()
            {
                var count = source.Count;
                var array = new TResult[count];
                for (var index = 0; index < count; index++)
                    array[index] = selector(source[index]);

                return array;
            }

            public List<TResult> ToList()
            {
                var count = source.Count;
                var list = new List<TResult>(count);
                for (var index = 0; index < count; index++)
                    list.Add(selector(source[index]));

                return list;
            }
        }
    }

    static class SelectReadOnlyListExtensions
    {
        public static int Count<TEnumerable, TSource, TResult>(this ReadOnlyList.SelectReadOnlyList<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            => source.Count;
    }
}

