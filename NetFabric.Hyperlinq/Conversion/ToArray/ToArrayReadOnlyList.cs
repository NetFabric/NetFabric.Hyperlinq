using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource[] ToArray<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source == null) ThrowSourceNull();

            var count = source.Count;
            var array = new TSource[count];
            for (var index = 0; index < count; index++)
                array[index] = source[index];
            return array;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
