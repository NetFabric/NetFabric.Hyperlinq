using System;
using System.Buffers;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource, TPredicate>(ReadOnlySpan<TSource> source, TPredicate predicate, ArrayPool<TSource> arrayPool)
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TSource, TPredicate>(ReadOnlySpan<TSource> source, TPredicate predicate, ArrayPool<TSource> arrayPool)
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index], index))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult, TPredicate, TSelector>(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, ArrayPool<TResult> arrayPool)
            where TPredicate: struct, IFunction<TSource, bool>
            where TSelector: struct, IFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                    builder.Add(selector.Invoke(source[index]));
            }
            return builder;
        }
    }
}
