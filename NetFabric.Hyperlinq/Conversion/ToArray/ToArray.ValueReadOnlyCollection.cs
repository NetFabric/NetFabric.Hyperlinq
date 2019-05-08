using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var array = new TSource[source.Count];
            if (source.Count != 0)
            {
                using (var enumerator = source.GetEnumerator())
                {
                    for (var index = 0L; enumerator.MoveNext(); index++)
                        array[index] = enumerator.Current;
                }
            }
            return array;
        }
    }
}
