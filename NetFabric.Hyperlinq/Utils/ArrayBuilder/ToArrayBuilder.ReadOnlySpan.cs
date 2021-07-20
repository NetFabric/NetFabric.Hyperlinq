using System;
using System.Buffers;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {


        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource, TPredicate>(ReadOnlySpan<TSource> source, ArrayPool<TSource> arrayPool, bool clearOnDispose, TPredicate predicate)
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool, clearOnDispose);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    builder.Add(item);
            }
            return builder;
        }


        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TSource, TPredicate>(ReadOnlySpan<TSource> source, ArrayPool<TSource> arrayPool, bool clearOnDispose, TPredicate predicate)
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool, clearOnDispose);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    builder.Add(item);
            }
            return builder;
        }


        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult, TPredicate, TSelector>(ReadOnlySpan<TSource> source, ArrayPool<TResult> arrayPool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TPredicate: struct, IFunction<TSource, bool>
            where TSelector: struct, IFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool, clearOnDispose);
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    builder.Add(selector.Invoke(item));
            }
            return builder;
        }
    }
}
