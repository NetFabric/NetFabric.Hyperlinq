using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [Pure]
        public static SelectEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source, 
            Selector<TSource, TResult> selector)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if(selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectEnumerable<TList, TSource, TResult>(in source, selector, 0, source.Count);
        }

        static SelectEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source,
            Selector<TSource, TResult> selector,
            int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount, takeCount);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectEnumerable<TList, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly Selector<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal SelectEnumerable(in TList source, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public readonly int Count
                => takeCount;

            [MaybeNull]
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
                readonly TList source;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < end;
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly TList source;
                readonly Selector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in SelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index]);
                readonly object? IEnumerator.Current 
                    => selector(source[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < end;

                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long LongCount()
                => source.Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TList, TSource, TResult> Skip(int count)
                => new ReadOnlyList.SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount + count, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TList, TSource, TResult> Take(int count)
                => new ReadOnlyList.SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount, Math.Min(takeCount, count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => takeCount != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(Selector<TResult, TSelectorResult> selector)
                => ReadOnlyList.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectIndexEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(SelectorAt<TResult, TSelectorResult> selector)
                => ReadOnlyList.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult ElementAt(int index)
                => selector(ReadOnlyList.ElementAt<TList, TSource>(source, index, skipCount, takeCount));
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult ElementAtOrDefault(int index)
                => selector(ReadOnlyList.ElementAtOrDefault<TList, TSource>(source, index, skipCount, takeCount));
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Maybe<TResult> TryElementAt(int index)
            {
                var item = ReadOnlyList.TryElementAt<TList, TSource>(source, index, skipCount, takeCount);
                return item.HasValue 
                    ? new Maybe<TResult>(selector(item.Value)) 
                    : default;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(ReadOnlyList.GetFirst<TList, TSource>(source, skipCount, takeCount).ThrowOnEmpty());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult FirstOrDefault()
                => selector(ReadOnlyList.GetFirst<TList, TSource>(source, skipCount, takeCount).DefaultOnEmpty());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(ReadOnlyList.GetSingle<TList, TSource>(source, skipCount, takeCount).ThrowOnEmpty());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult SingleOrDefault()
                => selector(ReadOnlyList.GetSingle<TList, TSource>(source, skipCount, takeCount).DefaultOnEmpty());

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

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            [GeneratorIgnore]
            sealed class ToListCollection
                : ICollection<TResult>
            {
                readonly TList source;
                readonly Selector<TSource, TResult> selector;
                readonly int skipCount;
                readonly int takeCount;

                public ToListCollection(in SelectEnumerable<TList, TSource, TResult> source)
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

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(source.Count, comparer);

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
                var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);

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
                => ReadOnlyList.ForEach<TList, TSource, TResult>(source, action, selector, skipCount, takeCount);
            public void ForEach(ActionAt<TResult> action)
                => ReadOnlyList.ForEach<TList, TSource, TResult>(source, action, selector, skipCount, takeCount);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource, TResult>(this SelectEnumerable<TList, TSource, TResult> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;
    }
}

