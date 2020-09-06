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
        public static WhereAtEnumerable<TList, TSource, ValuePredicateAt<TSource>> Where<TList, TSource>(this TList source, PredicateAt<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt<TList, TSource, ValuePredicateAt<TSource>>(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereAtEnumerable<TList, TSource, TPredicate> WhereAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate = default)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
            => WhereAt<TList, TSource, TPredicate>(source, predicate, 0, source.Count);


        static WhereAtEnumerable<TList, TSource, TPredicate> WhereAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
            => new WhereAtEnumerable<TList, TSource, TPredicate>(source, predicate, offset, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereAtEnumerable<TList, TSource, TPredicate>
            : IValueEnumerable<TSource, WhereAtEnumerable<TList, TSource, TPredicate>.DisposableEnumerator>
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            readonly TList source;
            readonly TPredicate predicate;
            readonly int offset;
            readonly int count;

            internal WhereAtEnumerable(TList source, TPredicate predicate, int offset, int count)
            {
                this.source = source;
                this.predicate = predicate;
                (this.offset, this.count) = Utils.SkipTake(source.Count, offset, count);
            }

            
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereAtEnumerable<TList, TSource, TPredicate>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int offset;
                readonly int end;
                readonly TList source;
                readonly TPredicate predicate;

                internal Enumerator(in WhereAtEnumerable<TList, TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index + offset];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index + offset], index))
                            return true;
                    }
                    return false;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int offset;
                readonly int end;
                readonly TList source;
                readonly TPredicate predicate;

                internal DisposableEnumerator(in WhereAtEnumerable<TList, TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index + offset];
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index + offset];
                readonly object? IEnumerator.Current 
                    => source[index + offset];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index + offset], index))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            public int Count()
                => ReadOnlyListExtensions.CountAt<TList, TSource, TPredicate>(source, predicate, offset, count);

            public bool Any()
                => ReadOnlyListExtensions.AnyAt<TList, TSource, TPredicate>(source, predicate, offset, count);

            public WhereAtEnumerable<TList, TSource, PredicatePredicateAtCombination<ValuePredicate<TSource>, TPredicate, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null)
                    Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public WhereAtEnumerable<TList, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => WhereAt<TList, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            public WhereAtEnumerable<TList, TSource, PredicateAtPredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null)
                    Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public WhereAtEnumerable<TList, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => WhereAt<TList, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAtAt<TList, TSource, TPredicate>(source, index, predicate, offset, count);

            public Option<TSource> First()
                => ReadOnlyListExtensions.FirstAt<TList, TSource, TPredicate>(source, predicate, offset, count);

            public Option<TSource> Single()
                => ReadOnlyListExtensions.SingleAt<TList, TSource, TPredicate>(source, predicate, offset, count);

            public TSource[] ToArray()
                => ReadOnlyListExtensions.ToArrayAt<TList, TSource, TPredicate>(source, predicate, offset, count);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => ReadOnlyListExtensions.ToArrayAt<TList, TSource, TPredicate>(source, predicate, offset, count, pool);

            public List<TSource> ToList()
                => ReadOnlyListExtensions.ToListAt<TList, TSource, TPredicate>(source, predicate, offset, count);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ReadOnlyListExtensions.ToDictionaryAt<TList, TSource, TKey, TPredicate>(source, keySelector, comparer, predicate, offset, count);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ReadOnlyListExtensions.ToDictionaryAt<TList, TSource, TKey, TElement, TPredicate>(source, keySelector, elementSelector, comparer, predicate, offset, count);

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
            {
                comparer ??= EqualityComparer<TSource>.Default;

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
    }
}

