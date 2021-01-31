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
            : IValueEnumerable<TResult, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator>
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly TPredicate predicate;
            readonly TSelector selector;

            internal ArraySegmentWhereSelectRefEnumerable(ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly DisposableEnumerator IValueEnumerable<TResult, DisposableEnumerator>.GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                TPredicate predicate;
                TSelector selector;

                internal Enumerator(in ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public TResult Current 
                    => selector.Invoke(in source![index]);

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
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int index;
                readonly int end;
                readonly TSource[]? source;
                TPredicate predicate;
                TSelector selector;

                internal DisposableEnumerator(in ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public TResult Current 
                    => selector.Invoke(in source![index]);
                TResult IEnumerator<TResult>.Current 
                    => selector.Invoke(in source![index]);
                object? IEnumerator.Current
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
                => source.CountRef(predicate);

            #endregion
            #region Quantifier


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.AllRef(predicate);

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
            //    => this.Where<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult>(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.WhereRefEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2> Where<TPredicate2>(TPredicate2 predicate = default)
            //    where TPredicate2 : struct, IFunctionIn<TResult, bool>
            //    => this.WhereRef<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2>(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.WhereAtRefEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, FunctionInWrapper<TResult, int, bool>> Where(FunctionIn<TResult, int, bool> predicate)
            //    => this.Where<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult>(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.WhereAtRefEnumerable<ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectRefEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2> WhereAt<TPredicate2>(TPredicate2 predicate = default)
            //    where TPredicate2 : struct, IFunctionIn<TResult, int, bool>
            //    => this.WhereAtRef<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Projection

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentWhereSelectEnumerable<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, FunctionInWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            //    => Select<TResult2, FunctionInWrapper<TResult, TResult2>>(new FunctionInWrapper<TResult, TResult2>(selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public ArraySegmentWhereSelectEnumerable<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunctionIn<TResult, TResult2>
            //    => source.WhereSelect<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(predicate, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.SelectManyEnumerable<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionInWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    => this.SelectMany<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ValueEnumerableExtensions.SelectManyEnumerable<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    where TSelector2 : struct, IFunctionIn<TResult, TSubEnumerable>
            //    => this.SelectMany<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

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
                => source.ToArrayRef<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> memoryPool)
                => source.ToArrayRef(predicate, selector, memoryPool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => source.ToListRef<TSource, TResult, TPredicate, TSelector>(predicate, selector);

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
    }
}

