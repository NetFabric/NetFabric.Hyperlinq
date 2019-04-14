using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
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

            public int Count => source.Count;

            public TResult this[int index] => selector(source[index]);

            public struct Enumerator 
            {
                readonly TEnumerable source;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
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

                internal ValueEnumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
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

            public ValueReadOnlyCollection.SkipTakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Skip(int count)
                => ValueReadOnlyCollection.Skip<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public ValueReadOnlyCollection.SkipTakeEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Take(int count)
                => ValueReadOnlyCollection.Take<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, count);

            public bool All(Func<TResult, bool> predicate)
                => ValueReadOnlyList.All<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => source.Count != 0;

            public bool Any(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Any<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueReadOnlyList.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueReadOnlyList.Contains<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ValueReadOnlyList.SelectEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                 => ValueReadOnlyList.Select<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueReadOnlyList.WhereEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Where<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => selector(ValueReadOnlyList.First<TEnumerable, TEnumerator, TSource>(source));
            public TResult First(Func<TResult, bool> predicate)
                => ValueReadOnlyList.First<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => selector(ValueReadOnlyList.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source));
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => selector(ValueReadOnlyList.Single<TEnumerable, TEnumerator, TSource>(source));
            public TResult Single(Func<TResult, bool> predicate)
                => ValueReadOnlyList.Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => selector(ValueReadOnlyList.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source));
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IReadOnlyList<TResult> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueReadOnlyList.ToArray<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueReadOnlyCollection.ToList<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, ValueEnumerator, TResult>(this);
        }

        public static int Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        public static int Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => ValueReadOnlyList.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyList.FirstOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TResult : struct
            => ValueReadOnlyList.SingleOrNull<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}

