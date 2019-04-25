using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new SkipEnumerable<TEnumerable, TEnumerator, TSource>(in source, count);

        public readonly struct SkipEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal SkipEnumerable(in TEnumerable source, int count)
            {
                this.source = source;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
                : IDisposable
            {
                TEnumerator enumerator;
                int counter;

                internal Enumerator(in SkipEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    counter = enumerable.count;
                }

                public TSource Current => enumerator.Current;

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

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                int counter;

                internal ValueEnumerator(in SkipEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    counter = enumerable.count;
                }

                public bool TryMoveNext(out TSource current)
                {
                    while (counter > 0)
                    {
                        if(!enumerator.MoveNext())
                        {
                            counter = 0;
                            current = default;
                            return false;
                        }

                        counter--;
                    }

                    if (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        return true;
                    }

                    current = default;
                    return false;                    
                }

                public bool TryMoveNext() 
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

            public int Count()
                => (int)ValueEnumerable.Count<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public int Count(Func<TSource, long, bool> predicate)
                => (int)ValueEnumerable.Count<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public SkipEnumerable<TEnumerable, TEnumerator, TSource> Skip(int count)
                => Enumerable.Skip<TEnumerable, TEnumerator, TSource>(source, this.count + count);

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => Enumerable.SkipTake<TEnumerable, TEnumerator, TSource>(source, this.count, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueEnumerable.All<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Any<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                 => ValueEnumerable.Select<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Where<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Single<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public SkipEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<SkipEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipEnumerable<TEnumerable, TEnumerator, TSource>, SkipEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipEnumerable<TEnumerable, TEnumerator, TSource>, SkipEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<SkipEnumerable<TEnumerable, TEnumerator, TSource>, SkipEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<SkipEnumerable<TEnumerable, TEnumerator, TSource>, SkipEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}