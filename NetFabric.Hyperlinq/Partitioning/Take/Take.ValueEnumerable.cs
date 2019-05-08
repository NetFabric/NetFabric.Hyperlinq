using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static TakeEnumerable<TEnumerable, TEnumerator, TSource> Take<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long count)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new TakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, count);

        public readonly struct TakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly long count;

            internal TakeEnumerable(in TEnumerable source, long count)
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

                internal Enumerator(in TakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    counter = enumerable.count;
                }

                public TSource Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    if (counter > 0)
                    {
                        if (enumerator.MoveNext())
                        {
                            counter--;
                            return true;
                        }

                        counter = 0;
                    }

                    return false; 
                }

                public void Dispose() => enumerator.Dispose();
            }

            public long Count()
                => ValueEnumerable.Count<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public long Count(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Count<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public ValueEnumerable.SkipEnumerable<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Skip(long count)
                => ValueEnumerable.Skip<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, count);

            public TakeEnumerable<TEnumerable, TEnumerator, TSource> Take(long count)
                => ValueEnumerable.Take<TEnumerable, TEnumerator, TSource>(source, Math.Min(this.count, count));

            public bool All(Func<TSource, long, bool> predicate)
                => ValueEnumerable.All<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Any<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                 => ValueEnumerable.Select<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Where<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Single<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public TakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<TakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<TakeEnumerable<TEnumerable, TEnumerator, TSource>, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<TakeEnumerable<TEnumerable, TEnumerator, TSource>, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<TakeEnumerable<TEnumerable, TEnumerator, TSource>, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<TakeEnumerable<TEnumerable, TEnumerator, TSource>, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);
    }
}