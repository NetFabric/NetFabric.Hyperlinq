﻿using System;
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

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(this ReadOnlyMemory<TSource> source, Func<TSource, int, bool> predicate) 
            => source.WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate = default) 
            where TPredicate : struct, IFunction<TSource, int, bool>
            => new(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct MemoryWhereAtEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, MemoryWhereAtEnumerable<TSource, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            readonly ReadOnlyMemory<TSource> source;
            readonly TPredicate predicate;

            internal MemoryWhereAtEnumerable(ReadOnlyMemory<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);
            
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator 
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                TPredicate predicate;

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
                TPredicate predicate;

                internal DisposableEnumerator(in MemoryWhereAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source.Span[index];
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => source.Span[index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
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

            #region Aggregation

            public int Count()
                => source.Span.CountAt(predicate);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.Span.AllAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Span.AllAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.Span.AllAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Span.AnyAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Span.AnyAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.Span.AnyAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereAtEnumerable<TSource, PredicatePredicateAtCombination<FunctionWrapper<TSource, bool>, TPredicate, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereAtEnumerable<TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.WhereAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, FunctionWrapper<TSource, int, bool>, TSource>> Where(Func<TSource, int, bool> predicate)
                => WhereAt<FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MemoryWhereAtEnumerable<TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.WhereAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Projection
            
            #endregion
            #region Element

            public Option<TSource> ElementAt(int index)
                => source.Span.ElementAtAt(index, predicate);

            public Option<TSource> First()
                => source.Span.FirstAt(predicate);

            public Option<TSource> Single()
                => source.Span.SingleAt(predicate);
            
            #endregion
            #region Conversion

            public TSource[] ToArray()
                => source.ToArrayAt(predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => source.ToArrayAt(predicate, memoryPool);

            public List<TSource> ToList()
                => source.ToListAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionaryAt<TKey, FunctionWrapper<TSource, TKey>>(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionaryAt<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.Span.ToDictionaryAt(keySelector, comparer, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionaryAt<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionaryAt<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.Span.ToDictionaryAt<TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate);
            
            #endregion

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

