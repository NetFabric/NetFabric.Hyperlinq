using System;
using System.Collections;
using System.Collections.Generic;
using Xunit.Sdk;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static CollectionWrapper<T> AsCollection<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                _ => new CollectionWrapper<T>(source)
            };

        public class CollectionWrapper<T> 
            : ReadOnlyCollectionWrapper<T>
            , ICollection<T>
        {
            internal CollectionWrapper(T[] source)
                : base(source)
            { }

            bool ICollection<T>.IsReadOnly  
                => true;

            void ICollection<T>.CopyTo(T[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);

            bool ICollection<T>.Contains(T item)
                => ((ICollection<T>)source).Contains(item);

            void ICollection<T>.Add(T item) 
                => throw new NotSupportedException();
            bool ICollection<T>.Remove(T item) 
                => throw new NotSupportedException();
            void ICollection<T>.Clear() 
                => throw new NotSupportedException();
        }
    }
}