using System.Buffers;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {


        static LargeArrayBuilder<TSource> ToArrayBuilder<TList, TSource, TPredicate>(in TList source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool, clearOnDispose);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    builder.Add(item);
            }
            return builder;
        }


        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TList, TSource, TPredicate>(in TList source, ArrayPool<TSource> pool, bool clearOnDispose, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(pool, clearOnDispose);
            var end = count;
            if (offset is 0)
            {
                for (var index = 0; index < end; index++)
                {
                    var item = source[index];
                    if (predicate.Invoke(item, index))
                        builder.Add(item);
                }
            }
            else
            {
                for (var index = 0; index < end; index++)
                {
                    var item = source[index + offset];
                    if (predicate.Invoke(item, index))
                        builder.Add(item);
                }
            }
            return builder;
        }


        static LargeArrayBuilder<TResult> ToArrayBuilder<TList, TSource, TResult, TPredicate, TSelector>(in TList source, ArrayPool<TResult> pool, bool clearOnDispose, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector: struct, IFunction<TSource, TResult>
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TResult>(pool, clearOnDispose);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    builder.Add(selector.Invoke(item));
            }
            return builder;
        }
    }
}
