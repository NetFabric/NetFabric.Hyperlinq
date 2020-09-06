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
        public static WhereEnumerable<TList, TSource, ValuePredicate<TSource>> Where<TList, TSource>(this TList source, Predicate<TSource> predicate)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Where<TList, TSource, ValuePredicate<TSource>>(source, new ValuePredicate<TSource>(predicate));
        }

        public static WhereEnumerable<TList, TSource, TPredicate> Where<TList, TSource, TPredicate>(this TList source, TPredicate predicate = default)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => Where<TList, TSource, TPredicate>(source, predicate, 0, source.Count);

        static WhereEnumerable<TList, TSource, TPredicate> Where<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => new WhereEnumerable<TList, TSource, TPredicate>(source, predicate, offset, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereEnumerable<TList, TSource, TPredicate>
            : IValueEnumerable<TSource, WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator>
            where TList : notnull, IReadOnlyList<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            readonly TList source;
            readonly TPredicate predicate;
            readonly int offset;
            readonly int count;

            internal WhereEnumerable(TList source, TPredicate predicate, int offset, int count)
            {
                this.source = source;
                this.predicate = predicate;
                (this.offset, this.count) = Utils.SkipTake(source.Count, offset, count);
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TList source;
                readonly TPredicate predicate;

                internal Enumerator(in WhereEnumerable<TList, TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
                }

                [MaybeNull]
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

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly TList source;
                readonly TPredicate predicate;

                internal DisposableEnumerator(in WhereEnumerable<TList, TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
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
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ReadOnlyListExtensions.Count<TList, TSource, TPredicate>(source, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ReadOnlyListExtensions.Any<TList, TSource, TPredicate>(source, predicate, offset, count);

            public WhereEnumerable<TList, TSource, PredicatePredicateCombination<TPredicate, ValuePredicate<TSource>, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public WhereEnumerable<TList, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => ReadOnlyListExtensions.Where<TList, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public WhereAtEnumerable<TList, TSource, PredicatePredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public WhereAtEnumerable<TList, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => ReadOnlyListExtensions.WhereAt<TList, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate> Select<TResult>(NullableSelector<TSource, TResult> selector)
            {
                if (selector is null) Throw.ArgumentNullException(nameof(selector));

                return ReadOnlyListExtensions.WhereSelect<TList, TSource, TResult, TPredicate>(source, predicate, selector, offset, count);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => ReadOnlyListExtensions.ElementAt<TList, TSource, TPredicate>(source, index, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => ReadOnlyListExtensions.First<TList, TSource, TPredicate>(source, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => ReadOnlyListExtensions.Single<TList, TSource, TPredicate>(source, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyListExtensions.ToArray<TList, TSource, TPredicate>(source, predicate, offset, count);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => ReadOnlyListExtensions.ToArray<TList, TSource, TPredicate>(source, predicate, offset, count, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyListExtensions.ToList<TList, TSource, TPredicate>(source, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TPredicate>(source, keySelector, comparer, predicate, offset, count);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ReadOnlyListExtensions.ToDictionary<TList, TSource, TKey, TElement, TPredicate>(source, keySelector, elementSelector, comparer, predicate, offset, count);
        }
    }
}

