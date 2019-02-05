using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectReadOnlyList<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyList<TSource> source, 
            Func<TSource, TResult> selector) =>
                Select<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static SelectReadOnlyList<List<TSource>, List<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, TResult> selector) =>
                Select<List<TSource>, List<TSource>.Enumerator, TSource, TResult>(source, selector);

        public static SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IReadOnlyList<TSource> 
            where TEnumerator : IEnumerator<TSource> 
        {
            if(source == null) ThrowSourceNull();
            if(selector is null) ThrowSelectorNull();

            return new SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public readonly struct SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> 
            : IReadOnlyList<TResult>
            where TEnumerable : IReadOnlyList<TSource> 
            where TEnumerator : IEnumerator<TSource> 
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
                SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> enumerable;
                readonly int count;
                int index;

                internal Enumerator(in SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult> enumerable)
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

            public SelectReadOnlyList<SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector) =>
                Select<SelectReadOnlyList<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult, TSelectorResult>(this, selector);

            public TResult First() => First<TResult>(this);
            public TResult First(Func<TResult, bool> predicate) => First<TResult>(this, predicate);

            public TResult FirstOrDefault() => FirstOrDefault<TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate) => FirstOrDefault<TResult>(this, predicate);

            public TResult Single() => Single<TResult>(this);
            public TResult Single(Func<TResult, bool> predicate) => Single<TResult>(this, predicate);

            public TResult SingleOrDefault() => SingleOrDefault<TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate) => SingleOrDefault<TResult>(this, predicate);
        }
    }
}

