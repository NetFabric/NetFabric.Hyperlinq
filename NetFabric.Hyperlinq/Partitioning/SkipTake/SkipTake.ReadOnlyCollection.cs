using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;
            readonly int takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public int Count => takeCount;
            long IValueReadOnlyCollection<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>.Count => takeCount;

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                EnumeratorState state;
                TEnumerator enumerator;
                int skipCounter;
                int takeCounter;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.takeCount;
                    enumerator = default;
                    state = takeCounter > 0 ? EnumeratorState.Uninitialized : EnumeratorState.Complete;
                }

                public TSource Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case EnumeratorState.Uninitialized:
                            enumerator = (TEnumerator)source.GetEnumerator();
                            while (skipCounter > 0)
                            {
                                if (enumerator.MoveNext())
                                {
                                    skipCounter--;
                                }
                                else
                                {
                                    state = EnumeratorState.Complete;
                                    goto case EnumeratorState.Complete;
                                }
                            }                
                            state = EnumeratorState.Enumerating;
                            goto case EnumeratorState.Enumerating;
                            
                        case EnumeratorState.Enumerating:
                            if (enumerator.MoveNext())
                            {
                                takeCounter--;
                                if (takeCounter == 0)
                                    state = EnumeratorState.Complete;

                                return true;
                            }
                            state = EnumeratorState.Complete;
                            goto case EnumeratorState.Complete;

                        case EnumeratorState.Complete:
                        default:
                            return false;
                    }
                }

                public void Dispose() => enumerator?.Dispose();
            }

            public ValueReadOnlyCollection.SkipTakeEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Skip(int count)
                => ValueReadOnlyCollection.Skip<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, count);

            public ValueReadOnlyCollection.SkipTakeEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Take(int count)
                => ValueReadOnlyCollection.Take<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueReadOnlyCollection.All<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Any()
                => ValueReadOnlyCollection.Any<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueReadOnlyCollection.Any<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueReadOnlyCollection.Contains<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueReadOnlyCollection.Contains<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value, comparer);

            public ValueReadOnlyCollection.SelectEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                 => ValueReadOnlyCollection.Select<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Where<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource First()
                => ValueReadOnlyCollection.First<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueReadOnlyCollection.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueReadOnlyCollection.Single<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueReadOnlyCollection.Single<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueReadOnlyCollection.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueReadOnlyCollection.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public IReadOnlyCollection<TSource> AsEnumerable()
                => ValueReadOnlyCollection.AsEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueReadOnlyCollection()
                => this;

            public TSource[] ToArray()
                => ValueReadOnlyCollection.ToArray<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
        }

        public static long Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => source.Count;
        public static long Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => ValueReadOnlyCollection.Count<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);
        public static long Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => ValueReadOnlyCollection.Count<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyCollection.FirstOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyCollection.SingleOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyCollection.SingleOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);
    }
}