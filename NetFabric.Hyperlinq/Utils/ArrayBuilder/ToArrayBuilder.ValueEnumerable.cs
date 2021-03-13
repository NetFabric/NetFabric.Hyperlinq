using System.Buffers;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TEnumerable, TEnumerator, TSource>(TEnumerable source, ArrayPool<TSource> arrayPool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                builder.Add(enumerator.Current);
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TPredicate>(TEnumerable source, ArrayPool<TSource> arrayPool, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item))
                    builder.Add(item);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TPredicate>(TEnumerable source, ArrayPool<TSource> arrayPool, TPredicate predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            var builder = new LargeArrayBuilder<TSource>(arrayPool);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                if (predicate.Invoke(item, index))
                    builder.Add(item);
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TSelector>(TEnumerable source, ArrayPool<TResult> arrayPool, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                builder.Add(selector.Invoke(enumerator.Current));
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilderAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(TEnumerable source, ArrayPool<TResult> arrayPool, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool);
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    builder.Add(selector.Invoke(enumerator.Current, index));
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(TEnumerable source, ArrayPool<TResult> arrayPool, TPredicate predicate, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var builder = new LargeArrayBuilder<TResult>(arrayPool);
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
