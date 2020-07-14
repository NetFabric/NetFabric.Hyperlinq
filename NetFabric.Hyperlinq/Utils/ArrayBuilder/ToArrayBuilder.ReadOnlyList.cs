using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TList, TSource>(in TList source, Predicate<TSource> predicate, int skipCount, int takeCount, ArrayPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TSource>(pool);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TList, TSource>(in TList source, PredicateAt<TSource> predicate, int skipCount, int takeCount, ArrayPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TSource>(pool);
            if (skipCount == 0)
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index], index))
                        builder.Add(source[index]);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    if (predicate(source[index + skipCount], index))
                        builder.Add(source[index + skipCount]);
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TList, TSource, TResult>(in TList source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int skipCount, int takeCount, ArrayPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            using var builder = new LargeArrayBuilder<TResult>(pool);
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    builder.Add(selector(source[index]));
            }
            return builder;
        }
    }
}
