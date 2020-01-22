using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source)
            => source.Length != 0;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool Any<TSource>(this TSource[] source, int skipCount, int takeCount)
            => takeCount != 0;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, Predicate<TSource> predicate) 
            => predicate is null
                ? Throw.ArgumentNullException<bool>(nameof(predicate))
                : Any<TSource>(source, predicate, 0, source.Length);

        [Pure]
        static bool Any<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, PredicateAt<TSource> predicate) 
            => predicate is null 
                ? Throw.ArgumentNullException<bool>(nameof(predicate)) 
                : Any<TSource>(source, predicate, 0, source.Length);

        [Pure]
        static bool Any<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return true;
            }
            return false;
        }
    }
}

