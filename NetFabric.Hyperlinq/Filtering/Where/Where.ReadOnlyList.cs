using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static WhereEnumerable<TEnumerable, TSource> Where<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TSource>(in source, predicate);
        }

        public readonly struct WhereEnumerable<TEnumerable, TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TSource>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly Func<TSource, int, bool> predicate;

            internal WhereEnumerable(in TEnumerable source, Func<TSource, int, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
            {
                readonly TEnumerable source;
                readonly Func<TSource, int, bool> predicate;
                readonly int count;
                TSource current;
                int index;

                internal Enumerator(in WhereEnumerable<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count;
                    current = default;
                    index = -1;
                }

                public TSource Current => current;

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
                    current = default;
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly Func<TSource, int, bool> predicate;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereEnumerable<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public bool TryMoveNext(out TSource current)
                {
                    unchecked
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
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    unchecked
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

            public int Count()
                => ReadOnlyList.Count<TEnumerable, TSource>(source, predicate);

            public int Count(Func<TSource, long, bool> predicate)
                => (int)ValueEnumerable.Count<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public ValueEnumerable.SkipEnumerable<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource> Skip(int count)
                => ValueEnumerable.Skip<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, count);

            public ValueEnumerable.TakeEnumerable<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource> Take(int count)
                => ValueEnumerable.Take<WhereEnumerable<TEnumerable,  TSource>, ValueEnumerator, TSource>(this, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueEnumerable.All<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => ReadOnlyList.Any<TEnumerable, TSource>(source, predicate);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Any<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public ReadOnlyList.WhereSelectEnumerable<TEnumerable, TSource, TResult> Select<TResult>(Func<TSource, int, TResult> selector)
                => ReadOnlyList.WhereSelect<TEnumerable, TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.SelectManyEnumerable<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueEnumerable.SelectMany<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public ReadOnlyList.WhereEnumerable<TEnumerable, TSource> Where(Func<TSource, int, bool> predicate)
            {
                var currentPredicate = this.predicate;
                return ReadOnlyList.Where<TEnumerable, TSource>(source, CombinedPredicates);

                bool CombinedPredicates(TSource item, int index) 
                    => currentPredicate(item, index) && predicate(item, index);
            }

            public TSource First()
                => ReadOnlyList.First<TEnumerable, TSource>(source, predicate);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ReadOnlyList.FirstOrDefault<TEnumerable, TSource>(source, predicate);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ReadOnlyList.Single<TEnumerable, TSource>(source, predicate);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Single<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ReadOnlyList.SingleOrDefault<TEnumerable, TSource>(source, predicate);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);

            public WhereEnumerable<TEnumerable, TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerable, TSource>(this WhereEnumerable<TEnumerable, TSource> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => ReadOnlyList.FirstOrNull<TEnumerable, TSource>(source.source, source.predicate);

        public static TSource? FirstOrNull<TEnumerable, TSource>(this WhereEnumerable<TEnumerable, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<WhereEnumerable<TEnumerable, TSource>, WhereEnumerable<TEnumerable, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TSource>(this WhereEnumerable<TEnumerable,TSource> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => ReadOnlyList.SingleOrNull<TEnumerable, TSource>(source.source, source.predicate);

        public static TSource? SingleOrNull<TEnumerable, TSource>(this WhereEnumerable<TEnumerable, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<WhereEnumerable<TEnumerable, TSource>, WhereEnumerable<TEnumerable, TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}

