using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this TSource[] source)
        {
#if NET5_0
            var result = GC.AllocateUninitializedArray<TSource>(source.Length);
#else
            var result = new TSource[source.Length];
#endif
            Array.Copy(source, result, source.Length);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this TSource[] source, MemoryPool<TSource> pool)
            => ArrayExtensions.ToArray(source.AsMemory(), pool);
    }
}

