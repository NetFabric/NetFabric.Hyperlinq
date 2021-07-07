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
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> Select<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => new(in source, selector);

        [StructLayout(LayoutKind.Auto)]
        public partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>
            : IValueReadOnlyCollection<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator>
            , ICollection<TResult>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            internal readonly TEnumerable source;
            internal TSelector selector;

            internal SelectEnumerable(in TEnumerable source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            public readonly int Count 
                => source.Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            bool ICollection<TResult>.IsReadOnly  
                => true;

            public void CopyTo(Span<TResult> span) 
            {
                if (Count is 0)
                    return;
                
                if (span.Length < Count)
                    Throw.ArgumentException(Resource.DestinationNotLongEnough, nameof(span));

                checked
                {
                    using var enumerator = source.GetEnumerator();
                    for (var index = 0; enumerator.MoveNext(); index++)
                        span[index] = selector.Invoke(enumerator.Current);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TResult[] array, int arrayIndex)
                => CopyTo(array.AsSpan(arrayIndex));

            public bool Contains(TResult item)
                => ValueReadOnlyCollectionExtensions.Contains<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, item, default, selector);

            [ExcludeFromCodeCoverage]
            void ICollection<TResult>.Add(TResult item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();

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
            
            #endregion
            #region Quantifier

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Count is not 0;
            
            #endregion
            #region Filtering
            
            #endregion
            #region Projection
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => ValueReadOnlyCollectionExtensions.Select<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
                where TSelector2 : struct, IFunction<TResult, int, TResult2>
                => ValueReadOnlyCollectionExtensions.SelectAt<TEnumerable, TEnumerator, TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            #endregion
            #region Element

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> ElementAt(int index)
                => ValueReadOnlyCollectionExtensions.ElementAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, index, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> First()
                => ValueReadOnlyCollectionExtensions.First<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TResult> Single()
                => ValueReadOnlyCollectionExtensions.Single<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector);
            
            #endregion
            #region Conversion

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult[] ToArray()
                => ValueReadOnlyCollectionExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Lease<TResult> ToArray(ArrayPool<TResult> pool, bool clearOnDispose = default)
                => ValueReadOnlyCollectionExtensions.ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, pool, clearOnDispose, selector);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TResult> ToList()
                => ValueReadOnlyCollectionExtensions.ToList<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector);
            
            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource, TResult, TSelector, TPredicate>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            where TPredicate : struct, IFunction<TResult, bool>
            => Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountAt<TEnumerable, TEnumerator, TSource, TResult, TSelector, TPredicate>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> source, TPredicate predicate = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            where TPredicate : struct, IFunction<TResult, int, bool>
            => CountAt<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.Enumerator, TResult, TPredicate>(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, int, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int>
            => Sum<TEnumerable, TEnumerator, TSource, int, int, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, int?, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int?>
            => Sum<TEnumerable, TEnumerator, TSource, int?, int, TSelector>(source.source, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nint, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nint>
            => Sum<TEnumerable, TEnumerator, TSource, nint, nint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nint?, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nint?>
            => Sum<TEnumerable, TEnumerator, TSource, nint?, nint, TSelector>(source.source, source.selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nuint, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nuint>
            => Sum<TEnumerable, TEnumerator, TSource, nuint, nuint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, nuint?, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, nuint?>
            => Sum<TEnumerable, TEnumerator, TSource, nuint?, nuint, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, long, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, long>
            => Sum<TEnumerable, TEnumerator, TSource, long, long, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, long?, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, long?>
            => Sum<TEnumerable, TEnumerator, TSource, long?, long, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, float, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, float>
            => Sum<TEnumerable, TEnumerator, TSource, float, float, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, float?, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, float?>
            => Sum<TEnumerable, TEnumerator, TSource, float?, float, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, double, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, double>
            => Sum<TEnumerable, TEnumerator, TSource, double, double, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, double?, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, double?>
            => Sum<TEnumerable, TEnumerator, TSource, double?, double, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, decimal, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, decimal>
            => Sum<TEnumerable, TEnumerator, TSource, decimal, decimal, TSelector>(source.source, source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TEnumerable, TEnumerator, TSource, TSelector>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, decimal?, TSelector> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, decimal?>
            => Sum<TEnumerable, TEnumerator, TSource, decimal?, decimal, TSelector>(source.source, source.selector);
    }
}

