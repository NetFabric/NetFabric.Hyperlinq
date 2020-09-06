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
        static TSource[] ToArray<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
            => ToArray((ReadOnlySpan<TSource>)source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IPredicate<TSource>
            => ToArray((ReadOnlySpan<TSource>)source, predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
            => ToArrayAt((ReadOnlySpan<TSource>)source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IPredicateAt<TSource>
            => ToArrayAt((ReadOnlySpan<TSource>)source, predicate, pool);

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
        static TResult[] ToArray<TSource, TResult, TPredicate>(this Span<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
            => ToArray((ReadOnlySpan<TSource>)source, predicate, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate>(this Span<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IPredicate<TSource>
            => ToArray((ReadOnlySpan<TSource>)source, predicate, selector, pool);
    }
}

