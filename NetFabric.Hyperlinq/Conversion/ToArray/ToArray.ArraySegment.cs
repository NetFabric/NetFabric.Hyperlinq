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
            if (source.Count is 0)
                return Array.Empty<TSource>();

#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(source.Count);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TSource[source.Count];
#endif
            ArrayExtensions.Copy(source, result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, MemoryPool<TSource> pool)
        {
            if (source.Count is 0)
                return pool.Rent(0);

            var result = pool.RentSliced(source.Count);
            Copy(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (source.Count is 0)
                return Array.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            if (source.Count is 0)
                return Array.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilderRef(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (source.Count is 0)
                return pool.Rent(0);
            
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            if (source.Count is 0)
                return pool.Rent(0);

            using var arrayBuilder = ToArrayBuilderRef(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Count is 0)
                return Array.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            if (source.Count is 0)
                return Array.Empty<TSource>();

            using var arrayBuilder = ToArrayBuilderAtRef(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (source.Count is 0)
                return pool.Rent(0);

            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            if (source.Count is 0)
                return pool.Rent(0);

            using var arrayBuilder = ToArrayBuilderAtRef(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return Array.Empty<TResult>();

#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Count);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TResult[source.Count];
#endif
            Copy<TSource, TResult, TSelector>(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return pool.Rent(0);

            var result = pool.RentSliced(source.Count);
            Copy<TSource, TResult, TSelector>(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Count is 0)
                return Array.Empty<TResult>();

#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Count);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TResult[source.Count];
#endif
            CopyAt<TSource, TResult, TSelector>(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Count is 0)
                return pool.Rent(0);

            var result = pool.RentSliced(source.Count);
            CopyAt<TSource, TResult, TSelector>(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return Array.Empty<TResult>();

            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayRef<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            if (source.Count is 0)
                return Array.Empty<TResult>();

            using var arrayBuilder = ToArrayBuilderRef(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return pool.Rent(0);

            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayRef<TSource, TResult, TPredicate, TSelector>(this in ArraySegment<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            if (source.Count is 0)
                return pool.Rent(0);

            using var arrayBuilder = ToArrayBuilderRef(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }
    }
}

