using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static long Count<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
            => source.Count;

        public static long Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        public static long Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = 0L;
            if (source.Count != 0)
            {
                var index = 0L;
                using (var enumerator = source.GetValueEnumerator())
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                        if (predicate(current, index))
                            count++;
                        
                        index++;
                    }
                }
            }
            return count;
        }
    }
}

