using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereAtEnumerable<TSource, ValuePredicateAt<TSource>> Where<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => new SpanWhereAtEnumerable<TSource, TPredicate>(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanWhereAtEnumerable<TSource, TPredicate>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly TPredicate predicate;

            internal SpanWhereAtEnumerable(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator 
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                readonly TPredicate predicate;

                internal Enumerator(in SpanWhereAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index], index))
                            return true;
                    }
                    return false;
                }
            }

            public int Count()
                => ArrayExtensions.CountAt<TSource, TPredicate>(source, predicate);

            public bool Any()
                => ArrayExtensions.AnyAt<TSource, TPredicate>(source, predicate);

            public SpanWhereAtEnumerable<TSource, PredicatePredicateAtCombination<ValuePredicate<TSource>, TPredicate, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public SpanWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => WhereAt<TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            public SpanWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public SpanWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => WhereAt<TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAtAt<TSource, TPredicate>(source, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.FirstAt<TSource, TPredicate>(source, predicate);

            public Option<TSource> Single()
                => ArrayExtensions.SingleAt<TSource, TPredicate>(source, predicate);

            public TSource[] ToArray()
                => ArrayExtensions.ToArrayAt<TSource, TPredicate>(source, predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => ArrayExtensions.ToArrayAt<TSource, TPredicate>(source, predicate, memoryPool);

            public List<TSource> ToList()
                => ArrayExtensions.ToListAt<TSource, TPredicate>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ArrayExtensions.ToDictionaryAt<TSource, TKey, TPredicate>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ArrayExtensions.ToDictionaryAt<TSource, TKey, TElement, TPredicate>(source, keySelector, elementSelector, comparer, predicate);

            public bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = null)
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

                    if (!comparer.Equals(enumerator.Current, otherEnumerator.Current))
                        return false;
                }
            }
        }
    }
}

