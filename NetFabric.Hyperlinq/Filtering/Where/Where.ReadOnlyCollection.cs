using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

        public readonly struct WhereEnumerable<TEnumerable, TEnumerator, TSource> 
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly Func<TSource, long, bool> predicate;

            internal WhereEnumerable(in TEnumerable source, Func<TSource, long, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            
            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                readonly Func<TSource, long, bool> predicate;
                int index;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = 0;
                }

                public TSource Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    checked
                    {
                        while (enumerator.MoveNext())
                        {
                            if (predicate(enumerator.Current, index))
                                return true;

                            index++;
                        }
                    }
                    return false;
                }

                public void Dispose() => enumerator.Dispose(); 
            }

            public long Count()
                => ReadOnlyCollection.Count<TEnumerable, TEnumerator, TSource>(source, predicate);

            public long Count(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Count<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public ValueEnumerable.SkipEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Skip(int count)
                => ValueEnumerable.Skip<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, count);

            public ValueEnumerable.TakeEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource> Take(int count)
                => ValueEnumerable.Take<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueEnumerable.All<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Any()
                => ReadOnlyCollection.Any<TEnumerable, TEnumerator, TSource>(source, predicate);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Any<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, value, comparer);

            public ReadOnlyCollection.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                => ReadOnlyCollection.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.SelectManyEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueEnumerable.SelectMany<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public ReadOnlyCollection.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, long, bool> predicate)
            {
                var currentPredicate = this.predicate;
                return ReadOnlyCollection.Where<TEnumerable, TEnumerator, TSource>(source, CombinedPredicates);

                bool CombinedPredicates(TSource item, long index) 
                    => currentPredicate(item, index) && predicate(item, index);
            }

            public TSource First()
                => ReadOnlyCollection.First<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ReadOnlyCollection.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single()
                => ReadOnlyCollection.Single<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Single<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ReadOnlyCollection.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public WhereEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereEnumerable<TEnumerable, TEnumerator, TSource>, Enumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<TEnumerable, TEnumerator, TSource>(source.source, source.predicate);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<WhereEnumerable<TEnumerable, TEnumerator, TSource>, WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<TEnumerable, TEnumerator, TSource>(source.source, source.predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<WhereEnumerable<TEnumerable, TEnumerator, TSource>, WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator, TSource>(source, predicate);
    }
}
