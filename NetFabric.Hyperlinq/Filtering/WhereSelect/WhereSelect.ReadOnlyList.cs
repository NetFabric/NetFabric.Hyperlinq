using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        internal static WhereSelectEnumerable<TEnumerable, TSource, TResult> WhereSelect<TEnumerable, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, long, bool> predicate,
            Func<TSource, long, TResult> selector) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TEnumerable, TSource, TResult>(in source, predicate, selector);
        }

        public readonly struct WhereSelectEnumerable<TEnumerable, TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, long, bool> predicate;
            readonly Func<TSource, long, TResult> selector;

            internal WhereSelectEnumerable(in TEnumerable source, Func<TSource, long, bool> predicate, Func<TSource, long, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
            {
                readonly TEnumerable source;
                readonly Func<TSource, long, bool> predicate;
                readonly Func<TSource, long, TResult> selector;
                readonly int count;
                TSource current;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    current = default;
                    index = -1;
                }

                public TResult Current => selector(current, index);

                public bool MoveNext()
                {
                    unchecked // always less than count
                    {
                        index++;
                        while (index < count)
                        {
                            current = source[index];
                            if (predicate(current, index))
                                return true;

                            index++;
                        }
                    }
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, long, bool> predicate;
                readonly Func<TSource, long, TResult> selector;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereSelectEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public bool TryMoveNext(out TResult current)
                {
                    unchecked // always less than count
                    {
                        index++;
                        while (index < count)
                        {
                            if (predicate(source[index], index))
                            {
                                current = selector(source[index], index);
                                return true;
                            }

                            index++;
                        }
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    unchecked // always less than count
                    {
                        index++;
                        while (index < count)
                        {
                            if (predicate(source[index], index))
                                return true;

                            index++;
                        }
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public long Count()
                => ReadOnlyList.Count<TEnumerable, TSource>(source, predicate);

            public long Count(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Count<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public ValueEnumerable.SkipEnumerable<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult> Skip(int count)
                => ValueEnumerable.Skip<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public ValueEnumerable.TakeEnumerable<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult> Take(int count)
                => ValueEnumerable.Take<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public bool All(Func<TResult, long, bool> predicate)
                => ValueEnumerable.All<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => ReadOnlyList.Any<TEnumerable, TSource>(source, predicate);

            public bool Any(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Any<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueEnumerable.Contains<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueEnumerable.Contains<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
                => ValueEnumerable.Select<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Where<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, long, bool> predicate)
                => ValueEnumerable.First<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Single<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public WhereSelectEnumerable<TEnumerable, TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<WhereSelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
        }

        public static TResult? FirstOrNull<TEnumerable, TSource, TResult>(this WhereSelectEnumerable<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<WhereSelectEnumerable<TEnumerable, TSource, TResult>, WhereSelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TSource, TResult>(this WhereSelectEnumerable<TEnumerable, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<WhereSelectEnumerable<TEnumerable, TSource, TResult>, WhereSelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TSource, TResult>(this WhereSelectEnumerable<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<WhereSelectEnumerable<TEnumerable, TSource, TResult>, WhereSelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TSource, TResult>(this WhereSelectEnumerable<TEnumerable, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<WhereSelectEnumerable<TEnumerable, TSource, TResult>, WhereSelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}

