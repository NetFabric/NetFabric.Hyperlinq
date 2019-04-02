using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectEnumerable<TEnumerable, TSource, TResult> Select<TEnumerable, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectEnumerable<TEnumerable, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => source.Count;

            public TResult this[int index] => selector(source[index]);

            public struct Enumerator 
            {
                readonly TEnumerable source;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in SelectEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public TResult Current => selector(source[index]);

                public bool MoveNext() => ++index < count;
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal ValueEnumerator(in SelectEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
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
                => ValueReadOnlyList.Count<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool All(Func<TResult, bool> predicate)
                => ValueReadOnlyList.All<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => source.Count != 0;

            public bool Any(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Any<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyList.Contains<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyList.Contains<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ValueReadOnlyList.SelectEnumerable<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                 => ValueReadOnlyList.Select<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueReadOnlyList.WhereEnumerable<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Where<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => selector(ReadOnlyList.First<TEnumerable, TSource>(source));
            public TResult First(Func<TResult, bool> predicate)
                => ValueReadOnlyList.First<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(ReadOnlyList.FirstOrDefault<TEnumerable, TSource>(source));
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(ReadOnlyList.Single<TEnumerable, TSource>(source));
            public TResult Single(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Single<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(ReadOnlyList.SingleOrDefault<TEnumerable, TSource>(source));
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public IReadOnlyCollection<TResult> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public IReadOnlyList<TResult> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public SelectEnumerable<TEnumerable, TSource, TResult> AsValueEnumerable()
                => this;

            public SelectEnumerable<TEnumerable, TSource, TResult> AsValueReadOnlyCollection()
                => this;

            public SelectEnumerable<TEnumerable, TSource, TResult> AsValueReadOnlyList()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyList.ToArray<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

        }

        public static TResult? FirstOrNull<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source, Func<TResult, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source, Func<TResult, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}

