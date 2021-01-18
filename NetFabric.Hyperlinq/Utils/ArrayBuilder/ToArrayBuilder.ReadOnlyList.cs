using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TList, TSource, TPredicate>(in TList source, TPredicate predicate, int offset, int count, ArrayPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index]))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TList, TSource, TPredicate>(in TList source, TPredicate predicate, int offset, int count, ArrayPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool);
            var end = count - 1;
            if (offset is 0)
            {
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(source[index], index))
                        builder.Add(source[index]);
                }
            }
            else
            {
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(source[index + offset], index))
                        builder.Add(source[index + offset]);
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(in TList source, TPredicate predicate, TSelector selector, int offset, int count, ArrayPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
            where TSelector: struct, IFunction<TSource, TResult>
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TResult>(pool);
            var end = offset + count - 1;
            for (var index = offset; index <= end; index++)
            {
                if (predicate.Invoke(source[index]))
                    builder.Add(selector.Invoke(source[index]));
            }
            return builder;
        }
    }
}
