using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        sealed class ToListCollection<TEnumerable, TSource>
            : ICollection<TSource>
            where TEnumerable : IReadOnlyCollection<TSource>
        {
            readonly TEnumerable source;

            public ToListCollection(TEnumerable source)
            {
                this.source = source;
            }

            public int Count => source.Count;

            public bool IsReadOnly => true;

            public void CopyTo(TSource[] array, int _)
            {
                // List<T> constructor checks if Count is zero
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        array[index] = enumerator.Current;
                    }
                }
            }

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => throw new NotSupportedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
            void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
            void ICollection<TSource>.Clear() => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) => throw new NotSupportedException();
        }
    }
}
