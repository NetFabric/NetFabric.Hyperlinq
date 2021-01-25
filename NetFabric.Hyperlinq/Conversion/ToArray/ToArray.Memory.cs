using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this Memory<TSource> source, MemoryPool<TSource> pool)
            => source.Span.ToArray(pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Span.ToArray(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.Span.ToArray(predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Span.ToArrayAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.Span.ToArrayAt(predicate, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TSelector>(this Memory<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Span.ToArray<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TSelector>(this Memory<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Span.ToArray(selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TSource, TResult, TSelector>(this Memory<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Span.ToArrayAt<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TSource, TResult, TSelector>(this Memory<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.Span.ToArrayAt(selector, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TPredicate, TSelector>(this Memory<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Span.ToArray<TSource, TResult, TPredicate, TSelector>(predicate, selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this Memory<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
            => source.Span.ToArray(predicate, selector, pool);
    }
}

