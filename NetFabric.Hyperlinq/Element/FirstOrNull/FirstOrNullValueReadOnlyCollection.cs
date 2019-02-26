using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            
            if (source.Count() == 0) return null;

            using (var enumerator = source.GetValueEnumerator())
            {
                enumerator.TryMoveNext(out var current);
                return current;
            }
        }
    }
}
