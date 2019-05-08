using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, long, TResult> selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyCollection<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, long, TResult> selector;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, long, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
 
            public long Count => source.Count;

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                TEnumerator enumerator;
                readonly Func<TSource, long, TResult> selector;
                long index;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    index = -1;
                }

                public TResult Current
                    => selector(enumerator.Current, index);

                public bool MoveNext()
                {
                    if (enumerator.MoveNext())
                    {
                        index++; 
                        return true;
                    }
                    index = -1;
                    return false;
                }             

                public void Dispose() => enumerator.Dispose();
            }

            public ValueReadOnlyCollection.SkipTakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult> Skip(long count)
                => ValueReadOnlyCollection.Skip<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, count);

            public ValueReadOnlyCollection.SkipTakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult> Take(long count)
                => ValueReadOnlyCollection.Take<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, count);

            public bool All(Func<TResult, long, bool> predicate)
                => ValueReadOnlyCollection.All<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Any()
                => source.Count != 0;

            public bool Any(Func<TResult, long, bool> predicate)
                => ValueReadOnlyCollection.Any<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyCollection.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyCollection.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, value, comparer);

            public ValueReadOnlyCollection.SelectEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
            {
                var currentSelector = this.selector;
                return ValueReadOnlyCollection.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, CombinedSelectors);

                TSelectorResult CombinedSelectors(TSource item, long index) 
                    => selector(currentSelector(item, index), index);
            }

            public ValueEnumerable.WhereEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult> Where(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Where<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult First()
                => selector(ValueReadOnlyCollection.First<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult First(Func<TResult, long, bool> predicate)
                => ValueEnumerable.First<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(ValueReadOnlyCollection.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult FirstOrDefault(Func<TResult, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(ValueReadOnlyCollection.Single<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult Single(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(ValueReadOnlyCollection.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult SingleOrDefault(Func<TResult, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public IReadOnlyCollection<TResult> AsEnumerable()
                => ValueReadOnlyCollection.AsEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyCollection.ToArray<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);
        }

        public static long Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        public static long Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => ValueReadOnlyCollection.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyCollection.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyCollection.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyCollection.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyCollection.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);
    }
}

