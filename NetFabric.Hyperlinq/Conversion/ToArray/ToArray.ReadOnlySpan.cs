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
            var result = pool.RentSliced(source.Length);
            Copy(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilderRef(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilderRef(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAtRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAtRef(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAtRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate, MemoryPool<TSource> pool)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAtRef(source, predicate, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Length);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TResult[source.Length];
#endif
            Copy<TSource, TResult, TSelector>(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Length);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TResult[source.Length];
#endif
            CopyRef<TSource, TResult, TSelector>(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var result = pool.RentSliced(source.Length);
            Copy(source, result.Memory.Span, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            var result = pool.RentSliced(source.Length);
            CopyRef(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Length);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TResult[source.Length];
#endif
            CopyAt<TSource, TResult, TSelector>(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAtRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(source.Length);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TResult[source.Length];
#endif
            CopyAtRef<TSource, TResult, TSelector>(source, result, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var result = pool.RentSliced(source.Length);
            CopyAt(source, result.Memory.Span, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAtRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TSelector selector, MemoryPool<TResult> pool)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
        {
            var result = pool.RentSliced(source.Length);
            CopyAtRef(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayRef<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilderRef(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayRef<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, MemoryPool<TResult> pool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilderRef(source, predicate, selector, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }
    }
}

