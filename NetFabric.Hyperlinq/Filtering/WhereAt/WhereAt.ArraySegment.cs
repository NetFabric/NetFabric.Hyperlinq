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
        public static ArraySegmentWhereAtEnumerable<TSource, ValuePredicateAt<TSource>> Where<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => new ArraySegmentWhereAtEnumerable<TSource, TPredicate>(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereAtEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, ArraySegmentWhereAtEnumerable<TSource, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;

            internal ArraySegmentWhereAtEnumerable(in ArraySegment<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);


            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, ArraySegmentWhereAtEnumerable<TSource, TPredicate>.DisposableEnumerator>.GetEnumerator()
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
                readonly int offset;
                readonly TSource[]? source;
                readonly TPredicate predicate;

                internal Enumerator(in ArraySegmentWhereAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source![index + offset];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index + offset], index))
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
                readonly int offset;
                readonly TSource[]? source;
                readonly TPredicate predicate;

                internal DisposableEnumerator(in ArraySegmentWhereAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source![index + offset];
                }
                readonly TSource IEnumerator<TSource>.Current
                    => source![index + offset];
                readonly object? IEnumerator.Current
                    => source![index + offset];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index + offset], index))
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
                => ArrayExtensions.CountAt<TSource, TPredicate>(source, predicate);

            public bool Any()
                => ArrayExtensions.AnyAt<TSource, TPredicate>(source, predicate);

            public ArraySegmentWhereAtEnumerable<TSource, PredicatePredicateAtCombination<ValuePredicate<TSource>, TPredicate, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public ArraySegmentWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => WhereAt<TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            public ArraySegmentWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public ArraySegmentWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => WhereAt<TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAtAt<TSource, TPredicate>(source, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.FirstAt<TSource, TPredicate>(source, predicate);

#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            public Option<TSource> Single()
                => ArrayExtensions.SingleAt<TSource, TPredicate>(source, predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()

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
        }
    }
}

