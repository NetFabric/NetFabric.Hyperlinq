using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {

        [GeneratorIgnore(false)]
        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static WhereAtEnumerable<TList, TSource, FunctionWrapper<TSource, int, bool>> Where<TList, TSource>(this TList source, Func<TSource, int, bool> predicate)
            where TList : struct, IReadOnlyList<TSource>
            => source.Where(predicate, 0, source.Count);

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, int, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereAtEnumerable<TList, TSource, FunctionWrapper<TSource, int, bool>> Where<TList, TSource>(this TList source, Func<TSource, int, bool> predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.WhereAt<TList, TSource, FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate), offset, count);

        [GeneratorIgnore(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static WhereAtEnumerable<TList, TSource, TPredicate> WhereAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate = default)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.WhereAt<TList, TSource, TPredicate>(predicate, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereAtEnumerable<TList, TSource, TPredicate> WhereAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
            => new(in source, predicate, offset, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereAtEnumerable<TList, TSource, TPredicate>
            : IValueEnumerable<TSource, WhereAtEnumerable<TList, TSource, TPredicate>.DisposableEnumerator>
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            internal readonly TList source;
            internal readonly TPredicate predicate;
            internal readonly int offset;
            internal readonly int count;

            internal WhereAtEnumerable(in TList source, TPredicate predicate, int offset, int count)
                => (this.source, this.offset, this.count, this.predicate) = (source, offset, count, predicate);
            
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

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                readonly TList source;
                TPredicate predicate;
                readonly int offset;
                readonly int end;
                int index;

                internal Enumerator(in WhereAtEnumerable<TList, TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index + offset];
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index + offset], index))
                            return true;
                    }
                    return false;
                }
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                TPredicate predicate;
                readonly int offset;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereAtEnumerable<TList, TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    offset = enumerable.offset;
                    index = -1;
                    end = index + enumerable.count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index + offset];
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => source[index + offset];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => source[index + offset];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source[index + offset], index))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.CountAt<TList, TSource, TPredicate>(predicate, offset, count);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.AllAt<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.AllAt<TList, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AllAt<TList, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.AnyAt<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.AnyAt<TList, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AnyAt<TList, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TList, TSource, PredicatePredicateAtCombination<FunctionWrapper<TSource, bool>, TPredicate, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TList, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.WhereAt<TList, TSource, PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>>(new PredicatePredicateAtCombination<TPredicate2, TPredicate, TSource>(predicate, this.predicate), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TList, TSource, PredicateAtPredicateAtCombination<TPredicate, FunctionWrapper<TSource, int, bool>, TSource>> Where(Func<TSource, int, bool> predicate)
                => WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TList, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.WhereAt<TList, TSource, PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicateAtPredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);
            
            #endregion
            #region Projection
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => source.ElementAtAt<TList, TSource, TPredicate>(index, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => source.FirstAt<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => source.SingleAt<TList, TSource, TPredicate>(predicate, offset, count);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.ToArrayAt<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueMemoryOwner<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => source.ToArrayAt(pool, clearOnDispose, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.ToListAt<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionaryAt(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionaryAt<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.ToDictionaryAt<TList, TSource, TKey, TKeySelector, TPredicate>(keySelector, comparer, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionaryAt<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionaryAt<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.ToDictionaryAt<TList, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate, offset, count);
            
            #endregion

            public readonly bool SequenceEqual(IEnumerable<TSource> other, IEqualityComparer<TSource>? comparer = default)
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

                    if (!comparer.Equals(enumerator.Current!, otherEnumerator.Current))
                        return false;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TPredicate>(this WhereAtEnumerable<TList, int, TPredicate> source)
            where TList : struct, IReadOnlyList<int>
            where TPredicate : struct, IFunction<int, int, bool>
            => source.source.SumAt<TList, int, int, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TPredicate>(this WhereAtEnumerable<TList, int?, TPredicate> source)
            where TList : struct, IReadOnlyList<int?>
            where TPredicate : struct, IFunction<int?, int, bool>
            => source.source.SumAt<TList, int?, int, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TPredicate>(this WhereAtEnumerable<TList, long, TPredicate> source)
            where TList : struct, IReadOnlyList<long>
            where TPredicate : struct, IFunction<long, int, bool>
            => source.source.SumAt<TList, long, long, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TPredicate>(this WhereAtEnumerable<TList, long?, TPredicate> source)
            where TList : struct, IReadOnlyList<long?>
            where TPredicate : struct, IFunction<long?, int, bool>
            => source.source.SumAt<TList, long?, long, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TPredicate>(this WhereAtEnumerable<TList, float, TPredicate> source)
            where TList : struct, IReadOnlyList<float>
            where TPredicate : struct, IFunction<float, int, bool>
            => source.source.SumAt<TList, float, float, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TPredicate>(this WhereAtEnumerable<TList, float?, TPredicate> source)
            where TList : struct, IReadOnlyList<float?>
            where TPredicate : struct, IFunction<float?, int, bool>
            => source.source.SumAt<TList, float?, float, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TPredicate>(this WhereAtEnumerable<TList, double, TPredicate> source)
            where TList : struct, IReadOnlyList<double>
            where TPredicate : struct, IFunction<double, int, bool>
            => source.source.SumAt<TList, double, double, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TPredicate>(this WhereAtEnumerable<TList, double?, TPredicate> source)
            where TList : struct, IReadOnlyList<double?>
            where TPredicate : struct, IFunction<double?, int, bool>
            => source.source.SumAt<TList, double?, double, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TPredicate>(this WhereAtEnumerable<TList, decimal, TPredicate> source)
            where TList : struct, IReadOnlyList<decimal>
            where TPredicate : struct, IFunction<decimal, int, bool>
            => source.source.SumAt<TList, decimal, decimal, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TPredicate>(this WhereAtEnumerable<TList, decimal?, TPredicate> source)
            where TList : struct, IReadOnlyList<decimal?>
            where TPredicate : struct, IFunction<decimal?, int, bool>
            => source.source.SumAt<TList, decimal?, decimal, TPredicate>(source.predicate, source.offset, source.count);
    }
}

