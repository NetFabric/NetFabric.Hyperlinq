using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this ReadOnlySpan<TSource> source, MemoryPool<TSource> pool)
        {
            if (pool is null) Throw.ArgumentNullException(nameof(pool));

            var result = pool.RentSliced(source.Length);
            ArrayExtensions.Copy(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate,ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Length);
#else
            var result = new TResult[source.Length];
#endif
            ArrayExtensions.Copy(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            var result = pool.RentSliced(source.Length);
            ArrayExtensions.Copy(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelectorAt<TSource, TResult> selector)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Length);
#else
            var result = new TResult[source.Length];
#endif
            ArrayExtensions.Copy(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult>(this ReadOnlySpan<TSource> source, NullableSelectorAt<TSource, TResult> selector, MemoryPool<TResult> pool)
        {
            var result = pool.RentSliced(source.Length);
            ArrayExtensions.Copy(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IPredicate<TSource>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }
    }
}

