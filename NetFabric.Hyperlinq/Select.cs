using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static SelectEnumerable<TSource, TResult> Select<TEnumerable, TSource, TResult>(this TEnumerable source, Func<TSource, TResult> selector) where TEnumerable : IEnumerable<TSource> =>
            new SelectEnumerable<TSource, TResult>(source, selector);

        public static IndexSelectEnumerable<TSource, TResult> Select<TEnumerable, TSource, TResult>(this TEnumerable source, Func<TSource, int, TResult> selector) where TEnumerable : IEnumerable<TSource> =>
            new IndexSelectEnumerable<TSource, TResult>(source, selector);

        public readonly struct SelectEnumerable<TSource, TResult> : IEnumerable<TResult>
        {
            readonly IEnumerable<TSource> source;
            readonly Func<TSource, TResult> selector;

            public SelectEnumerable(IEnumerable<TSource> source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator : IEnumerator<TResult>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, TResult> selector;

                public Enumerator(in SelectEnumerable<TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                }

                public TResult Current => selector(enumerator.Current);
                object IEnumerator.Current => selector(enumerator.Current);

                public bool MoveNext() => enumerator.MoveNext();

                public void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }

        public readonly struct IndexSelectEnumerable<TSource, TResult> : IEnumerable<TResult>
        {
            readonly IEnumerable<TSource> source;
            readonly Func<TSource, int, TResult> selector;

            public IndexSelectEnumerable(IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator : IEnumerator<TResult>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, int, TResult> selector;
                int index;

                public Enumerator(in IndexSelectEnumerable<TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    index = -1;
                }

                public TResult Current => selector(enumerator.Current, index);
                object IEnumerator.Current => selector(enumerator.Current, index);

                public bool MoveNext()
                {
                    index++;
                    return enumerator.MoveNext();
                }

                public void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}

