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

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TSource, TResult>(this ReadOnlySpan<TSource> source, FunctionIn<TSource, TResult> selector)
            => source.SelectRef<TSource, TResult, FunctionInWrapper<TSource, TResult>>(new FunctionInWrapper<TSource, TResult>(selector));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SpanSelectRefEnumerable<TSource, TResult, TSelector> SelectRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => new(source, selector);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public ref struct SpanSelectRefEnumerable<TSource, TResult, TSelector>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal TSelector selector;

            internal SpanSelectRefEnumerable(ReadOnlySpan<TSource> source, TSelector selector)
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
                get => selector.Invoke(in source[index]);
            }

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                TSelector selector;

                internal Enumerator(in SpanSelectRefEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly TResult Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(in source[index]);
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;
            }

            //#region Aggregation
            
            //#endregion
            //#region Quantifier

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public bool Any()
            //    => source.Length is not 0;
            
            //#endregion
            //#region Filtering
            
            //#endregion
            //#region Projection
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public SpanSelectEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            //    => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public SpanSelectEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunction<TResult, TResult2>
            //    => source.Select<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public SpanSelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
            //    => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public SpanSelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunction<TResult, int, TResult2>
            //    => source.SelectAt<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            //#endregion
            //#region Element

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> ElementAt(int index)
            //    => source.ElementAt<TSource, TResult, TSelector>(index, selector);
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> First()
            //    => source.First<TSource, TResult, TSelector>(selector);


            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> Single()
            //    => source.Single<TSource, TResult, TSelector>(selector);
            
            //#endregion
            //#region Conversion

            //public TResult[] ToArray()
            //    => source.ToArray<TSource, TResult, TSelector>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
            //    => source.ToArray(selector, pool);

            //public List<TResult> ToList()
            //    => source.ToList<TSource, TResult, TSelector>(selector);
            
            //#endregion

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
        public static int Count<TSource, TResult, TSelector>(this SpanSelectRefEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int>
            => source.source.SumRef<TSource, int, int, TSelector, AddInt32>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int?>
            => source.source.SumRef<TSource, int?, int, TSelector, AddNullableInt32>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, long>
            => source.source.SumRef<TSource, long, long, TSelector, AddInt64>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, long?>
            => source.source.SumRef<TSource, long?, long, TSelector, AddNullableInt64>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, float>
            => source.source.SumRef<TSource, float, float, TSelector, AddSingle>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, float?>
            => source.source.SumRef<TSource, float?, float, TSelector, AddNullableSingle>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, double>
            => source.source.SumRef<TSource, double, double, TSelector, AddDouble>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, double?>
            => source.source.SumRef<TSource, double?, double, TSelector, AddNullableDouble>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, decimal>
            => source.source.SumRef<TSource, decimal, decimal, TSelector, AddDecimal>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this SpanSelectRefEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, decimal?>
            => source.source.SumRef<TSource, decimal?, decimal, TSelector, AddNullableDecimal>(source.selector);
    }
}

