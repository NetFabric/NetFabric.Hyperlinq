using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            var count = source.Count();
            var list = new List<TSource>(count);
            if(count != 0)
                list.AddRange(source.AsEnumerable<TEnumerable, TEnumerator, TSource>());
            return list;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
