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
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> Select<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, selector);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> 
            : IValueEnumerable<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal readonly TEnumerable source;
            internal readonly TSelector selector;

            internal SelectEnumerable(in TEnumerable source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
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
#pragma warning disable IDE0044 // Add readonly modifier
                TEnumerator enumerator;
                TSelector selector;
#pragma warning restore IDE0044 // Add readonly modifier

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
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
                    => enumerator.MoveNext();

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
                => source.Count<TEnumerable, TEnumerator, TSource>();
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Any<TEnumerable, TEnumerator, TSource>();
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => source.Select<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => source.SelectAt<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectManyEnumerable<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
                where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
                where TSubEnumerator : struct, IEnumerator<TResult2>
                where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
                => this.SelectMany<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, Enumerator, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => source.ElementAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(index, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => source.First<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => source.Single<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector);
            
            #endregion
            #region Conversion

            public TResult[] ToArray()
                => source.ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => source.ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(pool, clearOnDispose, selector);

            public List<TResult> ToList()
                => source.ToList<TEnumerable, TEnumerator, TSource, TResult, TSelector>(selector);
            
            #endregion
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, int, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, int, int, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, int?, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int?>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, int?, int, TSelector>(source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nint, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nint>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, nint, nint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nint?, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nint?>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, nint?, nint, TSelector>(source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nuint, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nuint>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, nuint, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nuint?, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nuint?>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, nuint?, nuint, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, long, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, long>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, long, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, long?, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, long?>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, long?, long, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, float, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, float>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, float, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, float?, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, float?>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, float?, float, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, double, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, double>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, double, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, double?, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, double?>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, double?, double, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, decimal, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, decimal>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, decimal, decimal, TSelector>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, decimal?, TSelector> source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, decimal?>
            => source.source.Sum<TEnumerable, TEnumerator, TSource, decimal?, decimal, TSelector>(source.selector);
    }
}

