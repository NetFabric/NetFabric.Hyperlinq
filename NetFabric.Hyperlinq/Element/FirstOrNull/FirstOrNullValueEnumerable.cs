using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = source.GetValueEnumerator())
            {
                if (enumerator.TryMoveNext(out var current))
                    return current; 

                return null;
            }
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext(out var current))
                {
                    if (predicate(current))
                        return current;
                }
                return null;
            }
        }
    }
}
