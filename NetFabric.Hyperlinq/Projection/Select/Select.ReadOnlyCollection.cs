using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, int, TResult> selector)
            where TEnumerable : IReadOnlyCollection<TSource> 
            where TEnumerator : IEnumerator<TSource> 
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyCollection<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
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

            public int Count => source.Count;

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

            public ValueReadOnlyCollection.SkipTakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Skip(int count)
                => ValueReadOnlyCollection.Skip<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public ValueReadOnlyCollection.SkipTakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Take(int count)
                => ValueReadOnlyCollection.Take<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public bool All(Func<TResult, int, bool> predicate)
                => ValueReadOnlyCollection.All<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => source.Count != 0;

            public bool Any(Func<TResult, int, bool> predicate)
                => ValueReadOnlyCollection.Any<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyCollection.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyCollection.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ReadOnlyCollection.SelectEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, int, TSelectorResult> selector)
            {
                var currentSelector = this.selector;
                return ReadOnlyCollection.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, CombinedSelectors);

                TSelectorResult CombinedSelectors(TSource item, int index) 
                    => selector(currentSelector(item, index), index);
            }

            public ValueEnumerable.WhereEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, int, bool> predicate)
                => ValueEnumerable.Where<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => selector(ReadOnlyCollection.First<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult First(Func<TResult, int, bool> predicate)
                => ValueReadOnlyCollection.First<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(ReadOnlyCollection.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult FirstOrDefault(Func<TResult, int, bool> predicate)
                => ValueReadOnlyCollection.FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(ReadOnlyCollection.Single<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult Single(Func<TResult, int, bool> predicate)
                => ValueReadOnlyCollection.Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(ReadOnlyCollection.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult SingleOrDefault(Func<TResult, int, bool> predicate)
                => ValueReadOnlyCollection.SingleOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IReadOnlyCollection<TResult> AsEnumerable()
                => ValueReadOnlyCollection.AsEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyCollection.ToArray<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }

        public static int Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => ValueReadOnlyCollection.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static int Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, int, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => ValueReadOnlyCollection.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyCollection.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, int, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyCollection.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, int, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyCollection.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}
