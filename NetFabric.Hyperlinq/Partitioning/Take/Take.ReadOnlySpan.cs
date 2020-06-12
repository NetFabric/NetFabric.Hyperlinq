using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<TSource> Take<TSource>(this ReadOnlySpan<TSource> source, int count) 
            => source.Slice(0, Utils.Take(source.Length, count));
    }
}
