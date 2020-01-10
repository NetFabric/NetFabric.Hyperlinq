using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static long LongCount<TSource>(this TSource[] source)
            => source.LongLength;

        [Pure]
        public static long LongCount<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            var count = 0L;
            var end = source.LongLength;
            for (var index = 0L; index < end; index++)
            {
                var result = predicate(source[index]);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }
    }
}

