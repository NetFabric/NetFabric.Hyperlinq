using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static SkipTakeEnumerable<TList, TSource> Skip<TList, TSource>(this TList source, int count)
            where TList : struct, IReadOnlyList<TSource>
            => new(in source, Utils.Skip(source.Count, count));
    }
}