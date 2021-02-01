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
                var item = source[index];
                if (predicate.Invoke(item))
                    builder.Add(item);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderRef<TSource, TPredicate>(ReadOnlySpan<TSource> source, TPredicate predicate, ArrayPool<TSource> arrayPool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (predicate.Invoke(in item))
                    builder.AddRef(in item);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TSource, TPredicate>(ReadOnlySpan<TSource> source, TPredicate predicate, ArrayPool<TSource> arrayPool)
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item, index))
                    builder.Add(item);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderAtRef<TSource, TPredicate>(ReadOnlySpan<TSource> source, TPredicate predicate, ArrayPool<TSource> arrayPool)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (predicate.Invoke(in item, index))
                    builder.AddRef(in item);
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
                var item = source[index];
                if (predicate.Invoke(item))
                    builder.Add(selector.Invoke(item));
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilderRef<TSource, TResult, TPredicate, TSelector>(ReadOnlySpan<TSource> source, TPredicate predicate, TSelector selector, ArrayPool<TResult> arrayPool)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (predicate.Invoke(in item))
                    builder.Add(selector.Invoke(in item));
            }
            return builder;
        }
    }
}
