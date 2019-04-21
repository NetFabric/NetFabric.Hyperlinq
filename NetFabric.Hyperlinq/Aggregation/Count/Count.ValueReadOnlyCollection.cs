using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static int Count<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
            => source.Count;

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count == 0) return 0;

            var count = 0;
            if (source.Count != 0)
            {
                var index = 0;
                using (var enumerator = source.GetValueEnumerator())
                {
                    while (enumerator.TryMoveNext(out var current))
                    {
                        unchecked // always less than source.Count
                        {
                            if (predicate(current, index))
                                count++;
                            
                            index++;
                        }
                    }
                }
            }
            return count;
        }
    }
}

