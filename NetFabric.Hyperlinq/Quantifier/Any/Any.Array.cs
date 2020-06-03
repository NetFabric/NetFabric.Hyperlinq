using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source)
            => source.Length != 0;

#if SPAN_SUPPORTED
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Any((ReadOnlySpan<TSource>)source.AsSpan(), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => Any((ReadOnlySpan<TSource>)source.AsSpan(), predicate);
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => ReadOnlyList.Any(source, predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => ReadOnlyList.Any(source, predicate);
#endif
    }
}

