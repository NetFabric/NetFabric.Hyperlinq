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

#else
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SkipTakeEnumerable<TSource> SkipTake<TSource>(this TSource[] source, int skipCount, int takeCount)
            => new SkipTakeEnumerable<TSource>(in source, skipCount, takeCount);

        public readonly partial struct SkipTakeEnumerable<TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TSource>.Enumerator>
            , IList<TSource>
        {
            internal readonly TSource[] source;
            internal readonly int skipCount;

            internal SkipTakeEnumerable(in TSource[] source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, Count) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            public readonly int Count { get;  }

            public readonly TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count) 
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            TSource IList<TSource>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
            {
                if (arrayIndex == 0)
                {
                    if (skipCount == 0)
                    {
                        if (Count == array.Length)
                        {
                            for (var index = 0; index < array.Length; index++)
                                array[index] = source[index];
                        }
                        else
                        {
                            for (var index = 0; index < Count; index++)
                                array[index] = source[index];
                        }
                    }
                    else
                    {
                        if (Count == array.Length)
                        {
                            for (var index = 0; index < array.Length; index++)
                                array[index] = source[index + skipCount];
                        }
                        else
                        {
                            for (var index = 0; index < Count; index++)
                                array[index] = source[index + skipCount];
                        }
                    }
                }
                else
                {
                    if (skipCount == 0)
                    {
                        if (Count == array.Length)
                        {
                            for (var index = 0; index < array.Length; index++)
                                array[index + arrayIndex] = source[index];
                        }
                        else
                        {
                            for (var index = 0; index < Count; index++)
                                array[index + arrayIndex] = source[index];
                        }
                    }
                    else
                    {
                        if (Count == array.Length)
                        {
                            for (var index = 0; index < array.Length; index++)
                                array[index + arrayIndex] = source[index + skipCount];
                        }
                        else
                        {
                            for (var index = 0; index < Count; index++)
                                array[index + arrayIndex] = source[index + skipCount];
                        }
                    }
                }
            }
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotSupportedException();
            void ICollection<TSource>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotSupportedException();
            int IList<TSource>.IndexOf(TSource item)
            {
                if (skipCount == 0 && Count == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return index;
                    }
                }
                else
                {
                    var end = skipCount + Count;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return index - skipCount;
                    }
                }
                return -1;
            }
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotSupportedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotSupportedException();

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TSource> enumerable)
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
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TSource> Take(int count)
                => Array.SkipTake<TSource>(source, skipCount, Math.Min(Count, count));

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Predicate<TSource> predicate)
                => Array.All<TSource>(source, predicate, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(PredicateAt<TSource> predicate)
                => Array.All<TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Array.Any<TSource>(source, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Predicate<TSource> predicate)
                => Array.Any<TSource>(source, predicate, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(PredicateAt<TSource> predicate)
                => Array.Any<TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = null)
                => Array.Contains<TSource>(source, value, comparer, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => Array.Where<TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => Array.Where<TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TSource, TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => Array.Select<TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TSource, TResult> Select<TResult>(SelectorAt<TSource, TResult> selector)
                => Array.Select<TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => Array.ElementAt<TSource>(source, index, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => Array.First<TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => Array.Single<TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => Array.ToArray<TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => Array.ToList<TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = null)
                => Array.ToDictionary<TSource, TKey>(source, keySelector, comparer, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = null)
                => Array.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, skipCount, Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Array.Count<TSource>(source.source, predicate, source.skipCount, source.Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Array.Count<TSource>(source.source, predicate, source.skipCount, source.Count);
        }

#endif
    }
}