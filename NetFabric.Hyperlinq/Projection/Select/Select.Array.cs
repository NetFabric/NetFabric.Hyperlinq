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
        public static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source, 
            Selector<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectEnumerable<TSource, TResult>(source, selector, 0, source.Length);
        }

        [Pure]
        static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source,
            Selector<TSource, TResult> selector,
            int skipCount, int takeCount)
            => new SelectEnumerable<TSource, TResult>(source, selector, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SelectEnumerable<,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectEnumerable<,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        [GenericsMapping("TResult", "TSelectorResult")]
        public readonly struct SelectEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TSource, TResult>.DisposableEnumerator>
        {
            internal readonly TSource[] source;
            internal readonly Selector<TSource, TResult> selector;
            internal readonly int skipCount;
            internal readonly int takeCount;

            internal SelectEnumerable(TSource[] source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectEnumerable<TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public readonly int Count => takeCount;

            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source[index + skipCount]);
                }
            }

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector(source[index]);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < end;
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in SelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
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

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => ++index < end;

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            public long LongCount()
                => Array.LongCount<TSource>(source);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TSource, TResult> Skip(int count)
                => new SelectEnumerable<TSource, TResult>(source, selector, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TSource, TResult> Take(int count)
                => new SelectEnumerable<TSource, TResult>(source, selector, skipCount, Math.Min(takeCount, count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => takeCount != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.SelectEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(Selector<TResult, TSelectorResult> selector)
                => Array.Select<TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Array.SelectIndexEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(SelectorAt<TResult, TSelectorResult> selector)
                => Array.Select<TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult ElementAt(int index)
                => selector(Array.ElementAt<TSource>(source, index, skipCount, takeCount));
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult ElementAtOrDefault(int index)
                => selector(Array.ElementAtOrDefault<TSource>(source, index, skipCount, takeCount));
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Maybe<TResult> TryElementAt(int index)
            {
                var item = Array.TryElementAt<TSource>(source, index, skipCount, takeCount);
                return item.HasValue ? new Maybe<TResult>(selector(item.Value)) : default;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(Array.First<TSource>(source, skipCount, takeCount));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult FirstOrDefault()
                => selector(Array.FirstOrDefault<TSource>(source, skipCount, takeCount));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(Array.Single<TSource>(source, skipCount, takeCount));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult SingleOrDefault()
                => selector(Array.SingleOrDefault<TSource>(source, skipCount, takeCount));

            public TResult[] ToArray()
            {
                var array = new TResult[takeCount];

                for (var index = 0; index < takeCount; index++)
                    array[index] = selector(source[index + skipCount]);

                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => new List<TResult>(new ToListCollection(this));

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(source.Length, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    item = selector(source[index]);
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
                    item = selector(source[index]);
                    dictionary.Add(keySelector(item), elementSelector(item));
                }

                return dictionary;
            }

            public void ForEach(Action<TResult> action)
                => Array.ForEach<TSource, TResult>(source, action, selector, skipCount, takeCount);
            public void ForEach(Action<TResult, int> action)
                => Array.ForEach<TSource, TResult>(source, action, selector, skipCount, takeCount);

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            [Ignore]
            sealed class ToListCollection
                : ICollection<TResult>
            {
                readonly TSource[] source;
                readonly Selector<TSource, TResult> selector;
                readonly int skipCount;
                readonly int takeCount;

                public ToListCollection(in SelectEnumerable<TSource, TResult> source)
                {
                    this.source = source.source;
                    this.selector = source.selector;
                    this.skipCount = source.skipCount;
                    this.takeCount = source.takeCount;
                }

                public int Count => takeCount;

                public bool IsReadOnly => true;

                public void CopyTo(TResult[] array, int _)
                {
                    for (var index = 0; index < takeCount; index++)
                        array[index] = selector(source[index + skipCount]);
                }

                IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => throw new NotSupportedException();
                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                void ICollection<TResult>.Add(TResult item) => throw new NotSupportedException();
                bool ICollection<TResult>.Remove(TResult item) => throw new NotSupportedException();
                void ICollection<TResult>.Clear() => throw new NotSupportedException();
                bool ICollection<TResult>.Contains(TResult item) => throw new NotSupportedException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this SelectEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

