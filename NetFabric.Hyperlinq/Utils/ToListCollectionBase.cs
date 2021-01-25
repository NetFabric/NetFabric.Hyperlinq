using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
    [GeneratorIgnore]
    abstract class ToListCollectionBase<TSource>
        : ICollection<TSource>
    {
        protected ToListCollectionBase(int count)
            => Count = count;

        public int Count { get; }

        public abstract void CopyTo(TSource[] array, int arrayIndex);

        public bool IsReadOnly 
            => true;

        [ExcludeFromCodeCoverage]
        IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
            => Throw.NotSupportedException<IEnumerator<TSource>>();

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() 
            => Throw.NotSupportedException<IEnumerator>();

        [ExcludeFromCodeCoverage]
        void ICollection<TSource>.Add(TSource item) 
            => Throw.NotSupportedException();

        [ExcludeFromCodeCoverage]
        bool ICollection<TSource>.Remove(TSource item) 
            => Throw.NotSupportedException<bool>();

        [ExcludeFromCodeCoverage]
        void ICollection<TSource>.Clear() 
            => Throw.NotSupportedException();

        [ExcludeFromCodeCoverage]
        bool ICollection<TSource>.Contains(TSource item) 
            => Throw.NotSupportedException<bool>();
    }
}