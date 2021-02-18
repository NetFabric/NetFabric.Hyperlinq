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
        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector> WhereSelectRef<TSource, TResult, TPredicate, TSelector>(
            this ArraySegment<TSource> source, 
            TPredicate predicate, 
            TSelector selector) 
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => new(source, predicate, selector);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>
            : IValueEnumerable<TResult, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.Enumerator>
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;
            internal readonly TSelector selector;

            internal ArraySegmentWhereSelectRefEnumerable(ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly WhereSelectRefEnumerator<TSource, TResult, TPredicate, TSelector> GetEnumerator() 
                => new(source.AsSpan(), predicate, selector);
            readonly Enumerator IValueEnumerable<TResult, Enumerator>.GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly TSource[]? source;
                TPredicate predicate;
                TSelector selector;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TResult Current 
                    => selector.Invoke(in source![index]);
                readonly TResult IEnumerator<TResult>.Current 
                    => selector.Invoke(in source![index]);
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(in source![index])!;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate.Invoke(in source![index]))
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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).CountRef(predicate);

            #endregion
            #region Quantifier


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).AllRef(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool All(Func<TResult, bool> predicate)
            //    => All(new FunctionInWrapper<TResult, bool>(predicate));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool All<TPredicate2>(TPredicate2 predicate)
            //    where TPredicate2 : struct, IFunctionIn<TResult, bool>
            //    => this.AllRef<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2>(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool All(Func<TResult, int, bool> predicate)
            //    => AllAt(new FunctionInWrapper<TResult, int, bool>(predicate));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool AllAt<TPredicate2>(TPredicate2 predicate)
            //    where TPredicate2 : struct, IFunctionIn<TResult, int, bool>
            //    => this.AllAt<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.AnyRef(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool Any(Func<TResult, bool> predicate)
            //    => Any(new FunctionInWrapper<TResult, bool>(predicate));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool Any<TPredicate2>(TPredicate2 predicate)
            //    where TPredicate2 : struct, IFunctionIn<TResult, bool>
            //    => this.AnyRef<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2>(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool Any(Func<TResult, int, bool> predicate)
            //    => AnyAt(new FunctionInWrapper<TResult, int, bool>(predicate));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool AnyAt<TPredicate2>(TPredicate2 predicate)
            //    where TPredicate2 : struct, IFunctionIn<TResult, int, bool>
            //    => this.AnyAtRef<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Filtering

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.WhereRefEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, FunctionInWrapper<TResult, bool>> Where(FunctionIn<TResult, bool> predicate)
            //    => this.Where<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult>(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.WhereRefEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2> Where<TPredicate2>(TPredicate2 predicate = default)
            //    where TPredicate2 : struct, IFunctionIn<TResult, bool>
            //    => this.WhereRef<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2>(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.WhereAtRefEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, FunctionInWrapper<TResult, int, bool>> Where(FunctionIn<TResult, int, bool> predicate)
            //    => this.Where<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult>(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.WhereAtRefEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2> WhereAt<TPredicate2>(TPredicate2 predicate = default)
            //    where TPredicate2 : struct, IFunctionIn<TResult, int, bool>
            //    => this.WhereAtRef<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Projection

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentWhereSelectRefEnumerable<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, FunctionInWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            //    => Select<TResult2, FunctionInWrapper<TResult, TResult2>>(new FunctionInWrapper<TResult, TResult2>(selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentWhereSelectRefEnumerable<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunctionIn<TResult, TResult2>
            //    => source.WhereSelect<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(predicate, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.SelectManyEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionInWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    => this.SelectMany<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.SelectManyEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    where TSelector2 : struct, IFunctionIn<TResult, TSubEnumerable>
            //    => this.SelectMany<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            #endregion
            #region Element

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> ElementAt(int index)
            //    => source.ElementAtRef<TSource, TResult, TPredicate, TSelector>(index, predicate, selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> First()
            //    => source.FirstRef<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> Single()
            //    => source.SingleRef<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayRef<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> memoryPool)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArrayRef(predicate, selector, memoryPool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToListRef<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            //    where TKey : notnull
            //    => ToDictionary<TKey, FunctionInWrapper<TResult, TKey>>(new FunctionInWrapper<TResult, TKey>(keySelector), comparer);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Dictionary<TKey, TResult> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            //    where TKey : notnull
            //    where TKeySelector : struct, IFunctionIn<TResult, TKey>
            //    => source.ToDictionary<TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(keySelector, comparer, predicate, selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            //    where TKey : notnull
            //    => ToDictionary<TKey, TElement, FunctionInWrapper<TResult, TKey>, FunctionInWrapper<TResult, TElement>>(new FunctionInWrapper<TResult, TKey>(keySelector), new FunctionInWrapper<TResult, TElement>(elementSelector), comparer);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            //    where TKey : notnull
            //    where TKeySelector : struct, IFunctionIn<TResult, TKey>
            //    where TElementSelector : struct, IFunctionIn<TResult, TElement>
            //    => source.ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(keySelector, elementSelector, comparer, predicate, selector);

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, int, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, int>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, int, int, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, int?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, int?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, int?, int, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, long, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, long>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, long, long, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, long?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, long?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, long?, long, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, float, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, float>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, float, float, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, float?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, float?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, float?, float, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, double, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, double>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, double, double, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, double?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, double?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, double?, double, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, decimal, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, decimal>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, decimal, decimal, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectRefEnumerable<TSource, decimal?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, decimal?>
            => ((ReadOnlySpan<TSource>)source.source.AsSpan()).SumRef<TSource, decimal?, decimal, TPredicate, TSelector>(source.predicate, source.selector);
    }
}

