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
        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static WhereEnumerable<TList, TSource, FunctionWrapper<TSource, bool>> Where<TList, TSource>(this TList source, Func<TSource, bool> predicate)
            where TList : struct, IReadOnlyList<TSource>
            => source.Where(predicate, 0, source.Count);

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereEnumerable<TList, TSource, FunctionWrapper<TSource, bool>> Where<TList, TSource>(this TList source, Func<TSource, bool> predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.Where<TList, TSource, FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate), offset, count);

        [GeneratorIgnore(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static WhereEnumerable<TList, TSource, TPredicate> Where<TList, TSource, TPredicate>(this TList source, TPredicate predicate = default)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Where<TList, TSource, TPredicate>(predicate, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereEnumerable<TList, TSource, TPredicate> Where<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => new(in source, predicate, offset, count);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereEnumerable<TList, TSource, TPredicate>
            : IValueEnumerable<TSource, WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator>
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            internal readonly TList source;
            internal readonly TPredicate predicate;
            internal readonly int offset;
            internal readonly int count;

            internal WhereEnumerable(in TList source, TPredicate predicate, int offset, int count)
                => (this.source, this.offset, this.count, this.predicate) = (source, offset, count, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TList, TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
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

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TList source;
                TPredicate predicate;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereEnumerable<TList, TSource, TPredicate> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
                }

                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => source[index];
                }

                readonly TSource IEnumerator<TSource>.Current 
                    => source[index];
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
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

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.Count<TList, TSource, TPredicate>(predicate, offset, count);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.All<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.All<TList, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AllAt<TList, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Any<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Any<TList, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AnyAt<TList, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TList, TSource, PredicatePredicateCombination<TPredicate, FunctionWrapper<TSource, bool>, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TList, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Where<TList, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TList, TSource, PredicatePredicateAtCombination<TPredicate, FunctionWrapper<TSource, int, bool>, TSource>> Where(Func<TSource, int, bool> predicate)
                => WhereAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TList, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.WhereAt<TList, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate), offset, count);
            
            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TList, TSource, TResult, TPredicate, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => Select<TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.WhereSelect<TList, TSource, TResult, TPredicate, TSelector>(predicate, selector, offset, count);
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => source.ElementAt<TList, TSource, TPredicate>(index, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => source.First<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => source.Single<TList, TSource, TPredicate>(predicate, offset, count);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.ToArray<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueMemoryOwner<TSource> ToArray(ArrayPool<TSource> pool, bool clearOnDispose = default)
                => source.ToArray(pool, clearOnDispose, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.ToList<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.ToDictionary<TList, TSource, TKey, TKeySelector, TPredicate>(keySelector, comparer, predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate, offset, count);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TPredicate>(this WhereEnumerable<TList, int, TPredicate> source)
            where TList : struct, IReadOnlyList<int>
            where TPredicate : struct, IFunction<int, bool>
            => source.source.Sum<TList, int, int, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TPredicate>(this WhereEnumerable<TList, int?, TPredicate> source)
            where TList : struct, IReadOnlyList<int?>
            where TPredicate : struct, IFunction<int?, bool>
            => source.source.Sum<TList, int?, int, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TPredicate>(this WhereEnumerable<TList, long, TPredicate> source)
            where TList : struct, IReadOnlyList<long>
            where TPredicate : struct, IFunction<long, bool>
            => source.source.Sum<TList, long, long, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TPredicate>(this WhereEnumerable<TList, long?, TPredicate> source)
            where TList : struct, IReadOnlyList<long?>
            where TPredicate : struct, IFunction<long?, bool>
            => source.source.Sum<TList, long?, long, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TPredicate>(this WhereEnumerable<TList, float, TPredicate> source)
            where TList : struct, IReadOnlyList<float>
            where TPredicate : struct, IFunction<float, bool>
            => source.source.Sum<TList, float, float, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TPredicate>(this WhereEnumerable<TList, float?, TPredicate> source)
            where TList : struct, IReadOnlyList<float?>
            where TPredicate : struct, IFunction<float?, bool>
            => source.source.Sum<TList, float?, float, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TPredicate>(this WhereEnumerable<TList, double, TPredicate> source)
            where TList : struct, IReadOnlyList<double>
            where TPredicate : struct, IFunction<double, bool>
            => source.source.Sum<TList, double, double, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TPredicate>(this WhereEnumerable<TList, double?, TPredicate> source)
            where TList : struct, IReadOnlyList<double?>
            where TPredicate : struct, IFunction<double?, bool>
            => source.source.Sum<TList, double?, double, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TPredicate>(this WhereEnumerable<TList, decimal, TPredicate> source)
            where TList : struct, IReadOnlyList<decimal>
            where TPredicate : struct, IFunction<decimal, bool>
            => source.source.Sum<TList, decimal, decimal, TPredicate>(source.predicate, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TPredicate>(this WhereEnumerable<TList, decimal?, TPredicate> source)
            where TList : struct, IReadOnlyList<decimal?>
            where TPredicate : struct, IFunction<decimal?, bool>
            => source.source.Sum<TList, decimal?, decimal, TPredicate>(source.predicate, source.offset, source.count);
    }
}

