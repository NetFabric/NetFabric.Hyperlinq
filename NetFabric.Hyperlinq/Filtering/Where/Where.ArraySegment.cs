using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereEnumerable<TSource, ValuePredicate<TSource>> Where<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return Where(source, new ValuePredicate<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicate<TSource>
            => new ArraySegmentWhereEnumerable<TSource, TPredicate>(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, ArraySegmentWhereEnumerable<TSource, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IPredicate<TSource>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;

            internal ArraySegmentWhereEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);


            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, ArraySegmentWhereEnumerable<TSource, TPredicate>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                readonly TPredicate predicate;

                internal Enumerator(in ArraySegmentWhereEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source![index];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index]))
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
                readonly TSource[]? source;
                readonly TPredicate predicate;

                internal DisposableEnumerator(in ArraySegmentWhereEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source![index];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source![index];
                readonly object? IEnumerator.Current
                    => source![index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => ArrayExtensions.Count<TSource, TPredicate>(source, predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource, TPredicate>(source, predicate);

            public ArraySegmentWhereEnumerable<TSource, PredicatePredicateCombination<TPredicate, ValuePredicate<TSource>, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public ArraySegmentWhereEnumerable<TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => ArrayExtensions.Where<TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public ArraySegmentWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public ArraySegmentWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => ArrayExtensions.WhereAt<TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate> Select<TResult>(NullableSelector<TSource, TResult> selector)
            {
                if (selector is null) Throw.ArgumentNullException(nameof(selector));

                return ArrayExtensions.WhereSelect<TSource, TResult, TPredicate>(source, predicate, selector);
            }

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt<TSource, TPredicate>(source, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.First<TSource, TPredicate>(source, predicate);

            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => ArrayExtensions.Single<TSource, TPredicate>(source, predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()

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
        }
    }
}

