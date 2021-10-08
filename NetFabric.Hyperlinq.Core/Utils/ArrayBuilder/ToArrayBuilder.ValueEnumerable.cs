using System.Buffers;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        internal static LargeArrayBuilder<TSource> ToArrayBuilder<TEnumerable, TEnumerator, TSource>(TEnumerable source, ArrayPool<TSource> arrayPool, bool clearOnDispose)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool, clearOnDispose);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                builder.Add(item);
            }
            return builder;
        }


        static LargeArrayBuilder<TSource> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TPredicate>(TEnumerable source, ArrayPool<TSource> arrayPool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool, clearOnDispose);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    builder.Add(item);
            }
            return builder;
        }


        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TPredicate>(TEnumerable source, ArrayPool<TSource> arrayPool, bool clearOnDispose, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool, clearOnDispose);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item, index))
                    builder.Add(item);
            }
            return builder;
        }


        static LargeArrayBuilder<TResult> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TSelector>(TEnumerable source, ArrayPool<TResult> arrayPool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool, clearOnDispose);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                builder.Add(selector.Invoke(item));
            }
            return builder;
        }


        static LargeArrayBuilder<TResult> ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(TEnumerable source, ArrayPool<TResult> arrayPool, bool clearOnDispose, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool, clearOnDispose);
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var item = enumerator.Current;
                    builder.Add(selector.Invoke(item, index));
                }
            }
            return builder;
        }


        static LargeArrayBuilder<TResult> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(TEnumerable source, ArrayPool<TResult> arrayPool, bool clearOnDispose, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool, clearOnDispose);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    builder.Add(selector.Invoke(item));
            }
            return builder;
        }
    }
}
