using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;
            readonly int takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
                : IDisposable
            {
                TEnumerator enumerator;
                int skipCounter;
                int takeCounter;
                TSource current;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetValueEnumerator();
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.takeCount;
                    current = default;
                }

                public TSource Current => current;

                public bool MoveNext()
                {
                    while (skipCounter > 0)
                    {
                        if (!enumerator.TryMoveNext())
                        {
                            skipCounter = 0;
                            return false;
                        }

                        skipCounter--;
                    }

                    if (takeCounter > 0)
                    {
                        if (enumerator.TryMoveNext(out current))
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

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                int skipCounter;
                int takeCounter;

                internal ValueEnumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetValueEnumerator();
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.takeCount;
                }

                public bool TryMoveNext(out TSource current)
                {
                    while (skipCounter > 0)
                    {
                        if(!enumerator.TryMoveNext())
                        {
                            skipCounter = 0;
                            current = default;
                            return false;
                        }

                        skipCounter--;
                    }

                    if (takeCounter > 0)
                    {
                        if (enumerator.TryMoveNext(out current))
                        {
                            takeCounter--;
                            return true;
                        }

                        takeCounter = 0;
                    }

                    current = default;
                    return false; 
                }

                public bool TryMoveNext() 
                {
                    while (skipCounter > 0)
                    {
                        if (!enumerator.TryMoveNext())
                        {
                            skipCounter = 0;
                            return false;
                        }

                        skipCounter--;
                    }

                    if (takeCounter > 0)
                    {
                        if (enumerator.TryMoveNext())
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

            public int Count()
                => ValueEnumerable.Count<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public int Count(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Count<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public ValueEnumerable.SkipEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Skip(int count)
                => ValueEnumerable.Skip<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, count);

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => ValueEnumerable.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(takeCount, count));

            public bool All(Func<TSource, int, bool> predicate)
                => ValueEnumerable.All<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public bool Any(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Any<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, int, TResult> selector)
                 => ValueEnumerable.Select<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Where(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Where<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, int, bool> predicate)
                => ValueEnumerable.First<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Single<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}