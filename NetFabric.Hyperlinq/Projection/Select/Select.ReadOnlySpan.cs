using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorMapping("TSelector", "NetFabric.Hyperlinq.FunctionWrapper<TSource, TResult>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(this ReadOnlySpan<TSource> source, Func<TSource, TResult> selector)
            => source.Select<TSource, TResult, FunctionWrapper<TSource, TResult>>(new FunctionWrapper<TSource, TResult>(selector));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectEnumerable<TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => new(source, selector);

        [GeneratorMapping("TSource", "TResult")]
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

            public readonly Enumerator GetEnumerator() 
                => new (in this);

            public readonly int Count 
                => source.Length;

            public readonly TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => selector.Invoke(source[index]);
            }

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                TSelector selector;

                internal Enumerator(in SpanSelectEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly TResult Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(source[index]);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;
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
            public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
                => source.ToArray(selector, pool);

            public List<TResult> ToList()
                => source.ToList<TSource, TResult, TSelector>(selector);
            
            #endregion

            public bool SequenceEqual(IEnumerable<TResult> other, IEqualityComparer<TResult>? comparer = null)
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
        public static int Count<TSource, TResult, TSelector>(this SpanSelectEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunction<TSource, int>
            => source.source.Sum<TSource, int, int, TSelector, AddInt32>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunction<TSource, int?>
            => source.source.Sum<TSource, int?, int, TSelector, AddNullableInt32>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunction<TSource, long>
            => source.source.Sum<TSource, long, long, TSelector, AddInt64>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunction<TSource, long?>
            => source.source.Sum<TSource, long?, long, TSelector, AddNullableInt64>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunction<TSource, float>
            => source.source.Sum<TSource, float, float, TSelector, AddSingle>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunction<TSource, float?>
            => source.source.Sum<TSource, float?, float, TSelector, AddNullableSingle>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunction<TSource, double>
            => source.source.Sum<TSource, double, double, TSelector, AddDouble>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunction<TSource, double?>
            => source.source.Sum<TSource, double?, double, TSelector, AddNullableDouble>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunction<TSource, decimal>
            => source.source.Sum<TSource, decimal, decimal, TSelector, AddDecimal>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this SpanSelectEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunction<TSource, decimal?>
            => source.source.Sum<TSource, decimal?, decimal, TSelector, AddNullableDecimal>(source.selector);
    }
}

