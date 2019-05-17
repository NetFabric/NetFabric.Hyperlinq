using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long skipCount, long takeCount)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly long skipCount;
            readonly long takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, long skipCount, long takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                long skipCounter;
                long takeCounter;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.takeCount;
                }

                public TSource Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    while (skipCounter > 0)
                    {
                        if(!enumerator.MoveNext())
                        {
                            skipCounter = 0;
                            return false;
                        }

                        skipCounter--;
                    }

                    if (takeCounter > 0)
                    {
                        if (enumerator.MoveNext())
                        {
                            takeCounter--;
                            return true;
                        }

                        takeCounter = 0;
                    }

                    return false; 
                }

                public void Dispose() => enumerator.Dispose();
            }

            public long Count()
                => ValueEnumerable.Count<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public long Count(Func<TSource, bool> predicate)
                => ValueEnumerable.Count<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);
            public long Count(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Count<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public ValueEnumerable.SkipEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Skip(long count)
                => ValueEnumerable.Skip<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, count);

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(long count)
                => ValueEnumerable.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(takeCount, count));

            public bool All(Func<TSource, long, bool> predicate)
                => ValueEnumerable.All<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Any<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                 => ValueEnumerable.Select<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Where<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Single<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);
    }
}