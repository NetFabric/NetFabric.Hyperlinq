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
        internal static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Predicate<TSource> predicate,
            Selector<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector, 0, source.Count);
        }

        [Pure]
        internal static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source,
            Predicate<TSource> predicate,
            Selector<TSource, TResult> selector, 
            int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, predicate, selector, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereSelectEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereSelectEnumerable<,,,>.Enumerator))]
        public readonly struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Predicate<TSource> predicate;
            readonly Selector<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereSelectEnumerable(in TEnumerable source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index]);
                }
                readonly object? IEnumerator.Current => selector(source[index]);

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

            public List<TResult> ToList()
            {
                var list = new List<TResult>();

                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        list.Add(selector(source[index]));
                }

                return list;
            }

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(0, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                    {
                        item = selector(source[index]);
                        dictionary.Add(keySelector(item), item);
                    }
                }

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                    {
                        item = selector(source[index]);
                        dictionary.Add(keySelector(item), elementSelector(item));
                    }
                }

                return dictionary;
            }

            public void ForEach(Action<TResult> action)
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        action(selector(source[index]));
                }
            }
            public void ForEach(Action<TResult, int> action)
            {
                var actionIndex = 0;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        action(selector(source[index]), actionIndex++);
                }
            }
        }
    }
}

