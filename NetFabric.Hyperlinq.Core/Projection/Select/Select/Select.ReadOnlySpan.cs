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
        static SpanSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, TResult> selector)
            => source.Select<TSource, TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SpanSelectEnumerable<TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => new(source, selector);

        [StructLayout(LayoutKind.Auto)]
        public ref struct SpanSelectEnumerable<TSource, TResult, TSelector>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal TSelector selector;

            internal SpanSelectEnumerable(ReadOnlySpan<TSource> source, TSelector selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly SelectEnumerator<TSource, TResult, TSelector> GetEnumerator() 
                => new(source, selector);

            public readonly int Count 
                => source.Length;

            public TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => selector.Invoke(source[index]);
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
            public SpanSelectEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.Select<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
                => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SpanSelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAt<TSource, TResult, TSelector>(index, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.First<TSource, TResult, TSelector>(selector);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.Single<TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            public TResult[] ToArray()
                => source.ToArray<TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => source.ToArray(pool, clearOnDispose, selector);

            public List<TResult> ToList()
                => source.ToList<TSource, TResult, TSelector>(selector);
            
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
        // public static int Count<TSource, TResult, TSelector>(this SpanSelectEnumerable<TSource, TResult, TSelector> source, Func<TResult, bool> predicate)
        //     where TSelector : struct, IFunction<TSource, TResult>
        //     => ValueReadOnlyCollectionExtensions.Count<SpanSelectEnumerable<TSource, TResult, TSelector>, SpanSelectEnumerable<TSource, TResult, TSelector>.Enumerator, TResult>(source, predicate);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static int Count<TSource, TResult, TSelector, TPredicate>(this SpanSelectEnumerable<TSource, TResult, TSelector> source, TPredicate predicate = default)
        //     where TSelector : struct, IFunction<TSource, TResult>
        //     where TPredicate : struct, IFunction<TResult, bool>
        //     => ValueReadOnlyCollectionExtensions.Count<SpanSelectEnumerable<TSource, TResult, TSelector>, SpanSelectEnumerable<TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static int Count<TSource, TResult, TSelector>(this SpanSelectEnumerable<TSource, TResult, TSelector> source, Func<TResult, int, bool> predicate)
        //     where TSelector : struct, IFunction<TSource, TResult>
        //     => ValueReadOnlyCollectionExtensions.Count<SpanSelectEnumerable<TSource, TResult, TSelector>, SpanSelectEnumerable<TSource, TResult, TSelector>.Enumerator, TResult>(source, predicate);
        //
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static int CountAt<TSource, TResult, TSelector, TPredicate>(this SpanSelectEnumerable<TSource, TResult, TSelector> source, TPredicate predicate = default)
        //     where TSelector : struct, IFunction<TSource, TResult>
        //     where TPredicate : struct, IFunction<TResult, int, bool>
        //     => ValueReadOnlyCollectionExtensions.CountAt<SpanSelectEnumerable<TSource, TResult, TSelector>, SpanSelectEnumerable<TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, nint, TSelector> source)
            where TSelector : struct, IFunction<TSource, nint>
            => source.source.Sum<TSource, nint, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, nint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, nint?>
            => source.source.Sum<TSource, nint?, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, nuint, TSelector> source)
            where TSelector : struct, IFunction<TSource, nuint>
            => source.source.Sum<TSource, nuint, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, nuint?, TSelector> source)
            where TSelector : struct, IFunction<TSource, nuint?>
            => source.source.Sum<TSource, nuint?, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunction<TSource, int>
            => source.source.Sum<TSource, int, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int?>
            => source.source.Sum<TSource, int?, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunction<TSource, long>
            => source.source.Sum<TSource, long, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunction<TSource, long?>
            => source.source.Sum<TSource, long?, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunction<TSource, float>
            => source.source.Sum<TSource, float, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunction<TSource, float?>
            => source.source.Sum<TSource, float?, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunction<TSource, double>
            => source.source.Sum<TSource, double, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunction<TSource, double?>
            => source.source.Sum<TSource, double?, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunction<TSource, decimal>
            => source.source.Sum<TSource, decimal, decimal, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunction<TSource, decimal?>
            => source.source.Sum<TSource, decimal?, decimal, TSelector>(source.selector);
    }
}

