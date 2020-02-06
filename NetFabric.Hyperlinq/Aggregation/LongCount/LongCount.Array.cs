using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long LongCount<TSource>(this TSource[] source)
            => source.LongLength;

        [Pure]
        public static long LongCount<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var count = 0L;
            for (var index = 0L; index < source.LongLength; index++)
            {
                var result = predicate(source[index]);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }

        [Pure]
        public static long LongCount<TSource>(this TSource[] source, PredicateAtLong<TSource> predicate)
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            var count = 0L;
            for (var index = 0L; index < source.LongLength; index++)
            {
                var result = predicate(source[index], index);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }
    }
}

