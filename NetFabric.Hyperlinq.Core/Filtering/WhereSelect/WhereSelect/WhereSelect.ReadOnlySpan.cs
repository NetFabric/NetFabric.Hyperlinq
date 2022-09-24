using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector> WhereSelect<TSource, TResult, TPredicate, TSelector>(
            this ReadOnlySpan<TSource> source, 
            TPredicate predicate, 
            TSelector selector) 
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(source, predicate, selector);

        [StructLayout(LayoutKind.Auto)]
        public readonly ref struct SpanWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly TPredicate predicate;
            internal readonly TSelector selector;

            internal SpanWhereSelectEnumerable(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            {
                this.source = source;
                this.predicate = predicate;
                this.selector = selector;
            }
            
            public WhereSelectEnumerator<TSource, TResult, TPredicate, TSelector> GetEnumerator() 
                => new(source, predicate, selector);

            #region Aggregation

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.Count(predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public int Count(Func<TResult, bool> predicate)
            //    => Count(new FunctionWrapper<TResult, bool>(predicate));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public int Count<TPredicate2>(TPredicate2 predicate = default)
            //    where TPredicate2 : struct, IFunction<TResult, bool>
            //    => ValueEnumerableExtensions.Count<SpanWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerator<TSource, TResult, TPredicate, TSelector>, TResult, TPredicate2>(this, predicate);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public int Count(Func<TResult, int, bool> predicate)
            //    => CountAt(new FunctionWrapper<TResult, int, bool>(predicate));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public int CountAt<TPredicate2>(TPredicate2 predicate = default)
            //    where TPredicate2 : struct, IFunction<TResult, int, bool>
            //    => ValueEnumerableExtensions.CountAt<SpanWhereSelectEnumerable<TSource, TResult, TPredicate, TSelector>, WhereSelectEnumerator<TSource, TResult, TPredicate, TSelector>, TResult, TPredicate2>(this, predicate);

            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All()
                => source.All(predicate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Any(predicate);

            #endregion
            #region Filtering

            #endregion
            #region Projection

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanWhereSelectEnumerable<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanWhereSelectEnumerable<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.WhereSelect<TSource, TResult2, TPredicate, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(predicate, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            #endregion
            #region Element
                
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAt<TSource, TResult, TPredicate, TSelector>(index, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.First<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.Single<TSource, TResult, TPredicate, TSelector>(predicate, selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => source.ToArray<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => source.ToArray(pool, clearOnDispose, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => source.ToList<TSource, TResult, TPredicate, TSelector>(predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey>(Func<TResult, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary(new FunctionWrapper<TResult, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TResult> ToDictionary<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                => source.ToDictionary<TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(keySelector, comparer, predicate, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TResult, TKey> keySelector, Func<TResult, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionary<TKey, TElement, FunctionWrapper<TResult, TKey>, FunctionWrapper<TResult, TElement>>(new FunctionWrapper<TResult, TKey>(keySelector), new FunctionWrapper<TResult, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TResult, TKey>
                where TElementSelector : struct, IFunction<TResult, TElement>
                => source.ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(keySelector, elementSelector, comparer, predicate, selector);
            
            #endregion

            public bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = default)
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
        public static int Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, int, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, int>
            => source.source.Sum<TSource, int, int, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, int?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, int?>
            => source.source.Sum<TSource, int?, int, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, nint, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nint>
            => source.source.Sum<TSource, nint, nint, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, nint?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nint?>
            => source.source.Sum<TSource, nint?, nint, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, nuint, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nuint>
            => source.source.Sum<TSource, nuint, nuint, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, nuint?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, nuint?>
            => source.source.Sum<TSource, nuint?, nuint, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, long, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, long>
            => source.source.Sum<TSource, long, long, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, long?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, long?>
            => source.source.Sum<TSource, long?, long, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, float, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, float>
            => source.source.Sum<TSource, float, float, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, float?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, float?>
            => source.source.Sum<TSource, float?, float, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, double, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, double>
            => source.source.Sum<TSource, double, double, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, double?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, double?>
            => source.source.Sum<TSource, double?, double, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, decimal, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, decimal>
            => source.source.Sum<TSource, decimal, decimal, TPredicate, TSelector>(source.predicate, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TPredicate, TSelector>(this SpanWhereSelectEnumerable<TSource, decimal?, TPredicate, TSelector> source)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, decimal?>
            => source.source.Sum<TSource, decimal?, decimal, TPredicate, TSelector>(source.predicate, source.selector);
    }
}

