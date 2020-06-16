using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static CollectionWrapper<T> AsCollection<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new CollectionWrapper<T>(source);
        }

        public class CollectionWrapper<T> 
            : ReadOnlyCollectionWrapper<T>
            , ICollection<T>
        {
            internal CollectionWrapper(T[] source)
                : base(source)
            { }

            public bool IsReadOnly  
                => true;

            public void CopyTo(T[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);

            public bool Contains(T item)
                => ((IList<T>)source).Contains(item);

            void ICollection<T>.Add(T item) 
                => throw new NotSupportedException();
            bool ICollection<T>.Remove(T item) 
                => throw new NotSupportedException();
            void ICollection<T>.Clear() 
                => throw new NotSupportedException();
        }
    }
}