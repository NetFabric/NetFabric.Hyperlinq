using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static partial class ValueReadOnlyCollectionExtensions
    {
        public static void Copy<TEnumerable, TEnumerator, TSource>(TEnumerable source, TSource[] destination)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0)
                return;

            switch (source)
            {
                case ICollection<TSource> collection:
                    collection.CopyTo(destination, 0);
                    break;

                default:
                    {
                        using var enumerator = source.GetEnumerator();
                        checked
                        {
                            for (var index = 0; enumerator.MoveNext(); index++)
                                destination[index] = enumerator.Current;
                        }
                    }
                    break;
            }
        }

        public static void Copy<TEnumerable, TEnumerator, TSource>(TEnumerable source, Span<TSource> destination)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0)
                return;

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    destination[index] = enumerator.Current;
            }
        }

        public static void Copy<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, TResult[] destination, NullableSelector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0)
                return;

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    destination[index] = selector(enumerator.Current)!;
            }
        }

        public static void Copy<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, Span<TResult> destination, NullableSelector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0)
                return;

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    destination[index] = selector(enumerator.Current)!;
            }
        }

        public static void Copy<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, TResult[] destination, NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0)
                return;

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    destination[index] = selector(enumerator.Current, index)!;
            }
        }

        public static void Copy<TEnumerable, TEnumerator, TSource, TResult>(TEnumerable source, Span<TResult> destination, NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count == 0)
                return;

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    destination[index] = selector(enumerator.Current, index)!;
            }
        }
    }
}
