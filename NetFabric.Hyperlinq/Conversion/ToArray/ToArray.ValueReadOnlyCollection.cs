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
                var index = 0L;
                using (var enumerator = source.GetValueEnumerator())
                {
                    if (source.Count != 0)
                    {
                        while (enumerator.TryMoveNext(out var current))
                        {
                            array[index] = current;
                            index++;
                        }
                    }
                }
            }
            return array;
        }
    }
}
