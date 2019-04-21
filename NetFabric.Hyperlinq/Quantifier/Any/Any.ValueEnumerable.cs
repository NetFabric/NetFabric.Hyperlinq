using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static bool Any<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
        {
            using (var enumerator = source.GetValueEnumerator())
            {
                return enumerator.TryMoveNext();
            }
        }

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            using (var enumerator = source.GetValueEnumerator())
            {
                return enumerator.TryMoveNext();
            }
        }

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            using (var enumerator = source.GetValueEnumerator())
            {
                var index = 0;
                while (enumerator.TryMoveNext(out var current))
                {
                    checked
                    {
                        if (predicate(current, index))
                            return true;

                        index++;
                    }
                }
            }
            return false;
        }
    }
}
