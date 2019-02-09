namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static int Count<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
            => source.Count();

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count();
    }
}

