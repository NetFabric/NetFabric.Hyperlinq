using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        internal static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, bool> predicate, 
            Func<TSource, TResult> selector) 
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TSource, TResult>(source, predicate, selector);
        }

        public readonly struct WhereSelectEnumerable<TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TSource, TResult>.ValueEnumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, bool> predicate;
            readonly Func<TSource, TResult> selector;

            internal WhereSelectEnumerable(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
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

                public TResult Current => selector(source[index]);

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public bool TryMoveNext(out TResult current)
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                        {
                            current = selector(source[index]);
                            return true;
                        }

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
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public int Count()
                => source.Count(predicate);

            public int Count(Func<TResult, bool> predicate)
                => ValueEnumerable.Count<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool All(Func<TResult, bool> predicate)
                => ValueEnumerable.All<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);

            public bool Any(Func<TResult, bool> predicate)
                => ValueEnumerable.Any<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueEnumerable.Contains<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueEnumerable.Contains<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ValueEnumerable.Select<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueEnumerable.Where<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate)
                => ValueEnumerable.First<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate)
                => ValueEnumerable.Single<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<WhereSelectEnumerable<TSource, TResult>, ValueEnumerator, TResult>(this);
        }

        public static TResult? FirstOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueEnumerable.FirstOrNull<WhereSelectEnumerable<TSource, TResult>, WhereSelectEnumerable<TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source, Func<TResult, bool> predicate)
            where TResult : struct
            => ValueEnumerable.FirstOrNull<WhereSelectEnumerable<TSource, TResult>, WhereSelectEnumerable<TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source)
            where TResult : struct
            => ValueEnumerable.SingleOrNull<WhereSelectEnumerable<TSource, TResult>, WhereSelectEnumerable<TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TSource, TResult>(this WhereSelectEnumerable<TSource, TResult> source, Func<TResult, bool> predicate)
            where TResult : struct
            => ValueEnumerable.SingleOrNull<WhereSelectEnumerable<TSource, TResult>, WhereSelectEnumerable<TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}

