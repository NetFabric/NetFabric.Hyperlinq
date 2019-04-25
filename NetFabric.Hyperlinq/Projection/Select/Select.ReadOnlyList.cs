using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectEnumerable<TEnumerable, TSource, TResult> Select<TEnumerable, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, int, TResult> selector)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TSource, TResult>(source, selector, 0, source.Count);
        }

        public readonly struct SelectEnumerable<TEnumerable, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, int, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, int, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count => takeCount;
            long IValueReadOnlyCollection<TResult, ValueEnumerator>.Count => takeCount;

            public TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    var currentIndex = index + skipCount;
                    return selector(source[currentIndex], currentIndex);
                }
            }

            TResult IValueReadOnlyList<TResult, ValueEnumerator>.this[long index]
            {
                get
                {
                    if (index > int.MaxValue)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return this[(int)index];
                }
            }

            public struct Enumerator 
            {
                readonly TEnumerable source;
                readonly Func<TSource, int, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TResult Current => selector(source[index], index);

                public bool MoveNext() => ++index < end;
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, int, TResult> selector;
                readonly int end;
                int index;

                internal ValueEnumerator(in SelectEnumerable<TEnumerable, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public bool TryMoveNext(out TResult current)
                {
                    index++;
                    if (index < end)
                    {
                        current = selector(source[index], index);
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++index < end;

                public void Dispose() { }
            }

            public SelectEnumerable<TEnumerable, TSource, TResult> Skip(int count)
                => new SelectEnumerable<TEnumerable, TSource, TResult>(source, selector, skipCount + count, takeCount);

            public SelectEnumerable<TEnumerable, TSource, TResult> Take(int count)
                => new SelectEnumerable<TEnumerable, TSource, TResult>(source, selector, skipCount, Math.Min(takeCount, count));

            public bool All(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.All<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => source.Count != 0;

            public bool Any(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Any<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyList.Contains<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyList.Contains<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ReadOnlyList.SelectEnumerable<TEnumerable, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, int, TSelectorResult> selector)
            {
                var currentSelector = this.selector;
                return ReadOnlyList.Select<TEnumerable, TSource, TSelectorResult>(source, CombinedSelectors);

                TSelectorResult CombinedSelectors(TSource item, int index) 
                    => selector(currentSelector(item, index), index);
            }

            public ValueReadOnlyList.WhereEnumerable<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Where<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => selector(ReadOnlyList.First<TEnumerable, TSource>(source), 0);
            public TResult First(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.First<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(ReadOnlyList.FirstOrDefault<TEnumerable, TSource>(source), 0);
            public TResult FirstOrDefault(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(ReadOnlyList.Single<TEnumerable, TSource>(source), 0);
            public TResult Single(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.Single<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(ReadOnlyList.SingleOrDefault<TEnumerable, TSource>(source), 0);
            public TResult SingleOrDefault(Func<TResult, long, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IReadOnlyList<TResult> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public SelectEnumerable<TEnumerable, TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyList.ToArray<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TEnumerable, TSource, TResult>, ValueEnumerator, TResult>(this);
        }

        public static int Count<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            => (int)ValueReadOnlyList.Count<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static int Count<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            => (int)ValueReadOnlyList.Count<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? FirstOrNull<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TSource, TResult>(this SelectEnumerable<TEnumerable, TSource, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TEnumerable, TSource, TResult>, SelectEnumerable<TEnumerable, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}

