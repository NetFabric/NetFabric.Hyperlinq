using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static WhereReadOnlyList<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();

            return new WhereReadOnlyList<TEnumerable, TEnumerator, TSource>(in source, predicate);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
        }

        public readonly struct WhereReadOnlyList<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, WhereReadOnlyList<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;

            internal WhereReadOnlyList(in TEnumerable source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal Enumerator(in WhereReadOnlyList<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public TSource Current => source[index];

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                        {
                            return true;
                        }

                        index++;
                    }
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereReadOnlyList<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public bool TryMoveNext(out TSource current)
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

                public bool TryMoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                        {
                            return true;
                        }

                        index++;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public int Count()
                => ValueEnumerable.Count<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public ReadOnlyList.WhereSelectReadOnlyList<TEnumerable,TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ReadOnlyList.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.WhereValueEnumerable<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueEnumerable.Where<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate)
                => ValueEnumerable.First<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate)
                => ValueEnumerable.Single<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
        }
    }
}

