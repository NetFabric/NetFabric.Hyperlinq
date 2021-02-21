using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ReadOnlyMemory<TSource> Take<TSource>(this ReadOnlyMemory<TSource> source, int count) 
            => source.Slice(0, Utils.Take(source.Length, count));
    }
}
