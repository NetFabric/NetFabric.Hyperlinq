using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SelectAtEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source, 
            SelectorAt<TSource, TResult> selector)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if(selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectAtEnumerable<TList, TSource, TResult>(in source, selector, 0, source.Count);
        }


        static SelectAtEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source,
            SelectorAt<TSource, TResult> selector,
            int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
            => new SelectAtEnumerable<TList, TSource, TResult>(source, selector, skipCount, takeCount);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectAtEnumerable<TList, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectAtEnumerable<TList, TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
            where TList : notnull, IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly SelectorAt<TSource, TResult> selector;
            readonly int skipCount;

            internal SelectAtEnumerable(in TList source, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            {
                this.source = source;
                this.selector = selector;
                (this.skipCount, Count) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly int Count { get; }

            [MaybeNull]
            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source[index + skipCount], index);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index]!;
            TResult IList<TResult>.this[int index]
            {
                get => this[index]!;
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectAtEnumerable<TList, TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            bool ICollection<TResult>.IsReadOnly  
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex) 
            {
                if (skipCount == 0)
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = selector(source[index], index)!;
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = selector(source[index], index)!;
                    }
                }
                else
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = selector(source[index + skipCount], index)!;
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = selector(source[index + skipCount], index)!;
                    }
                }
            }
            void ICollection<TResult>.Add(TResult item) 
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TResult>.Contains(TResult item)
                => ReadOnlyListExtensions.Contains<TList, TSource, TResult>(source, item, selector, skipCount, Count);
            bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
            {
                if (default(TResult) is object)
                {
                    if (skipCount == 0)
                    {
                        for (var index = 0; index < Count; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(source[index], index)!, item))
                                return index;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(source[index + skipCount], index)!, item))
                                return index;
                        }
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;

                    if (skipCount == 0)
                    {
                        for (var index = 0; index < Count; index++)
                        {
                            if (defaultComparer.Equals(selector(source[index], index)!, item))
                                return index;
                        }
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                        {
                            if (defaultComparer.Equals(selector(source[index + skipCount], index)!, item))
                                return index;
                        }
                    }
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            public struct Enumerator
            {
                readonly TList source;
                readonly SelectorAt<TSource, TResult> selector;
                readonly int skipCount;
                readonly int takeCount;
                int index;

                internal Enumerator(in SelectAtEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    skipCount = enumerable.skipCount;
                    takeCount = enumerable.Count;
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

                internal DisposableEnumerator(in SelectAtEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    skipCount = enumerable.skipCount;
                    takeCount = enumerable.Count;
                    index = -1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index + skipCount], index);
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source[index + skipCount], index)!;
                readonly object? IEnumerator.Current
                    => selector(source[index + skipCount], index);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < takeCount;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectAtEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(Selector<TResult, TSelectorResult> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectAtEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(SelectorAt<TResult, TSelectorResult> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource, TResult>(source, index, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ReadOnlyListExtensions.First<TList, TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ReadOnlyListExtensions.Single<TList, TSource, TResult>(source, selector, skipCount, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ReadOnlyListExtensions.ToArray<TList, TSource, TResult>(source, selector, skipCount, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ReadOnlyListExtensions.ToList<TList, TSource, TResult>(source, selector, skipCount, Count);

            public Dictionary<TKey, TResult> ToDictionary<TKey>(Selector<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => ToDictionary<TKey>(keySelector, comparer);

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TResult, TKey> keySelector, Selector<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, comparer);

            public readonly bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = default)
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

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource, TResult>(this SelectAtEnumerable<TList, TSource, TResult> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;
    }
}

