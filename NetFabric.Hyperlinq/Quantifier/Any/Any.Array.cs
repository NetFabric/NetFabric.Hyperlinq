using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source)
            => source.Length != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Any(new ArraySegment<TSource>(source), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => Any(new ArraySegment<TSource>(source), predicate);
    }
}

