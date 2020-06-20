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
        static SkipTakeEnumerable<TList, TSource> SkipTake<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => new SkipTakeEnumerable<TList, TSource>(in source, skipCount, takeCount);

        public readonly partial struct SkipTakeEnumerable<TList, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TList, TSource>.Enumerator>
            , IList<TSource>
            where TList : IReadOnlyList<TSource>
        {
            internal readonly TList source;
            internal readonly int skipCount;

            internal SkipTakeEnumerable(in TList source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, Count) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly int Count { get; }

            [MaybeNull]
            public readonly TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count) 
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }
            TSource IReadOnlyList<TSource>.this[int index]
                => this[index]!;
            TSource IList<TSource>.this[int index]
            {
                get => this[index]!;
                [ExcludeFromCodeCoverage]
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(TSource[] array, int arrayIndex) 
            {
                if (skipCount == 0)
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = source[index];
                    }
                    else
                    {
                        if (Count == source.Count && source is ICollection<TSource> collection)
                        {
                            collection.CopyTo(array, arrayIndex);
                        }
                        else
                        {
                            for (var index = 0; index < Count; index++)
                                array[index + arrayIndex] = source[index];
                        }
                    }
                }
                else
                {
                    if (arrayIndex == 0)
                    {
                        for (var index = 0; index < Count; index++)
                            array[index] = source[index + skipCount];
                    }
                    else
                    {
                        for (var index = 0; index < Count; index++)
                            array[index + arrayIndex] = source[index + skipCount];
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item)
                => Contains(item);

            public int IndexOf(TSource item)
            {
                if (skipCount == 0 && Count == source.Count && source is IList<TSource> list)
                    return list.IndexOf(item);

                var end = skipCount + Count;
                if (Utils.IsValueType<TSource>())
                {
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return index - skipCount;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (defaultComparer.Equals(source[index], item))
                            return index - skipCount;
                    }
                }
                return -1;
            }

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    end = enumerable.skipCount + enumerable.Count;
                    index = enumerable.skipCount - 1;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index];
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index < end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TList, TSource> Take(int count)
                => ReadOnlyListExtensions.SkipTake<TList, TSource>(source, skipCount, Math.Min(Count, count));

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Predicate<TSource> predicate)
                => ReadOnlyListExtensions.All<TList, TSource>(source, predicate, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(PredicateAt<TSource> predicate)
                => ReadOnlyListExtensions.All<TList, TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ReadOnlyListExtensions.Any<TList, TSource>(source, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Predicate<TSource> predicate)
                => ReadOnlyListExtensions.Any<TList, TSource>(source, predicate, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(PredicateAt<TSource> predicate)
                => ReadOnlyListExtensions.Any<TList, TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => ReadOnlyListExtensions.Contains<TList, TSource>(source, value, comparer, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.WhereEnumerable<TList, TSource> Where(Predicate<TSource> predicate)
                => ReadOnlyListExtensions.Where<TList, TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource> Where(PredicateAt<TSource> predicate)
                => ReadOnlyListExtensions.Where<TList, TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectAtEnumerable<TList, TSource, TResult> Select<TResult>(NullableSelectorAt<TSource, TResult> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource>(source, index, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => ReadOnlyListExtensions.First<TList, TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => ReadOnlyListExtensions.Single<TList, TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ToArray<TList, TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ToList<TList, TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, skipCount, Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this SkipTakeEnumerable<TList, TSource> source)
            where TList : IReadOnlyList<TSource>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this SkipTakeEnumerable<TList, TSource> source, Predicate<TSource> predicate)
            where TList : IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return ReadOnlyListExtensions.Count<TList, TSource>(source.source, predicate, source.skipCount, source.Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this SkipTakeEnumerable<TList, TSource> source, PredicateAt<TSource> predicate)
            where TList : IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return ReadOnlyListExtensions.Count<TList, TSource>(source.source, predicate, source.skipCount, source.Count);
        }
    }
}