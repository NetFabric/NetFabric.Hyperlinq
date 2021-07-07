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
        static MemoryWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(this ReadOnlyMemory<TSource> source, Func<TSource, int, bool> predicate) 
            => source.WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemoryWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate = default) 
            where TPredicate : struct, IFunction<TSource, int, bool>
            => new(source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct MemoryWhereAtEnumerable<TSource, TPredicate>
            : IValueEnumerable<TSource, MemoryWhereAtEnumerable<TSource, TPredicate>.DisposableEnumerator>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal readonly TPredicate predicate;

            internal MemoryWhereAtEnumerable(ReadOnlyMemory<TSource> source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);
            
            public WhereAtEnumerator<TSource, TPredicate> GetEnumerator() 
                => new(source.Span, predicate);

            DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() 
                => new(in this);

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator 
                : IEnumerator<TSource>
            {
                readonly ReadOnlyMemory<TSource> source;
                TPredicate predicate;
                int index;

                internal DisposableEnumerator(in MemoryWhereAtEnumerable<TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = -1;
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
                    while (++index < span.Length)
                    {
                        var item = span[index];
                        if (predicate.Invoke(item, index))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            #region Aggregation

            public int Count()
                => source.Span.CountAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TSource, bool> predicate)
                => Count(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Span.CountAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TSource, int, bool> predicate)
                => CountAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.Span.CountAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.Span.AllAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Span.AllAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.Span.AllAt(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Span.AnyAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Span.AnyAt(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate = default)
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
                => WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));

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
                => source.Span.ToArrayAt(predicate);

            public Lease<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => source.Span.ToArrayAt(pool, clearOnDispose, predicate);

            public List<TSource> ToList()
                => source.Span.ToListAt(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionaryAt(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

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
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this MemoryWhereAtEnumerable<int, TPredicate> source)
            where TPredicate : struct, IFunction<int, int, bool>
            => source.source.Span.SumAt<int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TPredicate>(this MemoryWhereAtEnumerable<int?, TPredicate> source)
            where TPredicate : struct, IFunction<int?, int, bool>
            => source.source.Span.SumAt<int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TPredicate>(this MemoryWhereAtEnumerable<nint, TPredicate> source)
            where TPredicate : struct, IFunction<nint, int, bool>
            => source.source.Span.SumAt<nint, nint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TPredicate>(this MemoryWhereAtEnumerable<nint?, TPredicate> source)
            where TPredicate : struct, IFunction<nint?, int, bool>
            => source.source.Span.SumAt<nint?, nint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TPredicate>(this MemoryWhereAtEnumerable<nuint, TPredicate> source)
            where TPredicate : struct, IFunction<nuint, int, bool>
            => source.source.Span.SumAt<nuint, nuint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TPredicate>(this MemoryWhereAtEnumerable<nuint?, TPredicate> source)
            where TPredicate : struct, IFunction<nuint?, int, bool>
            => source.source.Span.SumAt<nuint?, nuint, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this MemoryWhereAtEnumerable<long, TPredicate> source)
            where TPredicate : struct, IFunction<long, int, bool>
            => source.source.Span.SumAt<long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TPredicate>(this MemoryWhereAtEnumerable<long?, TPredicate> source)
            where TPredicate : struct, IFunction<long?, int, bool>
            => source.source.Span.SumAt<long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this MemoryWhereAtEnumerable<float, TPredicate> source)
            where TPredicate : struct, IFunction<float, int, bool>
            => source.source.Span.SumAt<float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TPredicate>(this MemoryWhereAtEnumerable<float?, TPredicate> source)
            where TPredicate : struct, IFunction<float?, int, bool>
            => source.source.Span.SumAt<float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this MemoryWhereAtEnumerable<double, TPredicate> source)
            where TPredicate : struct, IFunction<double, int, bool>
            => source.source.Span.SumAt<double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TPredicate>(this MemoryWhereAtEnumerable<double?, TPredicate> source)
            where TPredicate : struct, IFunction<double?, int, bool>
            => source.source.Span.SumAt<double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this MemoryWhereAtEnumerable<decimal, TPredicate> source)
            where TPredicate : struct, IFunction<decimal, int, bool>
            => source.source.Span.SumAt<decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TPredicate>(this MemoryWhereAtEnumerable<decimal?, TPredicate> source)
            where TPredicate : struct, IFunction<decimal?, int, bool>
            => source.source.Span.SumAt<decimal?, decimal, TPredicate>(source.predicate);
    }
}

