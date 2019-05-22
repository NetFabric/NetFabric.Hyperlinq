using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count != 0;

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.Count == 0) return false;

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
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.Count == 0) return false;

            using (var enumerator = source.GetEnumerator())
            {
                var index = 0;
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current, index))
                        return true;

                    index++;
                }
            }
            return false;
        }
    }
}

