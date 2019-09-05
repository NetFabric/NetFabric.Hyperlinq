using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [Ignore]
        sealed class ToListCollection<TSource>
            : ICollection<TSource>
        {
            readonly TSource[] source;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(TSource[] source, int skipCount, int takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public int Count => takeCount;

            public bool IsReadOnly => true;

            public void CopyTo(TSource[] array, int _)
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = source[index + skipCount];
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
