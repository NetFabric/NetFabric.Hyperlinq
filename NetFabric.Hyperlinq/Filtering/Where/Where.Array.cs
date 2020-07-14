using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemoryWhereEnumerable<TSource> Where<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Where((ReadOnlyMemory<TSource>)source.AsMemory(), predicate);
    }
}

