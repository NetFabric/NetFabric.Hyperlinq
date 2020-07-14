using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this in Memory<TSource> source, MemoryPool<TSource> pool)
            => ToArray((ReadOnlySpan<TSource>)source.Span, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this in Memory<TSource> source, Predicate<TSource> predicate)
            => ToArray((ReadOnlySpan<TSource>)source.Span, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this in Memory<TSource> source, Predicate<TSource> predicate, MemoryPool<TSource> pool)
            => ToArray((ReadOnlySpan<TSource>)source.Span, predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this in Memory<TSource> source, PredicateAt<TSource> predicate)
            => ToArray((ReadOnlySpan<TSource>)source.Span, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this in Memory<TSource> source, PredicateAt<TSource> predicate, MemoryPool<TSource> pool)
            => ToArray((ReadOnlySpan<TSource>)source.Span, predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in Memory<TSource> source, NullableSelector<TSource, TResult> selector)
            => ToArray((ReadOnlySpan<TSource>)source.Span, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in Memory<TSource> source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray((ReadOnlySpan<TSource>)source.Span, selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in Memory<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => ToArray((ReadOnlySpan<TSource>)source.Span, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in Memory<TSource> source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray((ReadOnlySpan<TSource>)source.Span, selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in Memory<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => ToArray((ReadOnlySpan<TSource>)source.Span, predicate, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in Memory<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray((ReadOnlySpan<TSource>)source.Span, predicate, selector, pool);
    }
}

