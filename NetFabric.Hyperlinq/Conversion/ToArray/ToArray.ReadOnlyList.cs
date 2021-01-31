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
            => source.ToArray<TList, TSource>(0, source.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, MemoryPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
            => source.ToArray(0, source.Count, pool);

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource>(this TList source, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(count);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TSource[count];
#endif
            Copy(source, offset, result, 0, count);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource>(this TList source, int offset, int count, MemoryPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            var result = pool.RentSliced(count);
            Copy(source, offset, result.Memory.Span, count);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArray<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArray<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count, MemoryPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            using var arrayBuilder = ToArrayBuilder(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] ToArrayAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TSource> ToArrayAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count, MemoryPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            using var arrayBuilder = ToArrayBuilderAt(source, predicate, offset, count, ArrayPool<TSource>.Shared);
            return arrayBuilder.ToArray(pool);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(count);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TResult[count];
#endif
            Copy<TList, TSource, TResult, TSelector>(source, offset, result, 0, count, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var result = pool.RentSliced(count);
            Copy<TList, TSource, TResult, TSelector>(source, offset, result.Memory.Span, count, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TResult>(count);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TResult[count];
#endif
            CopyAt<TList, TSource, TResult, TSelector>(source, offset, result, 0, count, selector);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var result = pool.RentSliced(count);
            CopyAt<TList, TSource, TResult, TSelector>(source, offset, result.Memory.Span, count, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TList, TSource, TResult, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, predicate, selector, offset, count, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TList, TSource, TResult, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count, MemoryPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            using var arrayBuilder = ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(source, predicate, selector, offset, count, ArrayPool<TResult>.Shared);
            return arrayBuilder.ToArray(pool);
        }
    }
}

