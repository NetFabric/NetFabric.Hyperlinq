using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
    [GeneratorIgnore]
    abstract class ToListCollectionBase<TSource>
        : ICollection<TSource>
    {
        public ToListCollectionBase(int count)
            => Count = count;

        public int Count { get; }

        public abstract void CopyTo(TSource[] array, int arrayIndex);

        public bool IsReadOnly 
            => true;

        IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
            => Throw.NotSupportedException<IEnumerator<TSource>>();

        IEnumerator IEnumerable.GetEnumerator() 
            => Throw.NotSupportedException<IEnumerator>();

        void ICollection<TSource>.Add(TSource item) 
            => Throw.NotSupportedException();

        bool ICollection<TSource>.Remove(TSource item) 
            => Throw.NotSupportedException<bool>();

        void ICollection<TSource>.Clear() 
            => Throw.NotSupportedException();

        bool ICollection<TSource>.Contains(TSource item) 
            => Throw.NotSupportedException<bool>();
    }
}