using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, TResult> selector)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TSource, TResult>(source, selector);
        }

        public readonly struct SelectEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TSource, TResult>.ValueEnumerator>
        {
            readonly TSource[] source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(TSource[] source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => source.Length;

            public TResult this[int index] => selector(source[index]);

            public struct Enumerator 
            {
                readonly TSource[] source;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in SelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public TResult Current => selector(source[index]);

                public bool MoveNext() => ++index < count;
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal ValueEnumerator(in SelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public bool TryMoveNext(out TResult current)
                {
                    index++;
                    if (index < count)
                    {
                        current = selector(source[index]);
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++index < count;

                public void Dispose() { }
            }

            public int Count(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Count<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool All(Func<TResult, bool> predicate)
                => ValueReadOnlyList.All<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => source.Length != 0;

            public bool Any(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Any<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyList.Contains<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyList.Contains<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ValueReadOnlyList.SelectEnumerable<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                 => ValueReadOnlyList.Select<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueReadOnlyList.WhereEnumerable<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Where<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => selector(Array.First<TSource>(source));
            public TResult First(Func<TResult, bool> predicate)
                => ValueReadOnlyList.First<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(Array.FirstOrDefault<TSource>(source));
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(Array.Single<TSource>(source));
            public TResult Single(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Single<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(Array.SingleOrDefault<TSource>(source));
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);

            public IReadOnlyCollection<TResult> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);

            public IReadOnlyList<TResult> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);

            public SelectEnumerable<TSource, TResult> AsValueEnumerable()
                => this;

            public SelectEnumerable<TSource, TResult> AsValueReadOnlyCollection()
                => this;

            public SelectEnumerable<TSource, TResult> AsValueReadOnlyList()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyList.ToArray<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);

        }

        public static TResult? FirstOrNull<TSource, TResult>(this SelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TSource, TResult>(this SelectEnumerable<TSource, TResult> source, Func<TResult, bool> predicate)
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TSource, TResult>(this SelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TSource, TResult>(this SelectEnumerable<TSource, TResult> source, Func<TResult, bool> predicate)
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TSource, TResult>, SelectEnumerable<TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}

