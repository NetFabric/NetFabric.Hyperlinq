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
        static ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector> WhereSelect<TSource, TResult, TPredicate, TSelector>(
            this in ArraySegment<TSource> source, 
            TPredicate predicate, 
            TSelector selector) 
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(source, predicate, selector);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>
            : IValueEnumerable<TResult, ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>.Enumerator>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly TPredicate predicate;
            internal readonly TSelector selector;

            internal ArraySegmentWhereSelectEnumerable(in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
                => (this.source, this.predicate, this.selector) = (source, predicate, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public WhereSelectEnumerator<TSource, TResult, TPredicate, TSelector> GetEnumerator() 
                => new(source.AsSpan(), predicate, selector);

            Enumerator IValueEnumerable<TResult, Enumerator>.GetEnumerator() 
                => new(in this);

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
                readonly TSource[]? source;
#pragma warning disable IDE0044 // Add readonly modifier
                TPredicate predicate;
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    selector = enumerable.selector;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TResult Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source![index]);
                }
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(source![index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var index = this.index;
                    while (++index <= end)
                    {
                        if (predicate.Invoke(source![index]))
                        {
                            this.index = index;
                            return true;
                        }
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }                
            }

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.AsReadOnlySpan().Count(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TResult, bool> predicate)
                => Count(new FunctionWrapper<TResult, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => ValueEnumerableExtensions.Count<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(this, predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count(Func<TResult, int, bool> predicate)
                => CountAt(new FunctionWrapper<TResult, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => ValueEnumerableExtensions.CountAt<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(this, predicate);

            #endregion
            #region Quantifier


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.AsReadOnlySpan().All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TResult, bool> predicate)
                => All(new FunctionWrapper<TResult, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.All<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TResult, int, bool> predicate)
                => AllAt(new FunctionWrapper<TResult, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AllAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.AllAt<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.AsReadOnlySpan().Any(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TResult, bool> predicate)
                => Any(new FunctionWrapper<TResult, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.Any<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TResult, int, bool> predicate)
                => AnyAt(new FunctionWrapper<TResult, int, bool>(predicate));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool AnyAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.AnyAt<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Filtering

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.WhereEnumerable<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2> Where<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, bool>
                => this.Where<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.WhereAtEnumerable<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2> WhereAt<TPredicate2>(TPredicate2 predicate = default)
                where TPredicate2 : struct, IFunction<TResult, int, bool>
                => this.WhereAt<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TPredicate2>(predicate);

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ArraySegmentWhereSelectEnumerable<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.WhereSelect<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(predicate, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.SelectManyEnumerable<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => this.SelectMany<ArraySegmentWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.AsReadOnlySpan().ElementAt<TSource, TResult, TPredicate, TSelector>(index, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.AsReadOnlySpan().First<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.AsReadOnlySpan().Single<TSource, TResult, TPredicate, TSelector>(predicate, selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => source.AsReadOnlySpan().ToArray<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => ((ReadOnlySpan<TSource>)source.AsSpan()).ToArray(pool, clearOnDispose, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => source.AsReadOnlySpan().ToList<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary(new FunctionWrapper<TResult, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                => source.AsReadOnlySpan().ToDictionary<TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(keySelector, comparer, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TResult, TKey>, FunctionWrapper<TResult, TElement>>(new FunctionWrapper<TResult, TKey>(keySelector), new FunctionWrapper<TResult, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                where TElementSelector : struct, IFunction<TResult, TElement>
                => source.AsReadOnlySpan().ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(keySelector, elementSelector, comparer, predicate, selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, int, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, int>
            => source.source.AsReadOnlySpan().Sum<TSource, int, int, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, int?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, int?>
            => source.source.AsReadOnlySpan().Sum<TSource, int?, int, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, nint, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nint>
            => source.source.AsReadOnlySpan().Sum<TSource, nint, nint, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, nint?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nint?>
            => source.source.AsReadOnlySpan().Sum<TSource, nint?, nint, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, nuint, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nuint>
            => source.source.AsReadOnlySpan().Sum<TSource, nuint, nuint, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, nuint?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nuint?>
            => source.source.AsReadOnlySpan().Sum<TSource, nuint?, nuint, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, long, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, long>
            => source.source.AsReadOnlySpan().Sum<TSource, long, long, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, long?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, long?>
            => source.source.AsReadOnlySpan().Sum<TSource, long?, long, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, float, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, float>
            => source.source.AsReadOnlySpan().Sum<TSource, float, float, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, float?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, float?>
            => source.source.AsReadOnlySpan().Sum<TSource, float?, float, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, double, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, double>
            => source.source.AsReadOnlySpan().Sum<TSource, double, double, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, double?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, double?>
            => source.source.AsReadOnlySpan().Sum<TSource, double?, double, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, decimal, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, decimal>
            => source.source.AsReadOnlySpan().Sum<TSource, decimal, decimal, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TPredicate, TSelector>(this ArraySegmentWhereSelectEnumerable<TSource, decimal?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, decimal?>
            => source.source.AsReadOnlySpan().Sum<TSource, decimal?, decimal, TPredicate, TSelector>(source.predicate, source.selector);
    }
}

