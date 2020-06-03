using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
#if SPAN_SUPPORTED
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => All((ReadOnlySpan<TSource>)source.AsSpan(), predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => All((ReadOnlySpan<TSource>)source.AsSpan(), predicate);
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => ReadOnlyList.All(source, predicate);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => ReadOnlyList.All(source, predicate);
#endif
    }
}

