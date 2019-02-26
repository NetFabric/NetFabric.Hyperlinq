using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = source.Count();
            if (count == 0) return null;
            if (count > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            using (var enumerator = source.GetValueEnumerator())
            {
                enumerator.TryMoveNext(out var current);
                return current;
            }
        }
    }
}
