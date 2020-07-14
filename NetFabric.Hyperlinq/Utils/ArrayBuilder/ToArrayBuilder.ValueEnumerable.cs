using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TEnumerable, TEnumerator, TSource>(TEnumerable source, ArrayPool<TSource> arrayPool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TSource>(arrayPool);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                builder.Add(enumerator.Current);
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TEnumerable, TEnumerator, TSource>(TEnumerable source, Predicate<TSource> predicate, ArrayPool<TSource> arrayPool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TSource>(arrayPool);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    builder.Add(item);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TEnumerable, TEnumerator, TSource>(TEnumerable source, PredicateAt<TSource> predicate, ArrayPool<TSource> arrayPool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TSource>(arrayPool);
            using var enumerator = source.GetEnumerator();
            for (var index = 0; enumerator.MoveNext(); index++)
            {
                var item = enumerator.Current;
                if (predicate(item, index))
                    builder.Add(item);
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> arrayPool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TResult>(arrayPool);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                builder.Add(selector(enumerator.Current));
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, NullableSelectorAt<TSource, TResult> selector, ArrayPool<TResult> arrayPool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TResult>(arrayPool);
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    builder.Add(selector(enumerator.Current, index));
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, ArrayPool<TResult> arrayPool)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            Debug.Assert(arrayPool is object);

            using var builder = new LargeArrayBuilder<TResult>(arrayPool);
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                    builder.Add(selector(item));
            }
            return builder;
        }
    }
}
