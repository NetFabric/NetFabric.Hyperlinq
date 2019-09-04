using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate, 0, source.Count);
        }

        [Pure]
        static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<,,>.Enumerator))]
        public readonly struct WhereEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereEnumerable(in TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }
                readonly object IEnumerator.Current => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public int Count(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public int Count(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public long LongCount()
                => ValueEnumerable.LongCount<TEnumerable, TEnumerator, TSource>(source, predicate);
            public long LongCount(Func<TSource, bool> predicate)
                => ValueEnumerable.LongCount<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate));

            public bool Any()
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public bool Any(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public bool Any(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public ValueReadOnlyList.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ValueReadOnlyList.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public ValueReadOnlyList.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public ValueReadOnlyList.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public TSource First()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();
            public TSource First(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();

            public TSource FirstOrDefault()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();

            public (ElementResult Success, TSource Value) TryFirst()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public (ElementResult Success, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);
            public (int Index, TSource Value) TryFirst(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount);

            public TSource Single()
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();
            public TSource Single(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();

            public TSource SingleOrDefault()
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.CombinePredicates(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();

            public List<TSource> ToList()
                => ValueReadOnlyList.ToList<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);
        }
    }
}

