using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyMemory<TSource> source)
            => source.Length != 0;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyMemory<TSource> source, Predicate<TSource> predicate)
            => Any(source.Span, predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlyMemory<TSource> source, PredicateAt<TSource> predicate)
            => Any(source.Span, predicate);
    }
}

