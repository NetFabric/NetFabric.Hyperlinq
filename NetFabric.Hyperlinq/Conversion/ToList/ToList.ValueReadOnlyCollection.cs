using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source)
            {
                case ICollection<TSource> collection:
                    return new List<TSource>(collection); // no need to allocate helper class

                default:
                    return new List<TSource>(new ToListCollection<TEnumerable, TEnumerator, TSource>(source));
            }
        }

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        class ToListCollection<TEnumerable, TEnumerator, TSource>
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
                using (var enumerator = source.GetEnumerator())
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        array[index] = enumerator.Current;
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
