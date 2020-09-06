using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SkipTakeEnumerable<TList, TSource> SkipTake<TList, TSource>(this TList source, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => new SkipTakeEnumerable<TList, TSource>(in source, offset, count);

        [StructLayout(LayoutKind.Sequential)]
        public readonly partial struct SkipTakeEnumerable<TList, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TList, TSource>.DisposableEnumerator>
            , IList<TSource>
            where TList : notnull, IReadOnlyList<TSource>
        {
            internal readonly int offset;
            internal readonly TList source;

            internal SkipTakeEnumerable(in TList source, int offset, int count)
            {
                this.source = source;
                (this.offset, Count) = Utils.SkipTake(source.Count, offset, count);
            }

            public readonly int Count { get; }

            [MaybeNull]
            public readonly TSource this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    if (index < 0 || index >= Count) Throw.ArgumentOutOfRangeException(nameof(index));

                    return source[index + offset];
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
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, SkipTakeEnumerable<TList, TSource>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;


            public void CopyTo(TSource[] array, int arrayIndex) 
                => ReadOnlyListExtensions.Copy(source, offset, array, arrayIndex, Count);


            bool ICollection<TSource>.Contains(TSource item)
            {
                if (offset == 0 && Count == source.Count && source is ICollection<TSource> collection)
                    return collection.Contains(item);

                var end = offset + Count - 1;
                if (Utils.IsValueType<TSource>())
                {
                    for (var index = offset; index <= end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return true;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var index = offset; index <= end; index++)
                    {
                        if (defaultComparer.Equals(source[index], item))
                            return true;
                    }
                }
                return false;
            }

            public int IndexOf(TSource item)
            {
                if (offset == 0 && Count == source.Count && source is IList<TSource> list)
                    return list.IndexOf(item);

                var end = offset + Count - 1;
                if (Utils.IsValueType<TSource>())
                {
                    for (var index = offset; index <= end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(source[index], item))
                            return index - offset;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TSource>.Default;
                    for (var index = offset; index <= end; index++)
                    {
                        if (defaultComparer.Equals(source[index], item))
                            return index - offset;
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

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TList source;

                internal Enumerator(in SkipTakeEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                    => ++index <= end;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly TList source;

                internal DisposableEnumerator(in SkipTakeEnumerable<TList, TSource> enumerable)
                {
                    source = enumerable.source;
                    index = enumerable.offset - 1;
                    end = index + enumerable.Count;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current 
                    => source[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TList, TSource> Skip(int count)
                => ReadOnlyListExtensions.SkipTake<TList, TSource>(source, offset + count, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TList, TSource> Take(int count)
                => ReadOnlyListExtensions.SkipTake<TList, TSource>(source, offset, Math.Min(count, Count));


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Predicate<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return All(new ValuePredicate<TSource>(predicate));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IPredicate<TSource>
                => ReadOnlyListExtensions.All<TList, TSource, TPredicate>(source, predicate, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(PredicateAt<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return AllAt(new ValuePredicateAt<TSource>(predicate));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IPredicateAt<TSource>
                => ReadOnlyListExtensions.AllAt<TList, TSource, TPredicate>(source, predicate, offset, Count);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ReadOnlyListExtensions.Any<TList, TSource>(source, offset, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => ReadOnlyListExtensions.Contains<TList, TSource>(source, value, comparer, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.WhereEnumerable<TList, TSource, ValuePredicate<TSource>> Where(Predicate<TSource> predicate)
                => Where<ValuePredicate<TSource>>(new ValuePredicate<TSource>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate> Where<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IPredicate<TSource>
                => ReadOnlyListExtensions.Where<TList, TSource, TPredicate>(source, predicate, offset, Count);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource, ValuePredicateAt<TSource>> Where(PredicateAt<TSource> predicate)
                => WhereAt<ValuePredicateAt<TSource>>(new ValuePredicateAt<TSource>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource, TPredicate> WhereAt<TPredicate>(TPredicate predicate = default)
                where TPredicate : struct, IPredicateAt<TSource>
                => ReadOnlyListExtensions.WhereAt<TList, TSource, TPredicate>(source, predicate, offset, Count);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectEnumerable<TList, TSource, TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TResult>(source, selector, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.SelectAtEnumerable<TList, TSource, TResult> Select<TResult>(NullableSelectorAt<TSource, TResult> selector)
                => ReadOnlyListExtensions.Select<TList, TSource, TResult>(source, selector, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource>(source, index, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => ReadOnlyListExtensions.First<TList, TSource>(source, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => ReadOnlyListExtensions.Single<TList, TSource>(source, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyListExtensions.ToArray<TList, TSource>(source, offset, Count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => ReadOnlyListExtensions.ToArray<TList, TSource>(source, offset, Count, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyListExtensions.ToList<TList, TSource>(source, offset, Count);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey>(source, keySelector, comparer, offset, Count);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TElement>(source, keySelector, elementSelector, comparer, offset, Count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TList, TSource>(this in SkipTakeEnumerable<TList, TSource> source)
            where TList : notnull, IReadOnlyList<TSource>
            => source.Count;
    }
}