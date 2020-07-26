using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length;

        static unsafe int Count<TSource>(this ReadOnlySpan<TSource> source, Predicate<TSource> predicate)
        {
            var counter = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var result = predicate(source[index]);
                counter += *(int*)&result;
            }
            return counter;
        }

        static unsafe int Count<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            var counter = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var result = predicate(source[index], index);
                counter += *(int*)&result;
            }
            return counter;
        }
    }
}

