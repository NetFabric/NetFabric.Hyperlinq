using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static WhereReadOnlyList<TEnumerable, TSource> Where<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();

            return new WhereReadOnlyList<TEnumerable, TSource>(in source, predicate);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
        }

        public readonly struct WhereReadOnlyList<TEnumerable, TSource> 
            : IEnumerable<TSource>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;

            internal WhereReadOnlyList(in TEnumerable source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator : IEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                TSource current;
                int index;

                internal Enumerator(in WhereReadOnlyList<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count;
                    current = default;
                    index = -1;
                }

                public TSource Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                        {
                            current = source[index];
                            return true;
                        }

                        index++;
                    }
                    current = default;
                    return false;
                }

                public void Reset() => index = -1;

                public void Dispose() { }
            }

            public Enumerable.SelectEnumerable<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) =>
                Enumerable.Select<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource, TResult>(this, selector);

            public Enumerable.WhereEnumerable<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource> Where(Func<TSource, bool> predicate) =>
                Enumerable.Where<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this, predicate);

            public TSource First() 
                => Enumerable.First<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate) 
                => Enumerable.First<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault() 
                => Enumerable.FirstOrDefault<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate) 
                => Enumerable.FirstOrDefault<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single() 
                => Enumerable.Single<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate) 
                => Enumerable.Single<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault() 
                => Enumerable.SingleOrDefault<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => Enumerable.SingleOrDefault<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this, predicate);

            public IEnumerable<TSource> ToEnumerable()
                => this;

            public TSource[] ToArray()
                => Enumerable.ToArray<WhereReadOnlyList<TEnumerable, TSource>, Enumerator, TSource>(this);

            public List<TSource> ToList()
            {
                var count = source.Count;
                var list = new List<TSource>(count);
                for (var index = 0; index < count; index++)
                {
                    if (predicate(source[index]))
                        list.Add(source[index]);
                }
                return list;
            }
        }
    }

    static class WhereReadOnlyListExtensions
    {
        public static int Count<TEnumerable, TSource>(this ReadOnlyList.WhereReadOnlyList<TEnumerable, TSource> source)
            where TEnumerable : IReadOnlyList<TSource>
            => Enumerable.Count<ReadOnlyList.WhereReadOnlyList<TEnumerable, TSource>, ReadOnlyList.WhereReadOnlyList<TEnumerable, TSource>.Enumerator, TSource>(source);
    }
}

