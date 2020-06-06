using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

#if SPAN_SUPPORTED

#else

        static int Count<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var count = 0;
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var result = predicate(source[index]);
                count += Unsafe.As<bool, byte>(ref result);
            }
            return count;
        }

        static int Count<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var count = 0;
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var result = predicate(source[index], index);
                    count += Unsafe.As<bool, byte>(ref result);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var result = predicate(source[index + skipCount], index);
                    count += Unsafe.As<bool, byte>(ref result);
                }
            }
            return count;
        }

#endif
    }
}

