using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long count)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new SkipEnumerable<TEnumerable, TEnumerator, TSource>(in source, count);

        public readonly struct SkipEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly long count;

            internal SkipEnumerable(in TEnumerable source, long count)
            {
                this.source = source;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                long counter;

                internal Enumerator(in SkipEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    counter = enumerable.count;
                }

                public TSource Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    while (counter > 0)
                    {
                        if (!enumerator.MoveNext())
                        {
                            counter = 0;
                            return false;
                        }

                        counter--;
                    }

                    return enumerator.MoveNext();                    
                }

                public void Dispose() => enumerator.Dispose();
            }

            public long Count()
                => ValueEnumerable.Count<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public long Count(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Count<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip(long count)
                => Enumerable.Skip<TEnumerable, TEnumerator, TSource>(source, this.count + count);

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(long count)
                => Enumerable.SkipTake<TEnumerable, TEnumerator, TSource>(source, this.count, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueEnumerable.All<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Any<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                 => ValueEnumerable.Select<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Where<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Single<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public SkipEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<SkipEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipEnumerable<TEnumerable, TEnumerator, TSource>, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipEnumerable<TEnumerable, TEnumerator, TSource>, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<SkipEnumerable<TEnumerable, TEnumerator, TSource>, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<SkipEnumerable<TEnumerable, TEnumerator, TSource>, SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);
    }
}