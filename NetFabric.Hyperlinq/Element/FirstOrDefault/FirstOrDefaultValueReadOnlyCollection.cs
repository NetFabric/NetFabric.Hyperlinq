using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count() == 0) return default;

            using (var enumerator = source.GetValueEnumerator())
            {
                enumerator.TryMoveNext(out var current);
                return current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
