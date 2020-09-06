using System;
using System.Buffers;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource, TPredicate>(in ArraySegment<TSource> source, TPredicate predicate, ArrayPool<TSource> pool)
            where TPredicate : struct, IPredicate<TSource>
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TSource>(pool);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item))
                            builder.Add(item);
                    }
                }
                else
                {
                    var array = source.Array;
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        var item = array![index];
                        if (predicate.Invoke(item))
                            builder.Add(item);
                    }
                }
            }
            return builder;
        }


        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TSource, TPredicate>(in ArraySegment<TSource> source, TPredicate predicate, ArrayPool<TSource> pool)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TSource>(pool);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item, index))
                            builder.Add(item);

                        index++;
                    }
                }
                else
                {
                    var end = source.Count - 1;
                    if (source.Offset == 0)
                    {
                        var array = source!.Array;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array![index];
                            if (predicate.Invoke(item, index))
                                builder.Add(item);
                        }
                    }
                    else
                    {
                        var array = source!.Array;
                        var offset = source.Offset;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array![index + offset];
                            if (predicate.Invoke(item, index))
                                builder.Add(item);
                        }
                    }
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult, TPredicate>(in ArraySegment<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> pool)
            where TPredicate : struct, IPredicate<TSource>
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TResult>(pool);
            if (source.Any())
            {
                if (source.IsWhole())
                {
                    foreach (var item in source.Array)
                    {
                        if (predicate.Invoke(item))
                            builder.Add(selector(item));
                    }
                }
                else
                {
                    var array = source.Array;
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        var item = array![index];
                        if (predicate.Invoke(item))
                            builder.Add(selector(item));
                    }
                }
            }
            return builder;
        }
    }
}
