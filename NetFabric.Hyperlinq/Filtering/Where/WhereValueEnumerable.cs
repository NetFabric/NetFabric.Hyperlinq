using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static WhereValueEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (predicate is null) ThrowPredicateNull();

            return new WhereValueEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
        }

        public readonly struct WhereValueEnumerable<TEnumerable, TEnumerator, TSource> 
            : IValueEnumerable<TSource, WhereValueEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;

            internal WhereValueEnumerable(in TEnumerable source, Func<TSource, bool> predicate)
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

                internal Enumerator(in WhereValueEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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

                internal ValueEnumerator(in WhereValueEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
                => ValueEnumerable.Count<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public ValueEnumerable.SelectValueEnumerable<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ValueEnumerable.Select<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereValueEnumerable<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueEnumerable.Where<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ValueEnumerable.First<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, bool> predicate)
                => ValueEnumerable.First<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueEnumerable.Single<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, bool> predicate)
                => ValueEnumerable.Single<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> ToEnumerable()
                => ValueEnumerable.ToEnumerable<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereValueEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
        }
    }
}

