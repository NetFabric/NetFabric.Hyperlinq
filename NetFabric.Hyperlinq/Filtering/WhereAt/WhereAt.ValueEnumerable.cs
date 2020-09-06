using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereAtEnumerable<TEnumerable, TEnumerator, TSource, ValuePredicateAt<TSource>> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, PredicateAt<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt<TEnumerable, TEnumerator, TSource, ValuePredicateAt<TSource>>(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> WhereAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
            => new WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> 
            : IValueEnumerable<TSource, WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.Enumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;

            internal WhereAtEnumerable(TEnumerable source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                int index;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly TPredicate predicate;

                internal Enumerator(in WhereAtEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = -1;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current 
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    checked
                    {
                        while (enumerator.MoveNext())
                        {
                            if (predicate.Invoke(enumerator.Current, ++index))
                                return true;
                        }
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            public int Count()
                => ValueEnumerableExtensions.CountAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public bool Any()
                => ValueEnumerableExtensions.AnyAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<ValuePredicate<TSource>, TPredicate, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null)
                    Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => WhereAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicateAtPredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null)
                    Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => WhereAt<TEnumerable, TEnumerator, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ValueEnumerableExtensions.ElementAtAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, index, predicate);

            public Option<TSource> First()
                => ValueEnumerableExtensions.FirstAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public Option<TSource> Single()
                => ValueEnumerableExtensions.SingleAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public TSource[] ToArray()
                => ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => ValueEnumerableExtensions.ToArrayAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, pool);

            public List<TSource> ToList()
                => ValueEnumerableExtensions.ToListAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ValueEnumerableExtensions.ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TPredicate>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ValueEnumerableExtensions.ToDictionaryAt<TEnumerable, TEnumerator, TSource, TKey, TElement, TPredicate>(source, keySelector, elementSelector, comparer, predicate);
        }
    }
}

