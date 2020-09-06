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
        public static MemoryWhereAtEnumerable<TSource, ValuePredicateAt<TSource>> Where<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate) 
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return WhereAt(source, new ValuePredicateAt<TSource>(predicate));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IPredicateAt<TSource>
            => new MemoryWhereAtEnumerable<TSource, TPredicate>(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct MemoryWhereAtEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, MemoryWhereAtEnumerable<TSource, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly TPredicate predicate;

            internal MemoryWhereAtEnumerable(ReadOnlyMemory<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);


            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, MemoryWhereAtEnumerable<TSource, TPredicate>.DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator 
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                readonly TPredicate predicate;

                internal Enumerator(in MemoryWhereAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source.Span;
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

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator 
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly ReadOnlyMemory<TSource> source;
                readonly TPredicate predicate;

                internal DisposableEnumerator(in MemoryWhereAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                [MaybeNull]
                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source.Span[index];
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => source.Span[index];
                readonly object? IEnumerator.Current 
                    => source.Span[index];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var span = source.Span;
                    while (++index <= end)
                    {
                        if (predicate.Invoke(span[index], index))
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
                => source.Span.CountAt<TSource, TPredicate>(predicate);

            public bool Any()
                => source.Span.AnyAt<TSource, TPredicate>(predicate);

            public MemoryWhereAtEnumerable<TSource, PredicatePredicateAtCombination<ValuePredicate<TSource>, TPredicate, TSource>> Where(Predicate<TSource> predicate)
            {
                if (predicate is null)
                    Throw.ArgumentNullException(nameof(predicate));

                return this.Where(new ValuePredicate<TSource>(predicate));
            }

            public MemoryWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicate<TSource>
                => WhereAt<TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(source, new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            public MemoryWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, ValuePredicateAt<TSource>, TSource>> Where(PredicateAt<TSource> predicate)
            {
                if (predicate is null)
                    Throw.ArgumentNullException(nameof(predicate));

                return this.WhereAt(new ValuePredicateAt<TSource>(predicate));
            }

            public MemoryWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IPredicateAt<TSource>
                => WhereAt<TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(source, new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAtAt<TSource, TPredicate>(source.Span, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.FirstAt<TSource, TPredicate>(source.Span, predicate);

            public Option<TSource> Single()
                => ArrayExtensions.SingleAt<TSource, TPredicate>(source.Span, predicate);

            public TSource[] ToArray()
                => ArrayExtensions.ToArrayAt<TSource, TPredicate>(source.Span, predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => ArrayExtensions.ToArrayAt<TSource, TPredicate>(source, predicate, memoryPool);

            public List<TSource> ToList()
                => ArrayExtensions.ToListAt<TSource, TPredicate>(source, predicate);  // memory performs best

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

