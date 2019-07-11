using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var count = source.Count;
            var array = new TSource[count];
            for (var index = 0; index < count; index++)
                array[index] = source[index];
            return array;
        }

        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var array = new TSource[takeCount];
            for (var index = 0; index < takeCount; index++)
                array[index] = source[index + skipCount];
            return array;
        }
    }
}
