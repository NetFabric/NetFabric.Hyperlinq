using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static SelectReadOnlyCollection<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyCollection<TSource> source, 
            Func<TSource, TResult> selector) =>
                Select<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

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

            public SelectReadOnlyCollection<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector) =>
                Select<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult, TSelectorResult>(this, selector);

            public TResult First() => First<TResult>(this);
            public TResult First(Func<TResult, bool> predicate) => 
                Enumerable.First<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult FirstOrDefault() => FirstOrDefault<TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate) =>
                Enumerable.FirstOrDefault<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult Single() => Single<TResult>(this);
            public TResult Single(Func<TResult, bool> predicate) =>
                Enumerable.Single<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult SingleOrDefault() => SingleOrDefault<TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate) =>
                Enumerable.SingleOrDefault<SelectReadOnlyCollection<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);
        }
    }
}

