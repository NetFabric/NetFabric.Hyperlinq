using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Count() == 0) return null;

            return source[0];
        }

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = source.Count();
            if (count == 0) return null;
            
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }
    }
}
