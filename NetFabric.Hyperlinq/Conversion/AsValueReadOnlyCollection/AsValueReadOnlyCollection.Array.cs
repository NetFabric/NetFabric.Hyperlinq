namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static AsValueEnumerableEnumerable<TSource> AsValueReadOnlyCollection<TSource>(this TSource[] source)
            => new AsValueEnumerableEnumerable<TSource>(source);
    }
}
