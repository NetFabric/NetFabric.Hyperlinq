using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            var count = source.Count;
            var array = new TSource[count];
            var index = 0;
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    array[index] = enumerator.Current;
                    index++;
                }
            }
            return array;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
