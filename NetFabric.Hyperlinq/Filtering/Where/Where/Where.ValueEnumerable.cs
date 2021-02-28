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

        [GeneratorMapping("TPredicate", "NetFabric.Hyperlinq.FunctionWrapper<TSource, bool>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource, FunctionWrapper<TSource, bool>> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Where<TEnumerable, TEnumerator, TSource, FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> Where<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => new(in source, predicate);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> 
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;

            internal WhereEnumerable(in TEnumerable source, TPredicate predicate)
                => (this.source, this.predicate) = (source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                TPredicate predicate;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource, TPredicate> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                }

                public readonly TSource Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
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

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.Count<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.All<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => All(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.All<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate)
                => AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AllAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Any<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate)
                => Any(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Any<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.AnyAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, FunctionWrapper<TSource, bool>, TSource>> Where(Func<TSource, bool> predicate)
                => Where(new FunctionWrapper<TSource, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, bool>
                => source.Where<TEnumerable, TEnumerator, TSource, PredicatePredicateCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, FunctionWrapper<TSource, int, bool>, TSource>> Where(Func<TSource, int, bool> predicate)
                => WhereAt<FunctionWrapper<TSource, int, bool>>(new FunctionWrapper<TSource, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereAtEnumerable<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TSource, int, bool>
                => source.WhereAt<TEnumerable, TEnumerator, TSource, PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>>(new PredicatePredicateAtCombination<TPredicate, TPredicate2, TSource>(this.predicate, predicate));
            
            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, FunctionWrapper<TSource, TResult>> Select<TResult>(Func<TSource, TResult> selector)
                => Select<TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> Select<TResult, TSelector>(TSelector selector = default)
                where TSelector : struct, IFunction<TSource, TResult>
                => source.WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector);
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => source.ElementAt<TEnumerable, TEnumerator, TSource, TPredicate>(index, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => source.First<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => source.Single<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => source.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => source.ToArray<TEnumerable, TEnumerator, TSource, TPredicate>(predicate, memoryPool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source.ToList<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, FunctionWrapper<TSource, TKey>>(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                => source.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(keySelector, comparer, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                => source.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(keySelector, elementSelector, comparer, predicate);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, int, TPredicate> source)
            where TEnumerable : IValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IEnumerator<int>
            where TPredicate : struct, IFunction<int, bool>
            => source.source.Sum<TEnumerable, TEnumerator, int, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, int?, TPredicate> source)
            where TEnumerable : IValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IEnumerator<int?>
            where TPredicate : struct, IFunction<int?, bool>
            => source.source.Sum<TEnumerable, TEnumerator, int?, int, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, long, TPredicate> source)
            where TEnumerable : IValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IEnumerator<long>
            where TPredicate : struct, IFunction<long, bool>
            => source.source.Sum<TEnumerable, TEnumerator, long, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, long?, TPredicate> source)
            where TEnumerable : IValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IEnumerator<long?>
            where TPredicate : struct, IFunction<long?, bool>
            => source.source.Sum<TEnumerable, TEnumerator, long?, long, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, float, TPredicate> source)
            where TEnumerable : IValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IEnumerator<float>
            where TPredicate : struct, IFunction<float, bool>
            => source.source.Sum<TEnumerable, TEnumerator, float, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, float?, TPredicate> source)
            where TEnumerable : IValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IEnumerator<float?>
            where TPredicate : struct, IFunction<float?, bool>
            => source.source.Sum<TEnumerable, TEnumerator, float?, float, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, double, TPredicate> source)
            where TEnumerable : IValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IEnumerator<double>
            where TPredicate : struct, IFunction<double, bool>
            => source.source.Sum<TEnumerable, TEnumerator, double, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, double?, TPredicate> source)
            where TEnumerable : IValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IEnumerator<double?>
            where TPredicate : struct, IFunction<double?, bool>
            => source.source.Sum<TEnumerable, TEnumerator, double?, double, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, decimal, TPredicate> source)
            where TEnumerable : IValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal>
            where TPredicate : struct, IFunction<decimal, bool>
            => source.source.Sum<TEnumerable, TEnumerator, decimal, decimal, TPredicate>(source.predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TPredicate>(this WhereEnumerable<TEnumerable, TEnumerator, decimal?, TPredicate> source)
            where TEnumerable : IValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IEnumerator<decimal?>
            where TPredicate : struct, IFunction<decimal?, bool>
            => source.source.Sum<TEnumerable, TEnumerator, decimal?, decimal, TPredicate>(source.predicate);
    }
}

