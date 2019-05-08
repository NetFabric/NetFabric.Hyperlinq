using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, long, TResult> selector)
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TSource, TResult>(source, selector);
        }

        public readonly struct SelectEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TSource, TResult>.Enumerator>
        {
            readonly TSource[] source;
            readonly Func<TSource, long, TResult> selector;

            internal SelectEnumerable(TSource[] source, Func<TSource, long, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public int Count => source.Length;
            long IValueReadOnlyCollection<TResult, Enumerator>.Count => source.Length;

            public TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= source.Length)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return selector(source[index], index);
                }
            }

            TResult IValueReadOnlyList<TResult, Enumerator>.this[long index]
            {
                get
                {
                    if (index > int.MaxValue)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return this[(int)index];
                }
            }

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, long, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in SelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public TResult Current
                    => selector(source[index], index);

                public bool MoveNext()
                    => ++index < count;

                public void Dispose() { }
            }

            public ValueReadOnlyList.SkipTakeEnumerable<SelectEnumerable<TSource, TResult>, Enumerator, TResult> Skip(int count)
                => ValueReadOnlyList.Skip<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, count);

            public ValueReadOnlyList.SkipTakeEnumerable<SelectEnumerable<TSource, TResult>, Enumerator, TResult> Take(int count)
                => ValueReadOnlyList.Take<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, count);

            public bool All(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.All<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Any()
                => source.Length != 0;

            public bool Any(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Any<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyList.Contains<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyList.Contains<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, value, comparer);

            public Array.SelectEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
            {
                var currentSelector = this.selector;
                return Array.Select<TSource, TSelectorResult>(source, CombinedSelectors);

                TSelectorResult CombinedSelectors(TSource item, long index) 
                    => selector(currentSelector(item, index), index);
            }

            public ValueReadOnlyList.WhereEnumerable<SelectEnumerable<TSource, TResult>, Enumerator, TResult> Where(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Where<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult First()
                => selector(Array.First<TSource>(source), 0);
            public TResult First(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.First<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(Array.FirstOrDefault<TSource>(source), 0);
            public TResult FirstOrDefault(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(Array.Single<TSource>(source), 0);
            public TResult Single(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Single<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(Array.SingleOrDefault<TSource>(source), 0);
            public TResult SingleOrDefault(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this, predicate);

            public IReadOnlyList<TResult> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);

            public SelectEnumerable<TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyList.ToArray<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TSource, TResult>, Enumerator, TResult>(this);

        }

        public static long Count<TSource, TResult>(this SelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueReadOnlyList.Count<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.Enumerator, TResult>(source);

        public static long Count<TSource, TResult>(this SelectEnumerable<TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TResult : struct
            => ValueReadOnlyList.Count<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TResult? FirstOrNull<TSource, TResult>(this SelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.Enumerator, TResult>(source);

        public static TResult? FirstOrNull<TSource, TResult>(this SelectEnumerable<TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TSource, TResult>(this SelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.Enumerator, TResult>(source);

        public static TResult? SingleOrNull<TSource, TResult>(this SelectEnumerable<TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.Enumerator, TResult>(source, predicate);
    }
}

