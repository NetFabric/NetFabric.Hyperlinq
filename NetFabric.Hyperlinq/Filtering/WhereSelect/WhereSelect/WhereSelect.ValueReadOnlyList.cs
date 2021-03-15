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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector> WhereSelect<TList, TSource, TResult, TPredicate, TSelector>(
            this TList source,
            TPredicate predicate,
            TSelector selector, 
            int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(source, predicate, selector, offset, count);

        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>
            : IValueEnumerable<TResult, WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>.DisposableEnumerator>
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal readonly TList source;
            internal readonly TPredicate predicate;
            internal readonly TSelector selector;
            internal readonly int offset;
            internal readonly int count;

            internal WhereSelectEnumerable(TList source, TPredicate predicate, TSelector selector, int offset, int count)
                => (this.source, this.offset, this.count, this.predicate, this.selector) = (source, offset, count, predicate, selector);

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

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                readonly TList source;
                TPredicate predicate;
                TSelector selector;
                readonly int end;
                int index;

                internal Enumerator(in WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index]);
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
                : IEnumerator<TResult>
            {
                readonly TList source;
                TPredicate predicate;
                TSelector selector;
                readonly int end;
                int index;

                internal DisposableEnumerator(in WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.offset - 1;
                    end = index + enumerable.count;
                }

                public TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index]);
                }
                TResult IEnumerator<TResult>.Current 
                    => selector.Invoke(source[index]);
                object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source[index]);

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
            public bool All(Func<TResult, bool> predicate)
                => All(new FunctionWrapper<TResult, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.All<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TResult, int, bool> predicate)
                => AllAt(new FunctionWrapper<TResult, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.AllAt<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Any<TList, TSource, TPredicate>(predicate, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TResult, bool> predicate)
                => Any(new FunctionWrapper<TResult, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.Any<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TResult, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TResult, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.AnyAt<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereEnumerable<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, FunctionWrapper<TResult, bool>> Where(Func<TResult, bool> predicate)
                => this.Where<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereEnumerable<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TPredicate2> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.Where<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereAtEnumerable<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, FunctionWrapper<TResult, int, bool>> Where(Func<TResult, int, bool> predicate)
                => this.Where<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.WhereAtEnumerable<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TPredicate2> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.WhereAt<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TList, TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TList, TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.WhereSelect<TList, TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(predicate, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector), offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectManyEnumerable<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                => this.SelectMany<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueEnumerableExtensions.SelectManyEnumerable<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => this.SelectMany<WhereSelectEnumerable<TList, TSource, TResult, TPredicate, TSelector>, DisposableEnumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAt<TList, TSource, TResult, TPredicate, TSelector>(index, predicate, selector, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.First<TList, TSource, TResult, TPredicate, TSelector>(predicate, selector, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.Single<TList, TSource, TResult, TPredicate, TSelector>(predicate, selector, offset, count);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => source.ToArray<TList, TSource, TResult, TPredicate, TSelector>(predicate, selector, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => source.ToArray<TList, TSource, TResult, TPredicate, TSelector>(pool, predicate, selector, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => source.ToList<TList, TSource, TResult, TPredicate, TSelector>(predicate, selector, offset, count); 

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary(new FunctionWrapper<TResult, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                => source.ToDictionary<TList, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(keySelector, comparer, predicate, selector, offset, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TResult, TKey>, FunctionWrapper<TResult, TElement>>(new FunctionWrapper<TResult, TKey>(keySelector), new FunctionWrapper<TResult, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                where TElementSelector : struct, IFunction<TResult, TElement>
                => source.ToDictionary<TList, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(keySelector, elementSelector, comparer, predicate, selector, offset, count);
            
            #endregion

            public readonly bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = default)
            {
                comparer ??= EqualityComparer<TResult>.Default;

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
        public static int Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, int, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, int>
            => source.source.Sum<TList, TSource, int, int, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, int?, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, int?>
            => source.source.Sum<TList, TSource, int?, int, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, long, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, long>
            => source.source.Sum<TList, TSource, long, long, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, long?, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, long?>
            => source.source.Sum<TList, TSource, long?, long, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, float, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, float>
            => source.source.Sum<TList, TSource, float, float, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, float?, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, float?>
            => source.source.Sum<TList, TSource, float?, float, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, double, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, double>
            => source.source.Sum<TList, TSource, double, double, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, double?, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, double?>
            => source.source.Sum<TList, TSource, double?, double, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, decimal, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, decimal>
            => source.source.Sum<TList, TSource, decimal, decimal, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TList, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TList, TSource, decimal?, TPredicate, TSelector> source)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, decimal?>
            => source.source.Sum<TList, TSource, decimal?, decimal, TPredicate, TSelector>(source.predicate, source.selector, source.offset, source.count);
    }
}

