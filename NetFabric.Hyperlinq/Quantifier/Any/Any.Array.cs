using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source)
            => source.Length != 0;

#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, Predicate<TSource> predicate)
            => Any((ReadOnlySpan<TSource>)source.AsSpan(), predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
            => Any((ReadOnlySpan<TSource>)source.AsSpan(), predicate);

#else

        static bool Any<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            (_, var count) = Utils.SkipTake(source.Length, skipCount, takeCount);
            return count != 0;
        }


        public static bool Any<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }


        static bool Any<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            if (skipCount == 0 && takeCount == source.Length)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (predicate(source[index]))
                        return true;
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    if (predicate(source[index]))
                        return true;
                }
            }
            return false;
        }


        public static bool Any<TSource>(this TSource[] source, PredicateAt<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    return true;
            }
            return false;
        }


        static bool Any<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        if (predicate(source[index], index))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        if (predicate(source[index], index))
                            return true;
                    }
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index + skipCount], index))
                        return true;
                }
            }
            return false;
        }

#endif
    }
}

