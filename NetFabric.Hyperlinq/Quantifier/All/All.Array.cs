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
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            for (var index = 0; index < source.Length; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }


        static bool All<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (!predicate(source[index]))
                        return false;
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (!predicate(source[index]))
                        return false;
                }
            }
            return true;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            for (var index = 0; index < source.Length; index++)
            {
                if (!predicate(source[index], index))
                    return false;
            }
            return true;
        }


        static bool All<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (!predicate(source[index], index))
                            return false;
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (!predicate(source[index], index))
                            return false;
                    }
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (!predicate(source[index + skipCount], index))
                        return false;
                }
            }
            return true;
        }

#endif
    }
}

