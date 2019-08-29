using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source switch
            {
                ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                _ => new List<TSource>(new ToListCollection<TEnumerable, TEnumerator, TSource>(source)),
            };

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        sealed class ToListCollection<TEnumerable, TEnumerator, TSource>
            : ICollection<TSource>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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
                var index = 0;
                foreach (var item in source)
                {
                    array[index] = item;
                    checked { index++; }
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
