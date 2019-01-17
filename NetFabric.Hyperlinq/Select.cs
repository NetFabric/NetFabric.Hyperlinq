using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) 
        {
            if(source == null)
                ThrowSourceNull();

            if(selector == null)
                ThrowSelectorNull();

            return new SelectEnumerable<TSource, TResult>(source, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public static SelectCollection<TSource, TResult> Select<TSource, TResult>(this IReadOnlyCollection<TSource> source, Func<TSource, TResult> selector) 
        {
            if(source == null)
                ThrowSourceNull();

            if(selector == null)
                ThrowSelectorNull();

            return new SelectCollection<TSource, TResult>(source, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public static SelectList<TSource, TResult> Select<TSource, TResult>(this IReadOnlyList<TSource> source, Func<TSource, TResult> selector) 
        {
            if(source == null)
                ThrowSourceNull();

            if(selector == null)
                ThrowSelectorNull();

            return new SelectList<TSource, TResult>(source, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public static IndexSelectEnumerable<TSource, TResult> Select<TEnumerable, TSource, TResult>(this TEnumerable source, Func<TSource, int, TResult> selector) 
            where TEnumerable : IEnumerable<TSource> 
        {
            if(source == null)
                ThrowSourceNull();

            if(selector == null)
                ThrowSelectorNull();

            return new IndexSelectEnumerable<TSource, TResult>(source, selector);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
        }

        public readonly struct SelectEnumerable<TSource, TResult> : IEnumerable<TResult>
        {
            readonly IEnumerable<TSource> source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(IEnumerable<TSource> source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public readonly struct Enumerator : IEnumerator<TResult>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in SelectEnumerable<TSource, TResult> enumerable)
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

        public readonly struct SelectCollection<TSource, TResult> : IReadOnlyCollection<TResult>
        {
            readonly IReadOnlyCollection<TSource> source;
            readonly Func<TSource, TResult> selector;

            internal SelectCollection(IReadOnlyCollection<TSource> source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => source.Count;

            public readonly struct Enumerator : IEnumerator<TResult>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in SelectCollection<TSource, TResult> enumerable)
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

        public readonly struct SelectList<TSource, TResult> : IReadOnlyList<TResult>
        {
            readonly IReadOnlyList<TSource> source;
            readonly Func<TSource, TResult> selector;

            internal SelectList(IReadOnlyList<TSource> source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => source.Count;

            public TResult this[int index]
            {
                get 
                {
                    if(index < 0 || index >= source.Count)
                        ThrowIndexOutOfRange();

                    return selector(source[index]);

                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
                }
            }

            public readonly struct Enumerator : IEnumerator<TResult>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, TResult> selector;

                internal Enumerator(in SelectList<TSource, TResult> enumerable)
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

            internal IndexSelectEnumerable(IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
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

                internal Enumerator(in IndexSelectEnumerable<TSource, TResult> enumerable)
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

