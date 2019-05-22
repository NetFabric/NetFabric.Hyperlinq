using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            using (var enumerator = source.GetEnumerator())
            {
                return enumerator.MoveNext();
            }
        }

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        return true;
                }
            }
            return false;
        }

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            using (var enumerator = source.GetEnumerator())
            {
                var index = 0L;
                checked
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current, index))
                            return true;

                        index++;
                    }
                }
            }
            return false;
        }
    }
}
