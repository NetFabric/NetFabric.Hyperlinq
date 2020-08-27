using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this ReadOnlyMemory<TSource> source, MemoryPool<TSource> pool)
            => ToArray(source.Span, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => ToArray(source.Span, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate, MemoryPool<TSource> pool)
            => ToArray(source.Span, predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => ToArray(source.Span, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate, MemoryPool<TSource> pool)
            => ToArray(source.Span, predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelector<TSource, TResult> selector)
            => ToArray(source.Span, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray(source.Span, selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => ToArray(source.Span, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this ReadOnlyMemory<TSource> source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray(source.Span, selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => ToArray(source.Span, predicate, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray(source.Span, predicate, selector, pool);
    }
}

