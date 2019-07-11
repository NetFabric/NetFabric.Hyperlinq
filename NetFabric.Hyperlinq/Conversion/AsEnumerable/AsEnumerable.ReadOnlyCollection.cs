using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TEnumerable AsEnumerable<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            => source;
    }
}