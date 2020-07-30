using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SkipTakeEnumerable<TList, TSource> Skip<TList, TSource>(this TList source, int count)
            where TList : notnull, IReadOnlyList<TSource>
            => SkipTake<TList, TSource>(source, count, source.Count);
    }
}