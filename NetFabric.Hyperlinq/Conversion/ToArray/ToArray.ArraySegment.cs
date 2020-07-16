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
            ArrayExtensions.Copy(source, result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this in ArraySegment<TSource> source, MemoryPool<TSource> pool)
            => ArrayExtensions.ToArray(source.AsMemory(), pool);
    }
}

