using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, int, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate);
        }

        public readonly struct WhereEnumerable<TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TSource>.ValueEnumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, int, bool> predicate;

            internal WhereEnumerable(TSource[] source, Func<TSource, int, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator 
            {
                readonly TSource[] source;
                readonly Func<TSource, int, bool> predicate;
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

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index], index))
                            return true;

                        index++;
                    }
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, int, bool> predicate;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public bool TryMoveNext(out TSource current)
                {
                    index++;
                    while (index < count)
                    {
                        current = source[index];
                        if (predicate(current, index))
                            return true;

                        index++;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index], index))
                            return true;

                        index++;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public int Count()
                => source.Count(predicate);

            public int Count(Func<TSource, long, bool> predicate)
                => (int)ValueEnumerable.Count<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ValueEnumerable.SkipEnumerable<WhereEnumerable<TSource>, ValueEnumerator, TSource> Skip(int count)
                => ValueEnumerable.Skip<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, count);

            public ValueEnumerable.TakeEnumerable<WhereEnumerable<TSource>, ValueEnumerator, TSource> Take(int count)
                => ValueEnumerable.Take<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueEnumerable.All<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => source.Any<TSource>(predicate);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Any<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public Array.WhereSelectEnumerable<TSource, TResult> Select<TResult>(Func<TSource, int, TResult> selector)
                => Array.WhereSelect<TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.SelectManyEnumerable<WhereEnumerable<TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueEnumerable.SelectMany<WhereEnumerable<TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public Array.WhereEnumerable<TSource> Where(Func<TSource, int, bool> predicate)
            {
                var currentPredicate = this.predicate;
                return Array.Where<TSource>(source, CombinedPredicates());

                Func<TSource, int, bool> CombinedPredicates() 
                    => (item, index) => currentPredicate(item, index) && predicate(item, index);
            }

            public ref TSource First()
                => ref Array.First<TSource>(source, predicate);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, predicate);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ref  TSource Single()
                => ref Array.Single<TSource>(source, predicate);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Single<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault<TSource>(source, predicate);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public WhereEnumerable<TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TSource>(this WhereEnumerable<TSource> source)
            where TSource : struct
            => Array.FirstOrNull<TSource>(source.source, source.predicate);

        public static TSource? FirstOrNull<TSource>(this WhereEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ValueEnumerable.FirstOrNull<WhereEnumerable<TSource>, WhereEnumerable<TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this WhereEnumerable<TSource> source)
            where TSource : struct
            => Array.SingleOrNull<TSource>(source.source, source.predicate);

        public static TSource? SingleOrNull<TSource>(this WhereEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ValueEnumerable.SingleOrNull<WhereEnumerable<TSource>, WhereEnumerable<TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}

