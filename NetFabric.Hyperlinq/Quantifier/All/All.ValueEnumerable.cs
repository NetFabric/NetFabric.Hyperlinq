using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
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
                        if (!predicate(current, index))
                            return false;

                        index++;
                    }
                }
            }
            return true;
        }
    }
}
