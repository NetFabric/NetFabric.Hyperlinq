using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(source.Count);
#else
            var result = new TSource[source.Count];
#endif
            ArrayExtensions.Copy(source, new ArraySegment<TSource>(result));
            return result;
        }

        public static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, MemoryPool<TSource> pool)
        {
            if (pool is null) Throw.ArgumentNullException(nameof(pool));

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source.AsSpan(), result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, MemoryPool<TSource> pool)
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate, MemoryPool<TSource> pool)
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Count);
#else
            var result = new TResult[source.Count];
#endif
            ArrayExtensions.Copy(source, new ArraySegment<TResult>(result), selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source.AsSpan(), result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Count);
#else
            var result = new TResult[source.Count];
#endif
            ArrayExtensions.Copy(source, new ArraySegment<TResult>(result), selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source.AsSpan(), result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }
    }
}

