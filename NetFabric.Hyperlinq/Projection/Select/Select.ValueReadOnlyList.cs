using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, long, TResult> selector)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
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

            public TResult this[long index] => selector(source[index], index);

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, long, TResult> selector;
                readonly long count;
                long index;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public TResult Current
                    => selector(source[index], index);

                public bool MoveNext()
                    => ++index < count;

                public void Dispose() { }
            }

            public ValueReadOnlyCollection.SkipTakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult> Skip(long count)
                => ValueReadOnlyCollection.Skip<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, count);

            public ValueReadOnlyCollection.SkipTakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult> Take(long count)
                => ValueReadOnlyCollection.Take<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, count);

            public bool All(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.All<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Any()
                => source.Count != 0;

            public bool Any(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Any<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyList.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyList.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, value, comparer);

            public ValueReadOnlyList.SelectEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
            {
                var currentSelector = this.selector;
                return ValueReadOnlyList.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, CombinedSelectors);

                TSelectorResult CombinedSelectors(TSource item, long index) 
                    => selector(currentSelector(item, index), index);
            }

            public ValueReadOnlyList.WhereEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult> Where(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Where<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult First()
                => selector(ValueReadOnlyList.First<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult First(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.First<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(ValueReadOnlyList.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult FirstOrDefault(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(ValueReadOnlyList.Single<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult Single(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(ValueReadOnlyList.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source), 0);
            public TResult SingleOrDefault(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this, predicate);

            public IReadOnlyList<TResult> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyList.ToArray<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, Enumerator, TResult>(this);
        }

        public static long Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        public static long Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => ValueReadOnlyList.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);
    }
}

