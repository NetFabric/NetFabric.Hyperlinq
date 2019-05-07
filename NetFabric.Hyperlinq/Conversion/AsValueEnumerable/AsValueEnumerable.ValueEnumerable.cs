using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static TEnumerable AsValueEnumerable<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
            => source;

        public static TEnumerable AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source;
    }
}
