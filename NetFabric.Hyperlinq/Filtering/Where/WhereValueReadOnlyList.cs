using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();

            return new WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>(in source, predicate);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
        }

        public readonly struct WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;

            internal WhereValueReadOnlyList(in TEnumerable source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
                : IDisposable
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                TSource current;
                int index;

                internal Enumerator(in WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count();
                    current = default;
                    index = -1;
                }

                public TSource Current => current;

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

                public void Dispose() { }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count();
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
                => ValueEnumerable.Count<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public ValueEnumerable.SelectValueEnumerable<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ValueEnumerable.Select<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereValueEnumerable<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueEnumerable.Where<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate)
                => ValueEnumerable.First<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate)
                => ValueEnumerable.Single<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> ToEnumerable()
                => ValueEnumerable.ToEnumerable<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereValueReadOnlyList<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
        }
    }
}

