using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReadOnlyList<TSource> AsEnumerable<TSource>(this TSource[] source)
            => source;
    }
}