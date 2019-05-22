using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TSource> AsEnumerable<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            => source;
    }
}