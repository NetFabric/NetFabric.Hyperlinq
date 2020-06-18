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
        public static SelectEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source, 
            NullableSelector<TSource, TResult> selector)
            where TList : IReadOnlyList<TSource>
        {
            if(selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectEnumerable<TList, TSource, TResult>(in source, selector, 0, source.Count);
        }

        static SelectEnumerable<TList, TSource, TResult> Select<TList, TSource, TResult>(
            this TList source,
            NullableSelector<TSource, TResult> selector,
            int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => new SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount, takeCount);

        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectEnumerable<TList, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>
            , IList<TResult>
            where TList : IReadOnlyList<TSource>
        {
            readonly TList source;
            readonly NullableSelector<TSource, TResult> selector;
            readonly int skipCount;

            internal SelectEnumerable(in TList source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
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

                    return selector(source[index + skipCount]);
                }
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index]!;
            TResult IList<TResult>.this[int index]
            {
                get => this[index]!;
                [ExcludeFromCodeCoverage]
                set => Throw.NotSupportedException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectEnumerable<TList, TSource, TResult>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            bool ICollection<TResult>.IsReadOnly  
                => true;

            public void CopyTo(TResult[] array, int arrayIndex) 
            {
                if (skipCount == 0)
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = selector(source[index])!;
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = selector(source[index])!;
                    }
                }
                else
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = selector(source[index + skipCount])!;
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = selector(source[index + skipCount])!;
                    }
                }
            }

            public bool Contains(TResult item)
                => ReadOnlyListExtensions.Contains<TList, TSource, TResult>(source, item, selector, skipCount, Count);

            public int IndexOf(TResult item)
            {
                var end = skipCount + Count;
                if (default(TResult) is object)
                {
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(source[index])!, item))
                            return index - skipCount;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (defaultComparer.Equals(selector(source[index])!, item))
                            return index - skipCount;
                    }
                }
                return -1;
            }

            [ExcludeFromCodeCoverage]
            void ICollection<TResult>.Add(TResult item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            public struct Enumerator
            {
                readonly TList source;
                readonly NullableSelector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal Enumerator(in SelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.Count;
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
                readonly NullableSelector<TSource, TResult> selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in SelectEnumerable<TList, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    end = enumerable.skipCount + enumerable.Count;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TResult Current
                    => selector(source[index]);
                readonly TResult IEnumerator<TResult>.Current 
                    => selector(source[index])!;
                readonly object? IEnumerator.Current
                    => selector(source[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult> Skip(int count)
                => new ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount + count, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult> Take(int count)
                => new ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult>(source, selector, skipCount, Math.Min(Count, count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(NullableSelector<TResult, TSelectorResult> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector), skipCount, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectAtEnumerable<TList, TSource, TSelectorResult> Select<TSelectorResult>(NullableSelectorAt<TResult, TSelectorResult> selector)
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

            public Dictionary<TKey, TResult> ToDictionary<TKey>(NullableSelector<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => ToDictionary<TKey>(keySelector, comparer);

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(NullableSelector<TResult, TKey> keySelector, NullableSelector<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
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
        public static int Count<TList, TSource, TResult>(this SelectEnumerable<TList, TSource, TResult> source)
            where TList : IReadOnlyList<TSource>
            => source.Count;
    }
}

