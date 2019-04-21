using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

        public readonly struct WhereEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
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

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count;
                    current = default;
                    index = -1;
                }

                public TSource Current => source[index];

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

                internal ValueEnumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public bool TryMoveNext(out TSource current)
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

            public int Count()
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, predicate);

            public int Count(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Count<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public ValueEnumerable.SkipEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Skip(int count)
                => ValueEnumerable.Skip<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, count);

            public ValueEnumerable.TakeEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Take(int count)
                => ValueEnumerable.Take<WhereEnumerable<TEnumerable,  TEnumerator, TSource>, ValueEnumerator, TSource>(this, count);

            public bool All(Func<TSource, int, bool> predicate)
                => ValueEnumerable.All<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, predicate);

            public bool Any(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Any<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public ValueReadOnlyList.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, int, TResult> selector)
                => ValueReadOnlyList.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.SelectManyEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueEnumerable.SelectMany<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Where(Func<TSource, int, bool> predicate)
            {
                var currentPredicate = this.predicate;
                return ValueEnumerable.Where<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, CombinedPredicates);

                bool CombinedPredicates(TSource item, int index) 
                    => currentPredicate(item, index) && predicate(item, index);
            }

            public TSource First()
                => ValueReadOnlyList.First<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource First(Func<TSource, int, bool> predicate)
                => ValueEnumerable.First<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueReadOnlyList.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueReadOnlyList.Single<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource Single(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Single<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueReadOnlyList.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public WhereEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyList.FirstOrNull<TEnumerable, TEnumerator, TSource>(source.source, source.predicate);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<WhereEnumerable<TEnumerable, TEnumerator, TSource>, WhereEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyList.SingleOrNull<TEnumerable, TEnumerator, TSource>(source.source, source.predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<WhereEnumerable<TEnumerable, TEnumerator, TSource>, WhereEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}

