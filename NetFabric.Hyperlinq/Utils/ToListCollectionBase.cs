using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
    [Ignore]
    abstract class ToListCollectionBase<TSource>
        : ICollection<TSource>
    {

        public ToListCollectionBase(int count)
        {
            Count = count;
        }

        public int Count { get; }

        public abstract void CopyTo(TSource[] array, int arrayIndex);

        public bool IsReadOnly => true;

        IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => throw new NotSupportedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
        void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
        bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
        void ICollection<TSource>.Clear() => throw new NotSupportedException();
        bool ICollection<TSource>.Contains(TSource item) => throw new NotSupportedException();
    }
}