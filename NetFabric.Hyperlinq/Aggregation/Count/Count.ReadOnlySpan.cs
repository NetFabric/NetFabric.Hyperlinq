using System;
using System.Diagnostics.Contracts;
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
            var count = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var result = predicate(source[index]);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }

        static int Count<TSource>(this ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate)
        {
            var count = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var result = predicate(source[index], index);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }
    }
}

