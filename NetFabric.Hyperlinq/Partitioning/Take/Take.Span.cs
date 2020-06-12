using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<TSource> Take<TSource>(this Span<TSource> source, int count)
            => source.Slice(0, Utils.Take(source.Length, count));
    }
}
