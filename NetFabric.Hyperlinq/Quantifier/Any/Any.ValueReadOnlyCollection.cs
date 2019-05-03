using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static bool Any<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
            => source.Count != 0;

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count != 0;

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.Count == 0) return false;

            using (var enumerator = source.GetValueEnumerator())
            {
                var index = 0;
                while (enumerator.TryMoveNext(out var current))
                {
                    if (predicate(current, index))
                        return true;

                    index++;
                }
            }
            return false;
        }
    }
}

