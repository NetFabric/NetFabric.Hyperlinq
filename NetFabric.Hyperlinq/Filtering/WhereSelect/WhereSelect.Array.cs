using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        internal static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, long, bool> predicate, 
            Func<TSource, long, TResult> selector) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector);
        }

        public readonly struct WhereSelectEnumerable<TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TSource, TResult>.Enumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, long, bool> predicate;
            readonly Func<TSource, long, TResult> selector;

            internal WhereSelectEnumerable(TSource[] source, Func<TSource, long, bool> predicate, Func<TSource, long, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, long, bool> predicate;
                readonly Func<TSource, long, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public TResult Current
                    => selector(source[index], index);

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
            public long Count(Func<TResult, bool> predicate)
                => ValueEnumerable.Count<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);
            public long Count(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Count<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public ValueEnumerable.SkipEnumerable<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult> Skip(int count)
                => ValueEnumerable.Skip<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, count);

            public ValueEnumerable.TakeEnumerable<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult> Take(int count)
                => ValueEnumerable.Take<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, count);

            public bool All(Func<TResult, long, bool> predicate)
                => ValueEnumerable.All<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);

            public bool Any(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Any<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueEnumerable.Contains<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueEnumerable.Contains<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
                => ValueEnumerable.Select<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult> Where(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Where<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);
            public TResult First(Func<TResult, long, bool> predicate)
                => ValueEnumerable.First<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);
            public TResult Single(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Single<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);

            public WhereSelectEnumerable<TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<WhereSelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);
        }

        public static TResult? FirstOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueEnumerable.FirstOrNull<WhereSelectEnumerable<TSource, TResult>, WhereSelectEnumerable<TSource, TResult>.Enumerator, TResult>(source);

        public static TResult? FirstOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TResult : struct
            => ValueEnumerable.FirstOrNull<WhereSelectEnumerable<TSource, TResult>, WhereSelectEnumerable<TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueEnumerable.SingleOrNull<WhereSelectEnumerable<TSource, TResult>, WhereSelectEnumerable<TSource, TResult>.Enumerator, TResult>(source);

        public static TResult? SingleOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TResult : struct
            => ValueEnumerable.SingleOrNull<WhereSelectEnumerable<TSource, TResult>, WhereSelectEnumerable<TSource, TResult>.Enumerator, TResult>(source, predicate);
    }
}

