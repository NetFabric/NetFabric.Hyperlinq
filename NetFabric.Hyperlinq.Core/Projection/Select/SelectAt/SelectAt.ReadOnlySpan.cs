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
        static SpanSelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, int, TResult> selector)
            => source.SelectAt<TSource, TResult, FunctionWrapper<TSource, int, TResult>>(new FunctionWrapper<TSource, int, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => new(source, selector);

        [StructLayout(LayoutKind.Auto)]
        public ref struct SpanSelectAtEnumerable<TSource, TResult, TSelector>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal TSelector selector;

            internal SpanSelectAtEnumerable(ReadOnlySpan<TSource> source, TSelector selector)
            {
                this.source = source;
                this.selector = selector;
            }
            
            public readonly SelectAtEnumerator<TSource, TResult, TSelector> GetEnumerator() 
                => new(source, selector);

            public readonly int Count 
                => source.Length;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => selector.Invoke(source[index], index);
            }

            #region Aggregation
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length is not 0;
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorAtSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAtAt<TSource, TResult, TSelector>(index, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.FirstAt<TSource, TResult, TSelector>(selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.SingleAt<TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            public TResult[] ToArray()
                => source.ToArrayAt<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => source.ToArrayAt(pool, clearOnDispose, selector);

            public List<TResult> ToList()
                => source.ToListAt<TSource, TResult, TSelector>(selector);
            
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

        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static int Count<TSource, TResult, TSelector>(this SpanSelectAtEnumerable<TSource, TResult, TSelector> source, Func<TResult, bool> predicate)
        //     where TSelector : struct, IFunction<TSource, int, TResult>
        //     => source.Count(predicate);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static int Count<TSource, TResult, TSelector, TPredicate>(this SpanSelectAtEnumerable<TSource, TResult, TSelector> source, TPredicate predicate = default)
        //     where TSelector : struct, IFunction<TSource, int, TResult>
        //     where TPredicate : struct, IFunction<TResult, bool>
        //     => source.Count(predicate);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static int Count<TSource, TResult, TSelector>(this SpanSelectAtEnumerable<TSource, TResult, TSelector> source, Func<TResult, int, bool> predicate)
        //     where TSelector : struct, IFunction<TSource, int, TResult>
        //     => source.Count(predicate);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static int CountAt<TSource, TResult, TSelector, TPredicate>(this SpanSelectAtEnumerable<TSource, TResult, TSelector> source, TPredicate predicate = default)
        //     where TSelector : struct, IFunction<TSource, int, TResult>
        //     where TPredicate : struct, IFunction<TResult, int, bool>
        //     => source.CountAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, int>
            => source.source.SumAt<TSource, int, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, int?>
            => source.source.SumAt<TSource, int?, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, nint, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nint>
            => source.source.SumAt<TSource, nint, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, nint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nint?>
            => source.source.SumAt<TSource, nint?, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, nuint, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nuint>
            => source.source.SumAt<TSource, nuint, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, nuint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, nuint?>
            => source.source.SumAt<TSource, nuint?, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, long>
            => source.source.SumAt<TSource, long, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, long?>
            => source.source.SumAt<TSource, long?, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, float>
            => source.source.SumAt<TSource, float, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, float?>
            => source.source.SumAt<TSource, float?, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, double>
            => source.source.SumAt<TSource, double, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, double?>
            => source.source.SumAt<TSource, double?, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, decimal>
            => source.source.SumAt<TSource, decimal, decimal, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this SpanSelectAtEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int, decimal?>
            => source.source.SumAt<TSource, decimal?, decimal, TSelector>(source.selector);
    }
}

