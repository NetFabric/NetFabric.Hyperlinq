using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count != 0;

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Count;
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var count = source.Count;
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index], index))
                    return true;
            }
            return false;
        }
    }
}

