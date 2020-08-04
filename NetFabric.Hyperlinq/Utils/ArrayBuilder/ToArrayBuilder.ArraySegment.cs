using System;
using System.Buffers;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ArraySegment<TSource> source, Predicate<TSource> predicate, ArrayPool<TSource> pool)
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TSource>(pool);
            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Count == array!.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var item = array![index];
                        if (predicate(item))
                            builder.Add(item);
                    }
                }
                else
                {
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        var item = array![index];
                        if (predicate(item))
                            builder.Add(item);
                    }
                }
            }
            return builder;
        }


        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ArraySegment<TSource> source, PredicateAt<TSource> predicate, ArrayPool<TSource> pool)
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TSource>(pool);
            if (source.Count != 0)
            {
                var array = source!.Array;
                if (source.Count == array!.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var item = array![index];
                        if (predicate(item, index))
                            builder.Add(item);
                    }
                }
                else
                {
                    var end = source.Count - 1;
                    if (source.Offset == 0)
                    {
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array![index];
                            if (predicate(item, index))
                                builder.Add(item);
                        }
                    }
                    else
                    {
                        var offset = source.Offset;
                        for (var index = 0; index <= end; index++)
                        {
                            var item = array![index + offset];
                            if (predicate(item, index))
                                builder.Add(item);
                        }
                    }
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult>(in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> pool)
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TResult>(pool);
            if (source.Count != 0)
            {
                var array = source.Array;
                if (source.Count == array!.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        var item = array![index];
                        if (predicate(item))
                            builder.Add(selector(item));
                    }
                }
                else
                {
                    var end = source.Offset + source.Count - 1;
                    for (var index = source.Offset; index <= end; index++)
                    {
                        var item = array![index];
                        if (predicate(item))
                            builder.Add(selector(item));
                    }
                }
            }
            return builder;
        }
    }
}
