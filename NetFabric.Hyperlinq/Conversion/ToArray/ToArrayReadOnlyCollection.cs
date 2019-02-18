using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = source.Count;
            var array = new TSource[count];
            var index = 0;
            using (var enumerator = Enumerable.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
            {
                while (enumerator.MoveNext())
                {
                    array[index] = enumerator.Current;
                    index++;
                }
            }
            return array;
        }
    }
}
