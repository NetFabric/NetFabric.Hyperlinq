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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(
            this TEnumerable source, 
            TPredicate predicate,
            TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, predicate, selector);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> 
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly TEnumerable source;
            readonly TPredicate predicate;
            readonly TSelector selector;

            internal WhereSelectEnumerable(in TEnumerable source, TPredicate predicate, TSelector selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => 
                new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                TPredicate predicate;
                TSelector selector;

                internal Enumerator(in WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(enumerator.Current);
                }
                TResult IEnumerator<TResult>.Current 
                    => selector.Invoke(enumerator.Current);
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(enumerator.Current);

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
            public bool All(Func<TResult, bool> predicate)
                => All(new FunctionWrapper<TResult, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.All<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TResult, int, bool> predicate)
                => AllAt(new FunctionWrapper<TResult, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.AllAt<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Any<TEnumerable, TEnumerator, TSource, TPredicate>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TResult, bool> predicate)
                => Any(new FunctionWrapper<TResult, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.Any<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TResult, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TResult, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.AnyAt<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly WhereEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, FunctionWrapper<TResult, bool>> Where(Func<TResult, bool> predicate)
                => this.Where<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly WhereEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TPredicate2> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.Where<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly WhereAtEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, FunctionWrapper<TResult, int, bool>> Where(Func<TResult, int, bool> predicate)
                => this.Where<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly WhereAtEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TPredicate2> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.WhereAt<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.WhereSelect<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(predicate, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectManyEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                => this.SelectMany<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SelectManyEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => this.SelectMany<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAt<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(index, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.First<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.Single<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => source.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => source.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector, pool);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => source.ToList<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, FunctionWrapper<TResult, TKey>>(new FunctionWrapper<TResult, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                => source.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(keySelector, comparer, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TResult, TKey>, FunctionWrapper<TResult, TElement>>(new FunctionWrapper<TResult, TKey>(keySelector), new FunctionWrapper<TResult, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                where TElementSelector : struct, IFunction<TResult, TElement>
                => source.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(keySelector, elementSelector, comparer, predicate, selector);
             
            #endregion
        }
    }
}

