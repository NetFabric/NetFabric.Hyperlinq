using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return All<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return All<TSource>(source, predicate, 0, source.Length);
        }

        [Pure]
        static bool All<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (!predicate(source[index], index))
                    return false;
            }
            return true;
        }
    }
}

