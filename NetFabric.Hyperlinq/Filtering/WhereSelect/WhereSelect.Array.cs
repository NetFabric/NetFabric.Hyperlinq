using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, bool> predicate, 
            Func<TSource, TResult> selector) 
            => new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector, 0, source.Length);

        static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this TSource[] source,
            Func<TSource, bool> predicate,
            Func<TSource, TResult> selector,
            int skipCount, int takeCount)
            => new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector, skipCount, takeCount);

        public readonly struct WhereSelectEnumerable<TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TSource, TResult>.Enumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereSelectEnumerable(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
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
                readonly int end;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TResult Current
                    => selector(source[index]);
                object IEnumerator.Current
                    => selector(source[index]);

                public bool MoveNext()
                {
                    while (++index < end)
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
                => Array.Count<TSource>(source, predicate, skipCount, takeCount);
            public int Count(Func<TSource, bool> predicate)
                => Array.Count<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public int Count(Func<TSource, int, bool> predicate)
                => Array.Count<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public bool Any()
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);
            public bool Any(Func<TSource, bool> predicate)
                => Array.Any<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public bool Any(Func<TSource, int, bool> predicate)
                => Array.Any<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public List<TResult> ToList()
            {
                var list = new List<TResult>();

                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        list.Add(selector(source[index]));
                }

                return list;
            }
        }
    }
}

