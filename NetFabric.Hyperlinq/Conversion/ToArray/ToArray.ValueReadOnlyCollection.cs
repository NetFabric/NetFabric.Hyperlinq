using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count is 0) return Array.Empty<TSource>();
#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(source.Count);
#else
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TSource[source.Count];
#endif
            Copy<TEnumerable, TEnumerator, TSource>(source, result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, MemoryPool<TSource> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var result = pool.RentSliced(source.Count);
            Copy<TEnumerable, TEnumerator, TSource>(source, result.Memory.Span);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0) return Array.Empty<TResult>();
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var array = new TResult[source.Count];
            Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, array, selector);
            return array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArray<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, MemoryPool<TResult> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var result = pool.RentSliced(source.Count);
            Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Memory.Span, selector);
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TResult[] ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Count is 0) return Array.Empty<TResult>();
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var array = new TResult[source.Count];
            CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, array, selector);
            return array;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IMemoryOwner<TResult> ToArrayAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector, MemoryPool<TResult> pool)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var result = pool.RentSliced(source.Count);
            CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, result.Memory.Span, selector);
            return result;
        }
    }
}
