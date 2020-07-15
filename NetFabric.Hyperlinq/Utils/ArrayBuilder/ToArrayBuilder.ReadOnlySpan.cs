using System;
using System.Buffers;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ReadOnlySpan<TSource> source, Predicate<TSource> predicate, ArrayPool<TSource> arrayPool)
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource>(in ReadOnlySpan<TSource> source, PredicateAt<TSource> predicate, ArrayPool<TSource> arrayPool)
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult>(in ReadOnlySpan<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> arrayPool)
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    builder.Add(selector(source[index]));
            }
            return builder;
        }
    }
}
