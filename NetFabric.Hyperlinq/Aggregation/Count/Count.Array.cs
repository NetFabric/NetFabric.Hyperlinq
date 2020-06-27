using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

#if SPAN_SUPPORTED

#else

        static unsafe int Count<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var count = 0;
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var result = predicate(source[index]);
                        count += *(int*)&result;
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        var result = predicate(source[index]);
                        count += *(int*)&result;
                    }
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var result = predicate(source[index + skipCount]);
                    count += *(int*)&result;
                }
            }
            return count;
        }

        static unsafe int Count<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var count = 0;
            if (skipCount == 0)
            {
                if (takeCount == source.Length)
                {
                    for (var index = 0; index < source.Length; index++)
                    {
                        var result = predicate(source[index], index);
                        count += *(int*)&result;
                    }
                }
                else
                {
                    for (var index = 0; index < takeCount; index++)
                    {
                        var result = predicate(source[index], index);
                        count += *(int*)&result;
                    }
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var result = predicate(source[index + skipCount], index);
                    count += *(int*)&result;
                }
            }
            return count;
        }

#endif
    }
}

