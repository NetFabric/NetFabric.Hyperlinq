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

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TSource, TResult>(this ReadOnlyMemory<TSource> source, FunctionIn<TSource, TResult> selector)
            => source.SelectRef<TSource, TResult, FunctionInWrapper<TSource, TResult>>(new FunctionInWrapper<TSource, TResult>(selector));

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemorySelectRefEnumerable<TSource, TResult, TSelector> SelectRef<TSource, TResult, TSelector>(this ReadOnlyMemory<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => new(source, selector);

        [GeneratorIgnore]
        [StructLayout(LayoutKind.Auto)]
        public partial struct MemorySelectRefEnumerable<TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, MemorySelectRefEnumerable<TSource, TResult, TSelector>.DisposableEnumerator>
            , IList<TResult>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            internal readonly ReadOnlyMemory<TSource> source;
            internal TSelector selector;

            internal MemorySelectRefEnumerable(ReadOnlyMemory<TSource> source, TSelector selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public readonly int Count 
                => source.Length;

            public readonly TResult this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => selector.Invoke(in source.Span[index]);
            }
            TResult IReadOnlyList<TResult>.this[int index]
                => selector.Invoke(in source.Span[index]);
            TResult IList<TResult>.this[int index]
            {
                get => selector.Invoke(in source.Span[index]);

                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }

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


            bool ICollection<TResult>.IsReadOnly  
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex)
                => ArrayExtensions.CopyRef(source.Span, array.AsSpan(arrayIndex), selector);
            void ICollection<TResult>.Add(TResult item) 
                => Throw.NotSupportedException();
            void ICollection<TResult>.Clear() 
                => Throw.NotSupportedException();
            public bool Contains(TResult item)
                => ArrayExtensions.ContainsRef(source.Span, item, selector);
            bool ICollection<TResult>.Remove(TResult item) 
                => Throw.NotSupportedException<bool>();
            int IList<TResult>.IndexOf(TResult item)
            {
                var span = source.Span;
                if (Utils.IsValueType<TResult>())
                {
                    for (var index = 0; index < span.Length; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in span[index]), item))
                            return index;
                    }
                }
                else
                {
                    var defaultComparer = EqualityComparer<TResult>.Default;
                    for (var index = 0; index < span.Length; index++)
                    {
                        if (defaultComparer.Equals(selector.Invoke(in span[index]), item))
                            return index;
                    }
                }
                return -1;
            }
            void IList<TResult>.Insert(int index, TResult item)
                => Throw.NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Sequential)]
            public ref struct Enumerator
            {
                int index;
                readonly int end;
                readonly ReadOnlySpan<TSource> source;
                TSelector selector;

                internal Enumerator(in MemorySelectRefEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source.Span;
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

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                int index;
                readonly int end;
                readonly ReadOnlyMemory<TSource> source;
                TSelector selector;

                internal DisposableEnumerator(in MemorySelectRefEnumerable<TSource, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                    end = index + source.Length;
                }

                public readonly TResult Current 
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => selector.Invoke(in source.Span[index]);
                }
                readonly TResult IEnumerator<TResult>.Current 
                    => selector.Invoke(in source.Span[index]);
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => selector.Invoke(in source.Span[index]);

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++index <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() { }
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
            //public MemorySelectRefEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
            //    => Select<TResult2, FunctionWrapper<TResult, TResult2>>(new FunctionWrapper<TResult, TResult2>(selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public MemorySelectRefEnumerable<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunction<TResult, TResult2>
            //    => source.Select<TSource, TResult2, SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public MemorySelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, FunctionWrapper<TResult, int, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, int, TResult2> selector)
            //    => SelectAt<TResult2, FunctionWrapper<TResult, int, TResult2>>(new FunctionWrapper<TResult, int, TResult2>(selector));
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public MemorySelectAtEnumerable<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>> SelectAt<TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSelector2 : struct, IFunction<TResult, int, TResult2>
            //    => source.SelectAt<TSource, TResult2, SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(new SelectorSelectorAtCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ReadOnlyListExtensions.SelectManyEnumerable<MemorySelectRefEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, FunctionWrapper<TResult, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult2>(Func<TResult, TSubEnumerable> selector)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    => this.SelectMany<MemorySelectRefEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public readonly ReadOnlyListExtensions.SelectManyEnumerable<MemorySelectRefEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2> SelectMany<TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(TSelector2 selector = default)
            //    where TSubEnumerable : IValueEnumerable<TResult2, TSubEnumerator>
            //    where TSubEnumerator : struct, IEnumerator<TResult2>
            //    where TSelector2 : struct, IFunction<TResult, TSubEnumerable>
            //    => this.SelectMany<MemorySelectRefEnumerable<TSource, TResult, TSelector>, TResult, TSubEnumerable, TSubEnumerator, TResult2, TSelector2>(selector);

            //#endregion
            //#region Element

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> ElementAt(int index)
            //    => source.Span.ElementAt<TSource, TResult, TSelector>(index, selector);
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> First()
            //    => source.Span.First<TSource, TResult, TSelector>(selector);
            
            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public Option<TResult> Single()
            //    => source.Span.Single<TSource, TResult, TSelector>(selector);
            
            //#endregion
            //#region Conversion

            //public TResult[] ToArray()
            //    => source.Span.ToArray<TSource, TResult, TSelector>(selector);

            //[MethodImpl(MethodImplOptions.AggressiveInlining)]
            //public IMemoryOwner<TResult> ToArray(MemoryPool<TResult> pool)
            //    => source.Span.ToArray(selector, pool);

            //public List<TResult> ToList()
            //    => source.Span.ToList<TSource, TResult, TSelector>(selector);
            
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
        public static int Count<TSource, TResult, TSelector>(this MemorySelectRefEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, int, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int>
            => source.source.Span.SumRef<TSource, int, int, TSelector, AddInt32>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, int?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, int?>
            => source.source.Span.SumRef<TSource, int?, int, TSelector, AddNullableInt32>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, long, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, long>
            => source.source.Span.SumRef<TSource, long, long, TSelector, AddInt64>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, long?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, long?>
            => source.source.Span.SumRef<TSource, long?, long, TSelector, AddNullableInt64>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, float, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, float>
            => source.source.Span.SumRef<TSource, float, float, TSelector, AddSingle>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, float?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, float?>
            => source.source.Span.SumRef<TSource, float?, float, TSelector, AddNullableSingle>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, double, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, double>
            => source.source.Span.SumRef<TSource, double, double, TSelector, AddDouble>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, double?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, double?>
            => source.source.Span.SumRef<TSource, double?, double, TSelector, AddNullableDouble>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, decimal, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, decimal>
            => source.source.Span.SumRef<TSource, decimal, decimal, TSelector, AddDecimal>(source.selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Sum<TSource, TSelector>(this MemorySelectRefEnumerable<TSource, decimal?, TSelector> source)
            where TSelector : struct, IFunctionIn<TSource, decimal?>
            => source.source.Span.SumRef<TSource, decimal?, decimal, TSelector, AddNullableDecimal>(source.selector);
    }
}

