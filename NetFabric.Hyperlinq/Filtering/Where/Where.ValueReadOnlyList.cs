using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate, 0, source.Count);
        }

        [Pure]
        static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<,,>.DisposableEnumerator))]
        public readonly struct WhereEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Predicate<TSource> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereEnumerable(in TEnumerable source, Predicate<TSource> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TEnumerable source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }
                readonly object? IEnumerator.Current => source[index];

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
            public int Count(Predicate<TSource> predicate)
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public int Count(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public long LongCount()
                => ValueEnumerable.LongCount<TEnumerable, TEnumerator, TSource>(source, predicate);
            public long LongCount(Predicate<TSource> predicate)
                => ValueEnumerable.LongCount<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool Any()
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public bool Any(Predicate<TSource> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public bool Any(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public ValueReadOnlyList.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => ValueReadOnlyList.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public ValueReadOnlyList.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Predicate<TSource> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public ValueReadOnlyList.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public TSource First()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource First(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();
            public TSource First(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();

            [return: MaybeNull]
            public TSource FirstOrDefault()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            [return: MaybeNull]
            public TSource FirstOrDefault(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();
            [return: MaybeNull]
            public TSource FirstOrDefault(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();

            public (ElementResult Success, TSource Value) TryFirst()
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public (ElementResult Success, TSource Value) TryFirst(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public (int Index, TSource Value) TryFirst(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.GetFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public TSource Single()
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource Single(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();
            public TSource Single(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();

            [return: MaybeNull]
            public TSource SingleOrDefault()
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            [return: MaybeNull]
            public TSource SingleOrDefault(Predicate<TSource> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();
            [return: MaybeNull]
            public TSource SingleOrDefault(PredicateAt<TSource> predicate)
                => ValueReadOnlyList.GetSingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();

            public List<TSource> ToList()
                => ValueReadOnlyList.ToList<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey>(source, keySelector, comparer, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, EqualityComparer<TKey>.Default, predicate, skipCount, takeCount);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => ValueReadOnlyList.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, predicate, skipCount, takeCount);

            public void ForEach(Action<TSource> action)
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        action(source[index]);
                }
            }
            public void ForEach(Action<TSource, int> action)
            {
                var actionIndex = 0;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        action(source[index], actionIndex++);
                }
            }
        }
    }
}

