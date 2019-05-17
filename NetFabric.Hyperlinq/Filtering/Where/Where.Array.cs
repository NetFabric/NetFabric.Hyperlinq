using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, long, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate);
        }

        public readonly struct WhereEnumerable<TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TSource>.Enumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, long, bool> predicate;

            internal WhereEnumerable(TSource[] source, Func<TSource, long, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator 
                : IValueEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, long, bool> predicate;
                readonly int count;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public ref TSource Current => ref source[index];
                TSource IValueEnumerator<TSource>.Current => source[index];

                public bool MoveNext()
                {
                    while (++index < count)
                    {
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public long Count()
                => source.Count(predicate);
            public long Count(Func<TSource, bool> predicate)
                => ValueEnumerable.Count<WhereEnumerable<TSource>, Enumerator, TSource>(this, predicate);
            public long Count(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Count<WhereEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public ValueEnumerable.SkipEnumerable<WhereEnumerable<TSource>, Enumerator, TSource> Skip(int count)
                => ValueEnumerable.Skip<WhereEnumerable<TSource>, Enumerator, TSource>(this, count);

            public ValueEnumerable.TakeEnumerable<WhereEnumerable<TSource>, Enumerator, TSource> Take(int count)
                => ValueEnumerable.Take<WhereEnumerable<TSource>, Enumerator, TSource>(this, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueEnumerable.All<WhereEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public bool Any()
                => source.Any<TSource>(predicate);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Any<WhereEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<WhereEnumerable<TSource>, Enumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<WhereEnumerable<TSource>, Enumerator, TSource>(this, value, comparer);

            public Array.WhereSelectEnumerable<TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                => Array.WhereSelect<TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.SelectManyEnumerable<WhereEnumerable<TSource>, Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueEnumerable.SelectMany<WhereEnumerable<TSource>, Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public Array.WhereEnumerable<TSource> Where(Func<TSource, long, bool> predicate)
            {
                var currentPredicate = this.predicate;
                return Array.Where<TSource>(source, CombinedPredicates());

                Func<TSource, long, bool> CombinedPredicates() 
                    => (item, index) => currentPredicate(item, index) && predicate(item, index);
            }

            public ref TSource First()
                => ref Array.First<TSource>(source, predicate);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<WhereEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, predicate);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public ref  TSource Single()
                => ref Array.Single<TSource>(source, predicate);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Single<WhereEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault<TSource>(source, predicate);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereEnumerable<TSource>, Enumerator, TSource>(this);

            public WhereEnumerable<TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereEnumerable<TSource>, Enumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereEnumerable<TSource>, Enumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TSource>(this WhereEnumerable<TSource> source)
            where TSource : struct
            => Array.FirstOrNull<TSource>(source.source, source.predicate);

        public static TSource? FirstOrNull<TSource>(this WhereEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ValueEnumerable.FirstOrNull<WhereEnumerable<TSource>, WhereEnumerable<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this WhereEnumerable<TSource> source)
            where TSource : struct
            => Array.SingleOrNull<TSource>(source.source, source.predicate);

        public static TSource? SingleOrNull<TSource>(this WhereEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ValueEnumerable.SingleOrNull<WhereEnumerable<TSource>, WhereEnumerable<TSource>.Enumerator, TSource>(source, predicate);
    }
}

