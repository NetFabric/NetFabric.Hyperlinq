using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this in ReadOnlySpan<TSource> source, MemoryPool<TSource> pool)
        {
            if (pool is null) Throw.ArgumentNullException(nameof(pool));

            var result = pool.RentSliced(source.Length);
            ArrayExtensions.Copy(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this in ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
            => ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this in ReadOnlySpan<TSource> source, Predicate<TSource> predicate, MemoryPool<TSource> memoryPool)
        {
            Debug.Assert(memoryPool is object);
            return ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared).ToArray(memoryPool);
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ReadOnlySpan<TSource> source, Predicate<TSource> predicate, ArrayPool<TSource> arrayPool)
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    builder.Add(source[index]);
            }
            return builder;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource>(this in ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
            => ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource>(this in ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate, MemoryPool<TSource> memoryPool)
        {
            Debug.Assert(memoryPool is object);
            return ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared).ToArray(memoryPool);
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate, ArrayPool<TSource> arrayPool)
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    builder.Add(source[index]);
            }
            return builder;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector)
        {
            var result = new TResult[source.Length];
            ArrayExtensions.Copy(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            var result = pool.RentSliced(source.Length);
            ArrayExtensions.Copy(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ReadOnlySpan<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
            var result = new TResult[source.Length];
            ArrayExtensions.Copy(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ReadOnlySpan<TSource> source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            var result = pool.RentSliced(source.Length);
            ArrayExtensions.Copy(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ReadOnlySpan<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
            => ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ReadOnlySpan<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> memoryPool)
        {
            Debug.Assert(memoryPool is object);
            return ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared).ToArray(memoryPool);
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult>(in ReadOnlySpan<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> arrayPool)
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TResult>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    builder.Add(selector(source[index]));
            }
            return builder;
        }
    }
}

