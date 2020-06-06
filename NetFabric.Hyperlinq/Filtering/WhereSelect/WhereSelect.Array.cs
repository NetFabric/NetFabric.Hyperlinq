using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemoryWhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(this TSource[] source, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            => WhereSelect(source.AsMemory(), predicate, selector);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereSelectEnumerable<TSource, TResult> WhereSelect<TSource, TResult>(
            this TSource[] source,
            Predicate<TSource> predicate,
            Selector<TSource, TResult> selector,
            int skipCount, int takeCount)
            => new WhereSelectEnumerable<TSource, TResult>(in source, predicate, selector, skipCount, takeCount);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct WhereSelectEnumerable<TSource, TResult>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TSource, TResult>.DisposableEnumerator>
        {
            readonly TSource[] source;
            readonly Predicate<TSource> predicate;
            readonly Selector<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereSelectEnumerable(in TSource[] source, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, WhereSelectEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TResult Current
                    => selector(source[index]);

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
                : IEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TResult Current
                    => selector(source[index]);
                readonly object? IEnumerator.Current
                    => selector(source[index]);

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => Count<TSource>(source, predicate, skipCount, takeCount);

            public bool Any()
                => Any<TSource>(source, predicate, skipCount, takeCount);

            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => Contains<TSource, TResult>(source, value, comparer, predicate, selector, skipCount, takeCount);

            public Option<TResult> ElementAt(int index)
                => ElementAt<TSource, TResult>(source, index, predicate, selector, skipCount, takeCount);

            public Option<TResult> First()
                => First<TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public Option<TResult> Single()
                => Single<TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public TResult[] ToArray()
                => ToArray<TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public List<TResult> ToList()
                => ToList<TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer)
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
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
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

            public readonly bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                var enumerator = GetEnumerator();
                using var otherEnumerator = other.GetEnumerator();
                while (true)
                {
                    var thisEnded = !enumerator.MoveNext();
                    var otherEnded = !otherEnumerator.MoveNext();

                    if (thisEnded != otherEnded)
                        return false;

                    if (thisEnded)
                        return true;

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }

#endif
    }
}

