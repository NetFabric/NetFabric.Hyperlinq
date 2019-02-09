using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count() == 0) return default;

            return source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            for (var index = 0; index < source.Count(); index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return default;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
