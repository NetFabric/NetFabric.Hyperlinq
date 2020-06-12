using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this Memory<TSource> source)
            => AsValueEnumerable((ReadOnlyMemory<TSource>)source);
    }
}