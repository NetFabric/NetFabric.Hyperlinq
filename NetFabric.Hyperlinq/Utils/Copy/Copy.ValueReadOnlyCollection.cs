using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static partial class ValueReadOnlyCollectionExtensions
    {
        public static void Copy<TEnumerable, TEnumerator, TSource>(TEnumerable source, Span<TSource> destination)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count is 0)
                return;

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    destination[index] = enumerator.Current;
            }
        }

        public static void Copy<TEnumerable, TEnumerator, TSource, TResult, TSelector>(TEnumerable source, Span<TResult> destination, TSelector selector = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return;

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    destination[index] = selector.Invoke(enumerator.Current);
            }
        }

        public static void CopyAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(TEnumerable source, Span<TResult> destination, TSelector selector = default)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Count is 0)
                return;

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    destination[index] = selector.Invoke(enumerator.Current, index);
            }
        }
    }
}
