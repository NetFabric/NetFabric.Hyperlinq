using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TList, TSource>(this TList source)
            where TList : IReadOnlyList<TSource>
            => ToArray<TList, TSource>(source, 0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, MemoryPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            if (pool is null) Throw.ArgumentNullException(nameof(pool));

            return ToArray(source, 0, source.Count, pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource>(this TList source, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(takeCount);
#else
            var result = new TSource[takeCount];
#endif
            ReadOnlyListExtensions.Copy(source, skipCount, result, 0, takeCount);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, int skipCount, int takeCount, MemoryPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(takeCount);
            ReadOnlyListExtensions.Copy<TList, TSource>(source, skipCount, result.Memory.Span, takeCount);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => ToArrayBuilder(source, predicate, skipCount, takeCount, ArrayPool<TSource>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, Predicate<TSource> predicate, int skipCount, int takeCount, MemoryPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);
            return ToArrayBuilder(source, predicate, skipCount, takeCount, ArrayPool<TSource>.Shared).ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => ToArrayBuilder(source, predicate, skipCount, takeCount, ArrayPool<TSource>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount, MemoryPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);
            return ToArrayBuilder(source, predicate, skipCount, takeCount, ArrayPool<TSource>.Shared).ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(takeCount);
#else
            var result = new TResult[takeCount];
#endif
            ReadOnlyListExtensions.Copy(source, skipCount, result, 0, takeCount, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TResult> ToArray<TList, TSource, TResult>(this TList source, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount, MemoryPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(takeCount);
            ReadOnlyListExtensions.Copy(source, skipCount, result.Memory.Span, takeCount, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(takeCount);
#else
            var result = new TResult[takeCount];
#endif
            ReadOnlyListExtensions.Copy(source, skipCount, result, 0, takeCount, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TResult> ToArray<TList, TSource, TResult>(this TList source, NullableSelectorAt<TSource, TResult> selector, int skipCount, int takeCount, MemoryPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            var result = pool.RentSliced(takeCount);
            ReadOnlyListExtensions.Copy(source, skipCount, result.Memory.Span, takeCount, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : IReadOnlyList<TSource>
            => ToArrayBuilder(source, predicate, selector, skipCount, takeCount, ArrayPool<TResult>.Shared).ToArray();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult>(this TList source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount, MemoryPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);
            return ToArrayBuilder(source, predicate, selector, skipCount, takeCount, ArrayPool<TResult>.Shared).ToArray(pool);
        }
    }
}

