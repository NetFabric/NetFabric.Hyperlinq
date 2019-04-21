using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, int, TResult> selector)
            where TEnumerable : IEnumerable<TSource> 
            where TEnumerator : IEnumerator<TSource> 
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueEnumerable<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, int, TResult> selector;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, int, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
                : IDisposable
            {
                TEnumerator enumerator;
                readonly Func<TSource, int, TResult> selector;
                int index;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    index = -1;
                }

                public TResult Current => selector(enumerator.Current, index);

                public bool MoveNext() 
                {
                    if (enumerator.MoveNext())
                    {
                        checked { index++; }
                        return true;
                    }
                    index = -1;
                    return false;
                }

                public void Dispose() => enumerator.Dispose();
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, int, TResult> selector;
                int index;

                internal ValueEnumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    index = -1;
                }

                public bool TryMoveNext(out TResult current)
                {
                    if (enumerator.MoveNext())
                    {
                        checked { index++; }
                        current = selector(enumerator.Current, index);
                        return true;
                    }
                    current = default;
                    index = -1;
                    return false;
                }

                public bool TryMoveNext() 
                {
                    if (enumerator.MoveNext())
                    {
                        checked { index++; }
                        return true;
                    }
                    index = -1;
                    return false;
                }

                public void Dispose() => enumerator.Dispose();
            }

            public int Count()
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source);

            public int Count(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public ValueEnumerable.SkipEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Skip(int count)
                => ValueEnumerable.Skip<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public ValueEnumerable.TakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Take(int count)
                => ValueEnumerable.Take<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public bool All(Func<TResult, int, bool> predicate)
                => ValueEnumerable.All<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source);

            public bool Any(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Any<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueEnumerable.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueEnumerable.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public Enumerable.SelectEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, int, TSelectorResult> selector)
            {
                var currentSelector = this.selector;
                return Enumerable.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, CombinedSelectors);

                TSelectorResult CombinedSelectors(TSource item, int index) 
                    => selector(currentSelector(item, index), index);
            }

            public ValueEnumerable.WhereEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Where<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => selector(Enumerable.First<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult First(Func<TResult, int, bool> predicate)
                => ValueEnumerable.First<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(Enumerable.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult FirstOrDefault(Func<TResult, int, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(Enumerable.Single<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult Single(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(Enumerable.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult SingleOrDefault(Func<TResult, int, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, int, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, int, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}
