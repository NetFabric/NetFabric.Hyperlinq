using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source)
            => source.Count != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
            => Any(source.AsMemory(), predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
            => Any(source.AsMemory(), predicate);
    }
}

