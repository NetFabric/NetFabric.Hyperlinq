using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this Span<TSource> source, MemoryPool<TSource> pool)
            => ToArray((ReadOnlySpan<TSource>)source, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => ToArray((ReadOnlySpan<TSource>)source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this Span<TSource> source, Predicate<TSource> predicate, MemoryPool<TSource> pool)
            => ToArray((ReadOnlySpan<TSource>)source, predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => ToArray((ReadOnlySpan<TSource>)source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate, MemoryPool<TSource> pool)
            => ToArray((ReadOnlySpan<TSource>)source, predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this Span<TSource> source, NullableSelector<TSource, TResult> selector)
            => ToArray((ReadOnlySpan<TSource>)source, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this Span<TSource> source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray((ReadOnlySpan<TSource>)source, selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this Span<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => ToArray((ReadOnlySpan<TSource>)source, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this Span<TSource> source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray((ReadOnlySpan<TSource>)source, selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this Span<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => ToArray((ReadOnlySpan<TSource>)source, predicate, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this Span<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            => ToArray((ReadOnlySpan<TSource>)source, predicate, selector, pool);
    }
}

