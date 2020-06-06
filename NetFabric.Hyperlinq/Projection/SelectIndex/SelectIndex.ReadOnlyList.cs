using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectIndexEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source, 
            SelectorAt<TSource, TResult> selector)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if(selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectIndexEnumerable<TList, TSource, TResult>(in source, selector, 0, source.Count);
        }


        static SelectIndexEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source,
            SelectorAt<TSource, TResult> selector,
            int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new SelectIndexEnumerable<TList, TSource, TResult>(source, selector, skipCount, takeCount);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectIndexEnumerable<TList, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectIndexEnumerable<TList, TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly SelectorAt<TSource, TResult> selector;
            readonly int skipCount;
            readonly int takeCount;

            internal SelectIndexEnumerable(in TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly int Count => takeCount;

            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source[index + skipCount], index);
                }
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectIndexEnumerable<TList, TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            TResult IList<TResult>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }

            bool ICollection<TResult>.IsReadOnly  
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex) 
            {
                for (var index = 0; index < takeCount; index++)
                    array[index + arrayIndex] = selector(source[index + skipCount], index);
            }
            void ICollection<TResult>.Add(TResult item) 
                => throw new NotSupportedException();
            void ICollection<TResult>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TResult>.Contains(TResult item) 
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(source[index + skipCount], index), item))
                        return true;
                }
                return false;
            }
            bool ICollection<TResult>.Remove(TResult item) 
                => throw new NotSupportedException();
            int IList<TResult>.IndexOf(TResult item)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(source[index + skipCount], index), item))
                        return index;
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => throw new NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => throw new NotSupportedException();

            public struct Enumerator
            {
                readonly TList source;
                readonly SelectorAt<TSource, TResult> selector;
                readonly int skipCount;
                readonly int takeCount;
                int index;

                internal Enumerator(in SelectIndexEnumerable<TList, TSource, TResult> enumerable)
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

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < takeCount;
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                readonly TList source;
                readonly SelectorAt<TSource, TResult> selector;
                readonly int skipCount;
                readonly int takeCount;
                int index;

                internal DisposableEnumerator(in SelectIndexEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    skipCount = enumerable.skipCount;
                    takeCount = enumerable.takeCount;
                    index = -1;
                }

                public readonly TResult Current
                    => selector(source[index + skipCount], index);
                readonly object? IEnumerator.Current 
                    => selector(source[index + skipCount], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < takeCount;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => takeCount != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => ReadOnlyList.Contains<TList, TSource, TResult>(source, value, comparer, selector, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectIndexEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(Selector<TResult, TSelectorResult> selector)
                => ReadOnlyList.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyList.SelectIndexEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(SelectorAt<TResult, TSelectorResult> selector)
                => ReadOnlyList.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, takeCount);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ReadOnlyList.ElementAt<TList, TSource, TResult>(source, index, selector, skipCount, takeCount);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ReadOnlyList.First<TList, TSource, TResult>(source, selector, skipCount, takeCount);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ReadOnlyList.Single<TList, TSource, TResult>(source, selector, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ReadOnlyList.ToArray<TList, TSource, TResult>(source, selector, skipCount, takeCount);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ReadOnlyList.ToList<TList, TSource, TResult>(source, selector, skipCount, takeCount);

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            {
                var dictionary = new Dictionary<TKey, TResult>(source.Count, comparer);

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
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);

                TResult item;
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    item = selector(source[index], index);
                    dictionary.Add(keySelector(item), elementSelector(item));
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource, TResult>(this SelectIndexEnumerable<TList, TSource, TResult> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;
    }
}

