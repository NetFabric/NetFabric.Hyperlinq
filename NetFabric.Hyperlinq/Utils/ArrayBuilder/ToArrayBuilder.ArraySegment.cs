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
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item))
                        builder.Add(item);
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderRef<TSource, TPredicate>(in ArraySegment<TSource> source, TPredicate predicate, ArrayPool<TSource> pool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    ref readonly var item = ref array[index];
                    if (predicate.Invoke(in item))
                        builder.AddRef(in item);
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
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        if (predicate.Invoke(item, index))
                            builder.Add(item);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        if (predicate.Invoke(item, index))
                            builder.Add(item);
                    }
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderAtRef<TSource, TPredicate>(in ArraySegment<TSource> source, TPredicate predicate, ArrayPool<TSource> pool)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        ref readonly var item = ref array[index];
                        if (predicate.Invoke(in item, index))
                            builder.AddRef(item);
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        ref readonly var item = ref array[index + start];
                        if (predicate.Invoke(in item, index))
                            builder.AddRef(in item);
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
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    if (predicate.Invoke(item))
                        builder.Add(selector.Invoke(item));
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilderRef<TSource, TResult, TPredicate, TSelector>(in ArraySegment<TSource> source, TPredicate predicate, TSelector selector, ArrayPool<TResult> pool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(pool);
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    ref readonly var item = ref array[index];
                    if (predicate.Invoke(in item))
                        builder.Add(selector.Invoke(in item));
                }
            }
            return builder;
        }
    }
}
