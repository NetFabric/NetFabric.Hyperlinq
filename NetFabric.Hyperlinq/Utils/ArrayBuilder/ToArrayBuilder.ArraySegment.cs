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
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var index = 0; index < array.Length; index++)
                {
                    if (predicate(array[index]))
                        builder.Add(array[index]);
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
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
            if (source.Offset == 0)
            {
                if (source.Count == array.Length)
                {
                    for (var index = 0; index < array.Length; index++)
                    {
                        if (predicate(array[index], index))
                            builder.Add(array[index]);
                    }
                }
                else
                {
                    for (var index = 0; index < source.Count; index++)
                    {
                        if (predicate(array[index], index))
                            builder.Add(array[index]);
                    }
                }
            }
            else
            {
                var offset = source.Offset;
                var count = source.Count;
                for (var index = 0; index < count; index++)
                {
                    var item = array[index + offset];
                    if (predicate(item, index))
                        builder.Add(item);
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult>(in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> pool)
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TResult>(pool);
            var array = source.Array;
            if (source.Offset == 0 && source.Count == array.Length)
            {
                for (var sourceIndex = 0; sourceIndex < array.Length; sourceIndex++)
                {
                    if (predicate(array[sourceIndex]))
                        builder.Add(selector(array[sourceIndex]));
                }
            }
            else
            {
                var end = source.Offset + source.Count;
                for (var index = source.Offset; index < end; index++)
                {
                    if (predicate(array[index]))
                        builder.Add(selector(array[index]));
                }
            }
            return builder;
        }
    }
}
