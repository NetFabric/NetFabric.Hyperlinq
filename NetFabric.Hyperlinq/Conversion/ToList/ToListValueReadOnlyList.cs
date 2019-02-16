using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            var count = source.Count();
            var list = new List<TSource>(count);
            list.AddRange(source.AsList<TEnumerable, TEnumerator, TSource>());
            return list;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
