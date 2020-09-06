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
        public static SpanWhereEnumerable<TSource, ValuePredicate<TSource>> Where<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Where(source, new ValuePredicate<TSource>(predicate));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => new SpanWhereEnumerable<TSource, TPredicate>(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanWhereEnumerable<TSource, TPredicate>
            where TPredicate : struct, IPredicate<TSource>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly TPredicate predicate;

            internal SpanWhereEnumerable(ReadOnlySpan<TSource> source, TPredicate predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator 
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                readonly TPredicate predicate;

                internal Enumerator(in SpanWhereEnumerable<TSource, TPredicate> enumerable)
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
                        if (predicate.Invoke(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public int Count()
                => ArrayExtensions.Count(source, predicate);

            public bool Any()
                => ArrayExtensions.Any(source, predicate);

            public SpanWhereEnumerable<TSource, PredicatePredicateCombination<TPredicate, ValuePredicate<TSource>, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public SpanWhereEnumerable<TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => ArrayExtensions.Where<TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public SpanWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public SpanWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => ArrayExtensions.WhereAt<TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public SpanWhereSelectEnumerable<TSource, TResult, TPredicate> Select<TResult>(NullableSelector<TSource, TResult> selector)
            {
                if (selector is null) Throw.ArgumentNullException(nameof(selector));

                return WhereSelect<TSource, TResult, TPredicate>(source, predicate, selector);
            }

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TPredicate>(source, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.First<TSource, TPredicate>(source, predicate);

            public Option<TSource> Single()
                => ArrayExtensions.Single<TSource, TPredicate>(source, predicate);

            public TSource[] ToArray()
                => ArrayExtensions.ToArray<TSource, TPredicate>(source, predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => ArrayExtensions.ToArray<TSource, TPredicate>(source, predicate, memoryPool);

            public List<TSource> ToList()
                => ArrayExtensions.ToList<TSource, TPredicate>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ArrayExtensions.ToDictionary<TSource, TKey, TPredicate>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ArrayExtensions.ToDictionary<TSource, TKey, TElement, TPredicate>(source, keySelector, elementSelector, comparer, predicate);

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

