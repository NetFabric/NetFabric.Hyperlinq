using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static SelectIndexEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source, 
            SelectorAt<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectIndexEnumerable<TSource, TResult>(source, selector, 0, source.Length);
        }

        [Pure]
        static SelectIndexEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source,
            SelectorAt<TSource, TResult> selector,
            int skipCount, int takeCount)
            => new SelectIndexEnumerable<TSource, TResult>(source, selector, skipCount, takeCount);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectIndexEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, SelectIndexEnumerable<TSource, TResult>.Enumerator>
        {
            readonly TSource[] source;
            readonly SelectorAt<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal SelectIndexEnumerable(TSource[] source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public readonly int Count => takeCount;

            [MaybeNull]
            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source[index + skipCount], index);
                }
            }

            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly SelectorAt<TSource, TResult> selector;
                readonly int skipCount;
                readonly int takeCount;
                int index;

                internal Enumerator(in SelectIndexEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    skipCount = enumerable.skipCount;
                    takeCount = enumerable.takeCount;
                    index = -1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index + skipCount], index);
                readonly object? IEnumerator.Current 
                    => selector(source[index + skipCount], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < takeCount;

                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long LongCount()
                => source.Length;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectIndexEnumerable<TSource, TResult> Skip(int count)
                => new SelectIndexEnumerable<TSource, TResult>(source, selector, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectIndexEnumerable<TSource, TResult> Take(int count)
                => new SelectIndexEnumerable<TSource, TResult>(source, selector, skipCount, Math.Min(takeCount, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => takeCount != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.SelectIndexEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(Selector<TResult, TSelectorResult> selector)
                => Array.Select<TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.SelectIndexEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(SelectorAt<TResult, TSelectorResult> selector)
                => Array.Select<TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(Array.First<TSource>(source, skipCount, takeCount), skipCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult FirstOrDefault()
                => selector(Array.FirstOrDefault<TSource>(source, skipCount, takeCount), skipCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(Array.Single<TSource>(source, skipCount, takeCount), skipCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult SingleOrDefault()
                => selector(Array.SingleOrDefault<TSource>(source, skipCount, takeCount), skipCount);

            public TResult[] ToArray()
            {
                var array = new TResult[takeCount];

                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index + skipCount], index);

                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => Array.ToList<TSource, TResult>(source, selector, skipCount, takeCount);

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(source.Length, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    item = selector(source[index], index);
                    dictionary.Add(keySelector(item), item);
                }

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    item = selector(source[index], index);
                    dictionary.Add(keySelector(item), elementSelector(item));
                }

                return dictionary;
            }

            public void ForEach(Action<TResult> action)
                => Array.ForEach<TSource, TResult>(source, action, selector, skipCount, takeCount);
            public void ForEach(ActionAt<TResult> action)
                => Array.ForEach<TSource, TResult>(source, action, selector, skipCount, takeCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this SelectIndexEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

