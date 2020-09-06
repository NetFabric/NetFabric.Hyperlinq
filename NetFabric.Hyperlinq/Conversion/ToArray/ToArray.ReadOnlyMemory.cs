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
        static TSource[] ToArray<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
            => ToArray(source.Span, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IPredicate<TSource>
            => ToArray(source.Span, predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
            => ToArrayAt(source.Span, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IPredicateAt<TSource>
            => ToArrayAt(source.Span, predicate, pool);

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
        static TResult[] ToArray<TSource, TResult, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
            => ToArray(source.Span, predicate, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate>(this ReadOnlyMemory<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IPredicate<TSource>
            => ToArray(source.Span, predicate, selector, pool);
    }
}

