using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this Span<TSource> source, MemoryPool<TSource> pool)
            => ((ReadOnlySpan<TSource>)source).ToArray(pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => ((ReadOnlySpan<TSource>)source).ToArray(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, bool>
            => ((ReadOnlySpan<TSource>)source).ToArray(predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ((ReadOnlySpan<TSource>)source).ToArrayAt<TSource, TPredicate>(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this Span<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => ((ReadOnlySpan<TSource>)source).ToArrayAt(predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TSelector>(this Span<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => ((ReadOnlySpan<TSource>)source).ToArray<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TSelector>(this Span<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, TResult>
            => ((ReadOnlySpan<TSource>)source).ToArray(selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TSource, TResult, TSelector>(this Span<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ((ReadOnlySpan<TSource>)source).ToArrayAt<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TSource, TResult, TSelector>(this Span<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => ((ReadOnlySpan<TSource>)source).ToArrayAt(selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TPredicate, TSelector>(this Span<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => ((ReadOnlySpan<TSource>)source).ToArray<TSource, TResult, TPredicate, TSelector>(predicate, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this Span<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => ((ReadOnlySpan<TSource>)source).ToArray(predicate, selector, pool);
    }
}

