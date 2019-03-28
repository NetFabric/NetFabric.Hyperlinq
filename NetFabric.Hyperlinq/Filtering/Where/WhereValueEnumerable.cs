using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

        public readonly struct WhereEnumerable<TEnumerable, TEnumerator, TSource> 
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly Func<TSource, bool> predicate;

            internal WhereEnumerable(in TEnumerable source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator 
                : IDisposable
            {
                TEnumerator enumerator;
                readonly Func<TSource, bool> predicate;
                TSource current;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetValueEnumerator();
                    predicate = enumerable.predicate;
                    current = default;
                }

                public TSource Current => current;

                public bool MoveNext()
                {
                    while (enumerator.TryMoveNext(out current))
                    {
                        if (predicate(current))
                            return true;
                    }
                    return false;
                }

                public void Dispose() => enumerator.Dispose();
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                readonly Func<TSource, bool> predicate;

                internal ValueEnumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetValueEnumerator();
                    predicate = enumerable.predicate;
                }

                public bool TryMoveNext(out TSource current)
                {
                    while (enumerator.TryMoveNext(out current))
                    {
                        if (predicate(current))
                            return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                        if (predicate(current))
                            return true;
                    }
                    return false;
                }

                public void Dispose() => enumerator.Dispose();
            }

            public int Count()
                => ValueEnumerable.Count<TEnumerable, TEnumerator, TSource>(source, predicate);

            public int Count(Func<TSource, bool> predicate)
                => ValueEnumerable.Count<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool All(Func<TSource, bool> predicate)
                => ValueEnumerable.All<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<TEnumerable, TEnumerator, TSource>(source, predicate);

            public bool Any(Func<TSource, bool> predicate)
                => ValueEnumerable.Any<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public ValueEnumerable.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ValueEnumerable.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.SelectManyEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueEnumerable.SelectMany<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueEnumerable.Where<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource First(Func<TSource, bool> predicate)
                => ValueEnumerable.First<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource Single(Func<TSource, bool> predicate)
                => ValueEnumerable.Single<WhereEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate);
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
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
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<TEnumerable, TEnumerator, TSource>(source.source, source.predicate);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<WhereEnumerable<TEnumerable, TEnumerator, TSource>, WhereEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<TEnumerable, TEnumerator, TSource>(source.source, source.predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this WhereEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueEnumerable.SingleOrNull<WhereEnumerable<TEnumerable, TEnumerator, TSource>, WhereEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}

