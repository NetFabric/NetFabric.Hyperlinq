using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        internal static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, bool> predicate, 
            Func<TSource, TResult> selector) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector);
        }

        public readonly struct WhereSelectEnumerable<TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TSource, TResult>.Enumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;

            internal WhereSelectEnumerable(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public TResult Current
                    => selector(source[index]);
                object IEnumerator.Current
                    => selector(source[index]);


                public bool MoveNext()
                {
                    while (++index < count)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => source.Count(predicate);

            public bool Any()
                => Array.Any<TSource>(source, predicate);

            public List<TResult> ToList()
            {
                var list = new List<TResult>();

                var count = source.Length;
                for (var index = 0; index < count; index++)
                {
                    if (predicate(source[index]))
                        list.Add(selector(source[index]));
                }

                return list;
            }
        }
    }
}

