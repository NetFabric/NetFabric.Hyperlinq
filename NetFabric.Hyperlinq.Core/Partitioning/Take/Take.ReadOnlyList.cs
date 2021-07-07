using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static SkipTakeEnumerable<TList, TSource> Take<TList, TSource>(this TList source, int count)
            where TList : struct, IReadOnlyList<TSource>
            => new(in source, 0, Utils.Take(source.Count, count));
    }
}