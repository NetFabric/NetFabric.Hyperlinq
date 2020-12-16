using System;
using System.Buffers;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource, TPredicate>(in ArraySegment<TSource> source, TPredicate predicate, ArrayPool<TSource> pool)
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item))
                            builder.Add(item);
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        var item = array[index];
                        if (predicate.Invoke(item))
                            builder.Add(item);
                    }
                }
            }
            return builder;
        }


        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TSource, TPredicate>(in ArraySegment<TSource> source, TPredicate predicate, ArrayPool<TSource> pool)
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item, index))
                            builder.Add(item);

                        index++;
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Count - 1;
                    if (source.Offset == 0)
                    {
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array[index];
                            if (predicate.Invoke(item, index))
                                builder.Add(item);
                        }
                    }
                    else
                    {
                        var offset = source.Offset;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array[index + offset];
                            if (predicate.Invoke(item, index))
                                builder.Add(item);
                        }
                    }
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult, TPredicate, TSelector>(in ArraySegment<TSource> source, TPredicate predicate, TSelector selector, ArrayPool<TResult> pool)
            where TPredicate: struct, IFunction<TSource, bool>
            where TSelector: struct, IFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(pool);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array!)
                    {
                        if (predicate.Invoke(item))
                            builder.Add(selector.Invoke(item));
                    }
                }
                else
                {
                    var array = source.Array!;
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        var item = array[index];
                        if (predicate.Invoke(item))
                            builder.Add(selector.Invoke(item));
                    }
                }
            }
            return builder;
        }
    }
}
