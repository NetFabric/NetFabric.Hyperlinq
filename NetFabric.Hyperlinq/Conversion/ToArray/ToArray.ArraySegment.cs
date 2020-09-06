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
            if (source.Count == 0)
                return Array.Empty<TSource>();

#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(source.Count);
#else
            var result = new TSource[source.Count];
#endif
            ArrayExtensions.Copy(source, result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, MemoryPool<TSource> pool)
        {
            if (pool is null)
                Throw.ArgumentNullException(nameof(pool));

            if (source.Count == 0)
                return pool.Rent(0);

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            if (source.Count == 0)
                return Array.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IPredicate<TSource>
        {
            if (source.Count == 0)
                return pool.Rent(0);
            
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (source.Count == 0)
                return Array.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (source.Count == 0)
                return pool.Rent(0);

            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
        {
            if (source.Count == 0)
                return Array.Empty<TResult>();

#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Count);
#else
            var result = new TResult[source.Count];
#endif
            ArrayExtensions.Copy(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            if (source.Count == 0)
                return pool.Rent(0);

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
            if (source.Count == 0)
                return Array.Empty<TResult>();

#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Count);
#else
            var result = new TResult[source.Count];
#endif
            ArrayExtensions.Copy(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            if (source.Count == 0)
                return pool.Rent(0);

            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
        {
            if (source.Count == 0)
                return Array.Empty<TResult>();

            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IPredicate<TSource>
        {
            if (source.Count == 0)
                return pool.Rent(0);

            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }
    }
}

