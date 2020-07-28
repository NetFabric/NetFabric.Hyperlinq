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
            var array = source.Array;
            if (source.IsWhole())
            {
                foreach (var item in array)
                {
                    if (predicate(item))
                        builder.Add(item);
                }
            }
            else
            {
                var end = source.Offset + source.Count - 1;
                for (var index = source.Offset; index <= end; index++)
                {
                    if (predicate(array[index]))
                        builder.Add(array[index]);
                }
            }
            return builder;
        }


        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ArraySegment<TSource> source, PredicateAt<TSource> predicate, ArrayPool<TSource> pool)
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TSource>(pool);
            var array = source.Array;
            if (source.IsWhole())
            {
                var index = 0;
                foreach (var item in array)
                {
                    if (predicate(item, index))
                        builder.Add(item);

                    index++;
                }
            }
            else
            {
                var end = source.Count - 1;
                if (source.Offset == 0)
                {
                    for (var index = 0; index <= end; index++)
                    {
                        if (predicate(array[index], index))
                            builder.Add(array[index]);
                    }
                }
                else
                {
                    var offset = source.Offset;
                    for (var index = 0; index <= end; index++)
                    {
                        var item = array[index + offset];
                        if (predicate(item, index))
                            builder.Add(item);
                    }
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult>(in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> pool)
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TResult>(pool);
            var array = source.Array;
            if (source.IsWhole())
            {
                foreach (var item in array)
                {
                    if (predicate(item))
                        builder.Add(selector(item));
                }
            }
            else
            {
                var end = source.Offset + source.Count - 1;
                for (var index = source.Offset; index <= end; index++)
                {
                    if (predicate(array[index]))
                        builder.Add(selector(array[index]));
                }
            }
            return builder;
        }
    }
}
