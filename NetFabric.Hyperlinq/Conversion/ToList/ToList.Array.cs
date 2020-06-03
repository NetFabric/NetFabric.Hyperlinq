using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this TSource[] source)
            => new List<TSource>(source);
    }
}