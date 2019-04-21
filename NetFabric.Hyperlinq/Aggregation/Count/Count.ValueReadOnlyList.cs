using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = 0;
            var length = source.Count;
            for (var index = 0; index < length; index++)
            {
                unchecked // always less than source.Count
                {
                    if (predicate(source[index], index))
                        count++;
                }
            }
            return count;
        }
    }
}

