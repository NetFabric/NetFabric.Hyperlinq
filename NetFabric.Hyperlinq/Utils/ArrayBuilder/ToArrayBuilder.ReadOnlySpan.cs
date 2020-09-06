using System;
using System.Buffers;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TSource, TPredicate>(ReadOnlySpan<TSource> source, TPredicate predicate, ArrayPool<TSource> arrayPool)
            where TPredicate : struct, IPredicate<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TSource, TPredicate>(ReadOnlySpan<TSource> source, TPredicate predicate, ArrayPool<TSource> arrayPool)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index], index))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TSource, TResult, TPredicate>(ReadOnlySpan<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> arrayPool)
            where TPredicate : struct, IPredicate<TSource>
        {
            Debug.Assert(arrayPool is object);

            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                    builder.Add(selector(source[index]));
            }
            return builder;
        }
    }
}
