using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IReadOnlyCollection<TSource> 
            where TEnumerator : IEnumerator<TSource> 
        {
            if(source == null) ThrowSourceNull();
            if(selector is null) ThrowSelectorNull();

            return new SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public readonly struct SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>
            : IReadOnlyCollection<TResult>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectReadOnlyCollection(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => source.Count;

            public struct Enumerator : IEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                }

                public TResult Current => selector(enumerator.Current);
                object IEnumerator.Current => selector(enumerator.Current);

                public bool MoveNext() => enumerator.MoveNext();

                public void Reset() => enumerator.Reset();

                public void Dispose() => enumerator.Dispose();
            }

            public SelectReadOnlyCollection<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector) 
                => Select<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult, TSelectorResult>(this, selector);

            public Enumerable.WhereEnumerable<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult> Where(Func<TResult, bool> predicate) 
                => Enumerable.Where<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult First() 
                => First<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate) 
                => Enumerable.First<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult FirstOrDefault() 
                => FirstOrDefault<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate) 
                => Enumerable.FirstOrDefault<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult Single() 
                => Single<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate) 
                => Enumerable.Single<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult SingleOrDefault() 
                => SingleOrDefault<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate) 
                => Enumerable.SingleOrDefault<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public IEnumerable<TResult> ToEnumerable()
                => this;

            public TResult[] ToArray()
                => ToArray<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);

            public List<TResult> ToList()
                => ToList<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, TResult>(this);
        }
    }

    static class SelectReadOnlyCollectionExtensions
    {
        public static int Count<TEnumerable, TEnumerator, TSource, TResult>(this ReadOnlyCollection.SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => source.Count;
    }
}

