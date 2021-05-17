using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static SkipTakeEnumerable<TList, TSource> Take<TList, TSource>(this TList source, int count)
            where TList : struct, IReadOnlyList<TSource>
            => source.SkipTake<TList, TSource>(0, count);
    }
}