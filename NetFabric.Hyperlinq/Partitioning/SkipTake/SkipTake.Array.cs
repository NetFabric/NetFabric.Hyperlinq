using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
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
                => this[index];
            TSource IList<TSource>.this[int index]
            {
                get => this[index];
                [ExcludeFromCodeCoverage]
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item)
                => Contains(item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex) 
                => Array.Copy(source, skipCount, array, arrayIndex, Count);

            public int IndexOf(TSource item)
            {
                if (skipCount == 0 && Count == source.Length)
                    return ((IList<TSource>)source).IndexOf(item);

                if (default(TSource) is object)
                {
                    var end = skipCount + Count;
                    for (var index = skipCount; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return index - skipCount;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    var end = skipCount + Count;
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
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TSource> Take(int count)
                => ArrayExtensions.SkipTake<TSource>(source, skipCount, Math.Min(Count, count));

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Predicate<TSource> predicate)
                => ArrayExtensions.All<TSource>(source, predicate, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(PredicateAt<TSource> predicate)
                => ArrayExtensions.All<TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ArrayExtensions.Any<TSource>(source, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Predicate<TSource> predicate)
                => ArrayExtensions.Any<TSource>(source, predicate, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(PredicateAt<TSource> predicate)
                => ArrayExtensions.Any<TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => ArrayExtensions.Contains<TSource>(source, value, comparer, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, predicate, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TSource, TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
                => ArrayExtensions.Select<TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TSource, TResult> Select<TResult>(NullableSelectorAt<TSource, TResult> selector)
                => ArrayExtensions.Select<TSource, TResult>(source, selector, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource>(source, index, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => ArrayExtensions.First<TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => ArrayExtensions.Single<TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ArrayExtensions.ToArray<TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ArrayExtensions.ToList<TSource>(source, skipCount, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => ArrayExtensions.ToDictionary<TSource, TKey>(source, keySelector, comparer, skipCount, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                => ArrayExtensions.ToDictionary<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, skipCount, Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return ArrayExtensions.Count<TSource>(source.source, predicate, source.skipCount, source.Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this SkipTakeEnumerable<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return ArrayExtensions.Count<TSource>(source.source, predicate, source.skipCount, source.Count);
        }

#endif
    }
}