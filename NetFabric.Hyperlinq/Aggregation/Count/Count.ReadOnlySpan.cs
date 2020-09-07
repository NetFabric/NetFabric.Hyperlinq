using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length;

        static int Count<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            var counter = 0;
            for (var index = 0; index < source.Length; index++)
                counter += predicate(source[index]).AsByte();
            return counter;
        }

        static int Count<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            var counter = 0;
            for (var index = 0; index < source.Length; index++)
                counter += predicate(source[index], index).AsByte();
            return counter;
        }
    }
}

