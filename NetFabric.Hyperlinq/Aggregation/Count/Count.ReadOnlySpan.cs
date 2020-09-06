using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length;

        static int Count<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            var counter = 0;
            for (var index = 0; index < source.Length; index++)
                counter += predicate.Invoke(source[index]).AsByte();
            return counter;
        }

        static int CountAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            var counter = 0;
            for (var index = 0; index < source.Length; index++)
                counter += predicate.Invoke(source[index], index).AsByte();
            return counter;
        }
    }
}

