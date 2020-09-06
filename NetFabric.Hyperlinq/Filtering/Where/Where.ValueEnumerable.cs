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
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource, ValuePredicate<TSource>> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Predicate<TSource> predicate)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Where<TEnumerable, TEnumerator, TSource, ValuePredicate<TSource>>(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> Where<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
            => new WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> 
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.Enumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;

            internal WhereEnumerable(TEnumerable source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly TPredicate predicate;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
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
                    while (enumerator.MoveNext())
                    {
                        if (predicate.Invoke(enumerator.Current))
                            return true;
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
                => ValueEnumerableExtensions.Count<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public bool Any()
                => ValueEnumerableExtensions.Any<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public WhereEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, ValuePredicate<TSource>, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public WhereEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => ValueEnumerableExtensions.Where<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => ValueEnumerableExtensions.WhereAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public ValueEnumerableExtensions.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate> Select<TResult>(NullableSelector<TSource, TResult> selector)
                => ValueEnumerableExtensions.WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(source, predicate, selector);

            public Option<TSource> ElementAt(int index)
                => ValueEnumerableExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, index, predicate);

            public Option<TSource> First()
                => ValueEnumerableExtensions.First<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public Option<TSource> Single()
                => ValueEnumerableExtensions.Single<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);
                
            public TSource[] ToArray()
                => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> pool)
                => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate, pool);

            public List<TSource> ToList()
                => ValueEnumerableExtensions.ToList<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TPredicate>(source, keySelector, comparer, predicate);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ValueEnumerableExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TPredicate>(source, keySelector, elementSelector, comparer, predicate);
        }
    }
}

