using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> WhereSelect<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(
            this TEnumerable source, 
            TPredicate predicate,
            TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, predicate, selector);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector> 
            : IValueEnumerable<TResult, WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>.Enumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal readonly TEnumerable source;
            internal readonly TPredicate predicate;
            internal readonly TSelector selector;

            internal WhereSelectEnumerable(in TEnumerable source, TPredicate predicate, TSelector selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() => 
                new(in this);

            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
                TPredicate predicate;
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier

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
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => enumerator.Dispose();
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => ValueReadOnlyCollectionExtensions.Count<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => ValueEnumerableExtensions.Count<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => ValueEnumerableExtensions.CountAt<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(this, predicate);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => ValueReadOnlyCollectionExtensions.All<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.All<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.AllAt<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => ValueReadOnlyCollectionExtensions.Any<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.Any<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.AnyAt<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.WhereEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => ValueEnumerableExtensions.Where<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.WhereAtEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => ValueEnumerableExtensions.WhereAt<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(this, predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => WhereSelect<TEnumerable, TEnumerator, TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, predicate, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.SelectManyEnumerable<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => ValueEnumerableExtensions.SelectMany<WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(this, selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ValueReadOnlyCollectionExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, index, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ValueReadOnlyCollectionExtensions.First<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ValueReadOnlyCollectionExtensions.Single<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ValueReadOnlyCollectionExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => ValueReadOnlyCollectionExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, pool, clearOnDispose, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ValueReadOnlyCollectionExtensions.ToList<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(source, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                => ValueReadOnlyCollectionExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(source, keySelector, comparer, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                where TElementSelector : struct, IFunction<TResult, TElement>
                => ValueReadOnlyCollectionExtensions.ToDictionary<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(source, keySelector, elementSelector, comparer, predicate, selector);
             
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, int, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, int>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, int, int, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, int?, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, int?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, int?, int, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, nint, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nint>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, nint, nint, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, nint?, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nint?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, nint?, nint, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, nuint, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nuint>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, nuint, nuint, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, nuint?, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nuint?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, nuint?, nuint, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, long, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, long>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, long, long, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, long?, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, long?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, long?, long, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, float, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, float>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, float, float, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, float?, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, float?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, float?, float, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, double, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, double>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, double, double, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, double?, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, double?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, double?, double, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, decimal, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, decimal>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, decimal, decimal, TPredicate, TSelector>(source.source, source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TPredicate, TSelector>(this WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, decimal?, TPredicate, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, decimal?>
            => ValueReadOnlyCollectionExtensions.Sum<TEnumerable, TEnumerator, TSource, decimal?, decimal, TPredicate, TSelector>(source.source, source.predicate, source.selector);
    }
}

