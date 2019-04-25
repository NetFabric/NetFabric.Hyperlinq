namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => System.Linq.Enumerable.ToArray(source.AsEnumerable<TEnumerable, TEnumerator, TSource>());
    }
}
